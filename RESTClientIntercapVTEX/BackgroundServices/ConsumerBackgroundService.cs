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
    internal class ConsumerBackgroundService //: BackgroundService
    {

        // Max execution per period
        const int MAX_PER_PERIOD = 2;
        // This is the number os concurrent action that will be release in the first few milliseconds of each minute
        // You can set another inital value if you don't want to have a peek in each minute
        const int MAX_ACTION_CONCURRENT = 1;


        // This semaphore is to control the time
        private static SemaphoreSlim _semaphoreSlimPeriod = new SemaphoreSlim(MAX_PER_PERIOD);
        // This semaphore is to control the action.
        private static SemaphoreSlim _semaphoreSlimAction = new SemaphoreSlim(MAX_ACTION_CONCURRENT);
        // All throttlings are rest every minute
        private readonly TimeSpan PERIOD = TimeSpan.FromMinutes(1);
        private readonly Serilog.ILogger _logger;
        public CategorysService _categoryService { get; }
        public SpecificationsService _specificationService { get; }

        public ConsumerBackgroundService(Serilog.ILogger logger, CategorysService categoryService, 
                                                                 SpecificationsService specificationService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _specificationService = specificationService;
        }


        public async Task RunAsync(CancellationToken stoppingToken)
        {
            if (MAX_PER_PERIOD < MAX_ACTION_CONCURRENT)
            {
                throw new Exception("The MAX_PER_PERIOD should be more or equal to MAX_ACTION_CONCURRENT");
            }

            try
            {
                while (true)
                {
                    // waiting an opportunity to run an action
                    await _semaphoreSlimAction.WaitAsync(stoppingToken);
                    // waiting the last period to end
                    await _semaphoreSlimPeriod.WaitAsync(stoppingToken);

                    var hasMoreInThisMinute = false;
                    try
                    {
                        await ExecServiceAsync(_categoryService, stoppingToken);
                        await ExecServiceAsync(_specificationService, stoppingToken);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"Se produjo un error al enviar datos: {ex.Message}.");
                    }
                    finally
                    {
                        if (hasMoreInThisMinute)
                        {
                            //_logger.Information("Release action sempahore");
                            _semaphoreSlimAction.Release(1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Fatal("BackgroundWorker stopped by error `{exMessage}`.", ex.Message);
                throw;
            }
        }

        private async Task ExecServiceAsync(IServiceVTEX _service, CancellationToken stoppingToken)
        {
            using var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMinutes(5));
            using var cancellationTokenLinked = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken, cancellationTokenSource.Token);

            //_logger.Information($"Ejecutando servicio {_service}");

            bool hasMoreInThisMinute = await _service.DequeueProcessAndCheckIfContinueAsync(cancellationTokenLinked.Token);
            //_logger.Information($"Ejecutado y {(hasMoreInThisMinute ? "tiene" : "no tiene")} más items");

            _ = Task.Delay(PERIOD).ContinueWith(task =>
            {
                //_logger.Debug("Release period sempahore");
                _semaphoreSlimPeriod.Release(1);
                if (!hasMoreInThisMinute)
                {
                    //_logger.Information("Release action sempahore after no more items");
                    _semaphoreSlimAction.Release(1);
                }
            });
        }
    }

}
