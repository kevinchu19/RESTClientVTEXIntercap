using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RESTClientIntercapVTEX.BackgroundServices;
using RESTClientIntercapVTEX.Client;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.MapperHelp.CategorysResolver;
using RESTClientIntercapVTEX.MapperHelp.SpecificationsResolver;
using RESTClientIntercapVTEX.Models;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using RESTClientIntercapVTEX.Repositories.Persistance;
using RESTClientIntercapVTEX.Services;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX
{
    class Program
    {
        public static IConfigurationRoot Configuration;

        static int Main(string[] args)
        {
            try
            {
                // Start!
                MainAsync(args).Wait();
                return 0;
            }
            catch (Exception ex)
            {
                var a = ex;
                return 1;
            }
        }

        static async Task MainAsync(string[] args)
        {
            // Create service collection
            Log.Information("Creating service collection");
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Create service provider
            Log.Information("Building service provider");
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            // Print connection string to demonstrate configuration object is populated
            Console.WriteLine(Configuration.GetConnectionString("DataConnection"));

            try
            {

                Log.Information("Comenzando servicio de categorias");
                await serviceProvider.GetService<ConsumerBackgroundService>().RunAsync(new CancellationTokenSource()
                                                                                            .Token);
                Log.Information("Terminando servicio de categorias");
            }

            catch (Exception ex)
            {
                Log.Fatal(ex, "Error running service");
                throw ex;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            
            
            // Build configuration
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("app.settings.json", false)
                .Build();
            
            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton<IConfigurationRoot>(Configuration);            

            // Add logging
            serviceCollection.AddSingleton<Serilog.ILogger>(options =>
            {
                var connstring = Configuration["Serilog:SerilogConnectionString"];
                var tableName = Configuration["Serilog:TableName"];

                return new LoggerConfiguration()
                            .WriteTo
                            .MSSqlServer(
                                connectionString: connstring,
                                sinkOptions: new MSSqlServerSinkOptions { TableName = tableName, AutoCreateSqlTable = true },
                                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
                            .CreateLogger();

            });

            serviceCollection.AddLogging();

            Serilog.ILogger _logger =  new LoggerConfiguration()
                                        .WriteTo
                                        .MSSqlServer(
                                            connectionString: Configuration["Serilog:SerilogConnectionString"],
                                            sinkOptions: new MSSqlServerSinkOptions { TableName = Configuration["Serilog:TableName"], AutoCreateSqlTable = true },
                                            restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
                                        .CreateLogger();

            //Add DbContext
            serviceCollection.AddDbContext<ApiIntercapContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")).EnableSensitiveDataLogging());

            // Add HttpClient
            serviceCollection.AddTransient<HttpClient>();

            // Add Services
            serviceCollection.AddTransient<SpecificationsService>();
            serviceCollection.AddTransient(provider =>
                new SpecificationsClient<SpecificationDTO>(new HttpClient() { },Configuration, Configuration["VTEX:Specifications:Path"], _logger));
            
            serviceCollection.AddTransient<CategorysService>();
            serviceCollection.AddTransient(provider =>
                new CategorysClient<CategoryDTO>(new HttpClient() { }, Configuration, Configuration["VTEX:Categorys:Path"], _logger));
            serviceCollection.AddTransient(provider =>
                new SpecificationGroupClient<SpecificationGroupDTO>(new HttpClient() { }, Configuration, Configuration["VTEX:SpecificationsGroup:Path"], _logger));

            // Add app
            serviceCollection.AddSingleton<ConsumerBackgroundService>();


            //Unit of work
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddAutoMapper(configuration =>
            {
                configuration.CreateMap<Usr_Sttcaa, SpecificationDTO>()
                .ForMember(dest => dest.FieldTypeId, opt => opt.MapFrom(src => Convert.ToInt32(src.Usr_Sttcaa_Fieldt)))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => Convert.ToInt32(src.Usr_Sttcaa_Deptos)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Usr_Sttcaa_Codatr))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Usr_Sttcaa_Descrp))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Usr_Sttcaa_Positi))
                .ForMember(dest => dest.IsFilter, opt => opt.MapFrom(src => src.Usr_Sttcaa_Isfilt == "S"))
                .ForMember(dest => dest.IsRequired, opt => opt.MapFrom(src => src.Usr_Sttcaa_Isrequ == "S"))
                .ForMember(dest => dest.IsOnProductDetails, opt => opt.MapFrom(src => src.Usr_Sttcaa_Isonpr == "S"))
                .ForMember(dest => dest.IsStockKeepingUnit, opt => opt.MapFrom(src => src.Usr_Sttcaa_Isssku == "S"))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Usr_Sttcaa_Isacti == "S"))
                .ForMember(dest => dest.IsTopMenuLinkActive, opt => opt.MapFrom(src => src.Usr_Sttcaa_Topmen == "S"))
                .ForMember(dest => dest.IsSideMenuLinkActive, opt => opt.MapFrom(src => src.Usr_Sttcaa_Sidmen == "S"))
                .ForMember(dest => dest.DefaultValue, opt => opt.MapFrom(src => src.Usr_Sttcaa_Defaul));

                configuration.CreateMap<Usr_Sttcah, CategoryDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Convert.ToInt32(src.Usr_Sttcah_Deptos)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Usr_Sttcah_Descrp))
                .ForMember(dest => dest.Keywords, opt => opt.MapFrom(src => src.Usr_Sttcah_Keywor))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Usr_Sttcah_Descrp))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Usr_Sttcah_Descri))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Usr_St_Debaja == "N"))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Usr_Sttcah_Scores));

                configuration.CreateMap<Usr_Sttcai, CategoryDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom<IdCategoryResolver>())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Usr_Sttcai_Descrp))
                .ForMember(dest => dest.Keywords, opt => opt.MapFrom(src => src.Usr_Sttcai_Keywor))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Usr_Sttcai_Descrp))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Usr_Sttcai_Descri))
                .ForMember(dest => dest.FatherCategoryId, opt => opt.MapFrom(src => Convert.ToInt32(src.Usr_Sttcai_Deptos).ToString()))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Usr_Sttcai_Isacti == "S"))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Usr_Sttcai_Scores));

                configuration.CreateMap<Usr_Sttcas, CategoryDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom<IdSubcategoryResolver>())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Usr_Sttcas_Descrp))
                .ForMember(dest => dest.Keywords, opt => opt.MapFrom(src => src.Usr_Sttcas_Keywor))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Usr_Sttcas_Descrp))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Usr_Sttcas_Descri))
                .ForMember(dest => dest.FatherCategoryId, opt => opt.MapFrom<FatherSubcategoryIdResolver>())
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Usr_Sttcas_Isacti == "S"))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Usr_Sttcas_Scores));
            }
                , typeof(Program));
        }
    }
}
