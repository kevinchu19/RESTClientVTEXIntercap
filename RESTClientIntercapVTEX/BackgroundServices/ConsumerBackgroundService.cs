using Microsoft.Extensions.Hosting;
using RESTClientIntercapVTEX.Models;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using RESTClientIntercapVTEX.Services;
using RESTClientIntercapVTEX.Services.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.BackgroundServices
{
    internal class ConsumerBackgroundService: BackgroundService
    {

        // Max execution per period
        const int MAX_PER_PERIOD = 1;
        // This is the number os concurrent action that will be release in the first few milliseconds of each minute
        // You can set another inital value if you don't want to have a peek in each minute
        const int MAX_ACTION_CONCURRENT = 1;


        // This semaphore is to control the time
        private static SemaphoreSlim _semaphoreSlimPeriodFeed = new SemaphoreSlim(MAX_PER_PERIOD);
        // This semaphore is to control the action.
        private static SemaphoreSlim _semaphoreSlimActionFeed = new SemaphoreSlim(MAX_ACTION_CONCURRENT);

        // This semaphore is to control the time
        private static SemaphoreSlim _semaphoreSlimPeriod = new SemaphoreSlim(MAX_PER_PERIOD);
        // This semaphore is to control the action.
        private static SemaphoreSlim _semaphoreSlimAction = new SemaphoreSlim(MAX_ACTION_CONCURRENT);
        // All throttlings are rest every minute
        private readonly TimeSpan PERIOD = TimeSpan.FromMinutes(1);
        private readonly Serilog.ILogger _logger;
        public CategorysService _categoryService { get; }
        public SpecificationsService _specificationService { get; }
        public SpecificationsGroupService _specificationGroupService { get; }
        public BrandsService _brandsService { get; }
        public ProductsService _productService { get; }
        public SKUService _SKUService { get; private set; }
        public SpecificationValuesService _specificationValuesService { get; }
        public ProductSpecificationsService _productSpecificationsService{ get; }
        public SKUSpecificationsService _SKUSpecificationsService { get; }
        public SKUFilesService _SKUFilesService { get; }
        public InventoryService _inventoryService { get; }
        public PricesService _pricesService { get; }

        public MotosService _motosService { get; }

        public FeedService _feedService { get; set; }
        public OrderService _ordersService { get; set; }


        public ConsumerBackgroundService(Serilog.ILogger logger, CategorysService categoryService, 
                                                                 SpecificationsService specificationService,
                                                                 SpecificationsGroupService specificationGroupService,
                                                                 BrandsService brandsService,
                                                                 ProductsService productService,
                                                                 SKUService SKUService,
                                                                 SpecificationValuesService specificationValuesService,
                                                                 ProductSpecificationsService productSpecificationsService,
                                                                 SKUSpecificationsService SKUSpecificationsService,
                                                                 SKUFilesService SKUFilesService,
                                                                 InventoryService inventoryService,
                                                                 PricesService pricesService,
                                                                 MotosService motosService, 
                                                                 FeedService feedService,
                                                                 OrderService ordersService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _specificationService = specificationService;
            _specificationGroupService = specificationGroupService;
            _brandsService = brandsService;
            _productService = productService;
            _SKUService = SKUService;
            //_specificationValuesService = specificationValuesService;
            _productSpecificationsService = productSpecificationsService;
            _SKUSpecificationsService = SKUSpecificationsService;
            _SKUFilesService = SKUFilesService;
            _inventoryService = inventoryService;
            _pricesService = pricesService;
            _motosService = motosService;
            _feedService = feedService;
            _ordersService = ordersService;
        }


        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (MAX_PER_PERIOD < MAX_ACTION_CONCURRENT)
            {
                throw new Exception("The MAX_PER_PERIOD should be more or equal to MAX_ACTION_CONCURRENT");
            }

            try
            {
                while (true)
                {
                    try
                    {
                        await ExecFeedServiceAsync(stoppingToken);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"Se produjo un error al enviar datos: {ex.Message}, {ex.StackTrace}.");
                    }
                    // waiting an opportunity to run an action
                    //await _semaphoreSlimAction.WaitAsync(stoppingToken);
                    // waiting the last period to end
                    await _semaphoreSlimPeriod.WaitAsync(stoppingToken);

                    try
                    {
                        await ExecServiceAsync(_ordersService, stoppingToken);
                        await ExecServiceAsync(_categoryService, stoppingToken);
                        await ExecServiceAsync(_brandsService, stoppingToken);
                        await ExecServiceAsync(_specificationGroupService, stoppingToken);
                        await ExecServiceAsync(_specificationService, stoppingToken);
                        await ExecServiceAsync(_productService, stoppingToken);
                        await ExecServiceAsync(_SKUService, stoppingToken);
                        //await ExecServiceAsync(_specificationValuesService, stoppingToken);
                        await ExecServiceAsync(_motosService, stoppingToken);
                        await ExecServiceAsync(_productSpecificationsService, stoppingToken);
                        await ExecServiceAsync(_SKUSpecificationsService, stoppingToken);
                        await ExecServiceAsync(_SKUFilesService, stoppingToken);
                        await ExecServiceAsync(_inventoryService, stoppingToken);
                        await ExecServiceAsync(_pricesService, stoppingToken);

                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"Se produjo un error al enviar datos: {ex.Message}, {ex.StackTrace}.");
                    }
                    finally
                    {
                        _ = Task.Delay(PERIOD).ContinueWith(task =>
                        {
                            _logger.Debug("Release period sempahore");
                            _semaphoreSlimPeriod.Release(1);
                            _semaphoreSlimAction.Release(1);
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Fatal($"BackgroundWorker stopped by error {ex.Message}");
                throw;
            }
        }

        private async Task ExecServiceAsync(IServiceVTEX _service, CancellationToken stoppingToken)
        {
            using var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMinutes(5));
            using var cancellationTokenLinked = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken, cancellationTokenSource.Token);
            bool hasMoreInThisMinute = true;

            while (hasMoreInThisMinute)
            {
                // waiting an opportunity to run an action
                await _semaphoreSlimAction.WaitAsync(stoppingToken);

                //_logger.Information($"Ejecutando servicio {_service}");

                hasMoreInThisMinute = await _service.DequeueProcessAndCheckIfContinueAsync(cancellationTokenLinked.Token);
                //_logger.Information($"Ejecutado y {(hasMoreInThisMinute ? "tiene" : "no tiene")} más items");

                if (!hasMoreInThisMinute)
                {
                    _logger.Information($"Release action sempahore after no more items, {_service.ToString()}");
                    _semaphoreSlimAction.Release(1);
                }
                else
                {
                    _ = Task.Delay(TimeSpan.FromSeconds(10)).ContinueWith(task =>
                    {
                        _logger.Debug("Release action sempahore to get more items");
                        _semaphoreSlimAction.Release(1);
                    });
                }
            }
        }

        protected async Task ExecFeedServiceAsync(CancellationToken stoppingToken)
        {
            if (MAX_PER_PERIOD < MAX_ACTION_CONCURRENT)
            {
                throw new Exception("The MAX_PER_PERIOD should be more or equal to MAX_ACTION_CONCURRENT");
            }

            try
            {
                var hasMoreInThisMinute = true;
                while (hasMoreInThisMinute)
                {
                    // waiting an opportunity to run an action
                    await _semaphoreSlimActionFeed.WaitAsync(stoppingToken);
                    // waiting the last period to end
                    await _semaphoreSlimPeriodFeed.WaitAsync(stoppingToken);

                    
                    try
                    {
                        using var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMinutes(5));
                        using var cancellationTokenLinked = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken, cancellationTokenSource.Token);

                        
                        hasMoreInThisMinute = await _feedService.DequeueProcessAndCheckIfContinueAsync(cancellationTokenLinked.Token);

                        _ = Task.Delay(PERIOD).ContinueWith(task =>
                        {
                            _logger.Information("Feed: Release period sempahore");
                            _semaphoreSlimPeriodFeed.Release(1);
                            if (!hasMoreInThisMinute)
                            {
                                _logger.Information("Feed: Release action sempahore after no more items");
                                _semaphoreSlimActionFeed.Release(1);
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"An error has occurred when processing the feed: {ex.Message}." );
                    }
                    finally
                    {
                        if (hasMoreInThisMinute)
                        {
                            _logger.Information("Feed: Release action sempahore");
                            _semaphoreSlimActionFeed.Release(1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Fatal($"BackgroundWorker stopped by error  {ex.Message}.");
                throw;
            }
        }
    }

}
