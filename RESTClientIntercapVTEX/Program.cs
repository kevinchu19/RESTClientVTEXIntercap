using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RESTClientIntercapVTEX.BackgroundServices;
using RESTClientIntercapVTEX.Client;
using RESTClientIntercapVTEX.Entities;
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
                Log.Information("Starting service");
                await serviceProvider.GetService<ConsumerBackgroundService<SpecificationsService<SpecificationDTO>>>().RunAsync(new CancellationTokenSource()
                                                                                            .Token);
                Log.Information("Ending service");
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

            //Add DbContext
            serviceCollection.AddDbContext<ApiIntercapContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")).EnableSensitiveDataLogging());

            // Add HttpClient
            serviceCollection.AddTransient<HttpClient>();

            // Add Services
            serviceCollection.AddTransient<SpecificationsService<SpecificationDTO>>();
            serviceCollection.AddTransient(provider =>
                new SpecificationsClient<SpecificationDTO>(new HttpClient() { },Configuration, Configuration["VTEX:Specifications:Path"]));
            // Add app
            serviceCollection.AddTransient<ConsumerBackgroundService<SpecificationsService<SpecificationDTO>>>();


            //Unit of work
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddAutoMapper(configuration =>
            {
                configuration.CreateMap<Usr_Sttcaa, SpecificationDTO>()
                .ForMember(dest => dest.FieldTypeId, opt => opt.MapFrom(src => Convert.ToInt32(src.Usr_Sttcaa_Fieldt)))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => Convert.ToInt32(src.Usr_Sttcaa_Deptos)))
                .ForMember(dest => dest.FieldGroupId, opt => opt.MapFrom<FieldGroupIdResolver>())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Usr_Sttcaa_Codatr))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Usr_Sttcaa_Descrp))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Usr_Sttcaa_Positi))
                .ForMember(dest => dest.IsFilter, opt => opt.MapFrom(src => src.Usr_Sttcaa_Isfilt =="S"))
                .ForMember(dest => dest.IsRequired, opt => opt.MapFrom(src => src.Usr_Sttcaa_Isrequ == "S"))
                .ForMember(dest => dest.IsOnProductDetails, opt => opt.MapFrom(src => src.Usr_Sttcaa_Isonpr == "S"))
                .ForMember(dest => dest.IsStockKeepingUnit, opt => opt.MapFrom(src => src.Usr_Sttcaa_Isssku == "S"))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Usr_Sttcaa_Isacti == "S"))
                .ForMember(dest => dest.IsTopMenuLinkActive, opt => opt.MapFrom(src => src.Usr_Sttcaa_Topmen == "S"))
                .ForMember(dest => dest.IsSideMenuLinkActive, opt => opt.MapFrom(src => src.Usr_Sttcaa_Sidmen == "S"))
                .ForMember(dest => dest.DefaultValue, opt => opt.MapFrom(src => src.Usr_Sttcaa_Defaul))
                .ReverseMap();

            }
                , typeof(Program));
        }
    }
}
