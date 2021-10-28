using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RESTClientIntercapVTEX.BackgroundServices;
using RESTClientIntercapVTEX.Client;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Entities.Test;
using RESTClientIntercapVTEX.MapperHelp.CategorysResolver;
using RESTClientIntercapVTEX.MapperHelp.SpecificationsResolver;
using RESTClientIntercapVTEX.Models;
using RESTClientIntercapVTEX.Models.Order;
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
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                var a = ex;
                return 1;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {

            return Host.CreateDefaultBuilder(args)
               .UseWindowsService()
               .ConfigureServices((hostContext, services) =>
               {

                   // Build configuration
                   Configuration = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                       .AddJsonFile("app.settings.json", false)
                       .Build();

                   // Add access to generic IConfigurationRoot
                   services.AddSingleton<IConfigurationRoot>(Configuration);

                   // Add logging
                   services.AddSingleton<Serilog.ILogger>(options =>
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

                   services.AddLogging();

                   Serilog.ILogger _logger = new LoggerConfiguration()
                                               .WriteTo
                                               .MSSqlServer(
                                                   connectionString: Configuration["Serilog:SerilogConnectionString"],
                                                   sinkOptions: new MSSqlServerSinkOptions { TableName = Configuration["Serilog:TableName"], AutoCreateSqlTable = true },
                                                   restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
                                               .CreateLogger();

                   //Add DbContext
                   services.AddDbContext<ApiIntercapContext>(options =>
                       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")).EnableSensitiveDataLogging());

                   services.AddDbContext<ApiIntercapTestContext>(options =>
                       options.UseSqlServer(Configuration.GetConnectionString("TestConnectionString")).EnableSensitiveDataLogging());


                   // Add HttpClient
                   services.AddTransient<HttpClient>();

                   // Add Services
                   services.AddTransient<SpecificationsService>();
                   services.AddTransient(provider =>
                       new SpecificationsClient<SpecificationDTO>(new HttpClient() { }, Configuration, Configuration["VTEX:Specifications:Path"], _logger));

                   services.AddTransient<CategorysService>();
                   services.AddTransient(provider =>
                       new CategorysClient<CategoryDTO>(new HttpClient() { }, Configuration, Configuration["VTEX:Categorys:Path"], _logger));

                   services.AddTransient<SpecificationsGroupService>();
                   services.AddTransient(provider =>
                       new SpecificationGroupClient<SpecificationGroupDTO>(new HttpClient() { }, Configuration, Configuration["VTEX:SpecificationsGroup:Path"], _logger));

                   services.AddTransient<BrandsService>();
                   services.AddTransient(provider =>
                       new BrandsClient<BrandDTO>(new HttpClient() { }, Configuration, Configuration["VTEX:Brands:Path"], _logger));

                   services.AddTransient<ProductsService>();
                   services.AddTransient(provider =>
                       new ProductsClient<ProductDTO>(new HttpClient() { }, Configuration, Configuration["VTEX:Products:Path"], _logger));

                   services.AddTransient<SKUService>();
                   services.AddTransient(provider =>
                       new SKUClient<SkuDTO>(new HttpClient() { }, Configuration, Configuration["VTEX:SKU:Path"], _logger));

                   services.AddTransient<SpecificationValuesService>();
                   services.AddTransient(provider =>
                       new SpecificationValuesClient<SpecificationValueDTO>(new HttpClient() { }, Configuration, Configuration["VTEX:SpecificationValues:Path"], _logger));

                   services.AddTransient<ProductSpecificationsService>();
                   services.AddTransient(provider =>
                       new ProductAndSKUSpecificationsClient<ProductSpecificationDTO>(new HttpClient() { }, Configuration, Configuration["VTEX:ProductSpecifications:Path"], _logger));

                   services.AddTransient<SKUSpecificationsService>();
                   services.AddTransient(provider =>
                       new ProductAndSKUSpecificationsClient<SKUSpecificationDTO>(new HttpClient() { }, Configuration, Configuration["VTEX:SKU:Path"], _logger));

                   services.AddTransient<SKUFilesService>();
                   services.AddTransient(provider =>
                       new SKUFilesClient<SKUFileDTO>(new HttpClient() { }, Configuration, Configuration["VTEX:SKU:Path"], _logger));

                   services.AddTransient<InventoryService>();
                   services.AddTransient(provider =>
                       new InventoryClient<InventoryDTO>(new HttpClient() { }, Configuration, Configuration["VTEX:Inventory:Path"], _logger));

                   services.AddTransient<PricesService>();
                   services.AddTransient(provider =>
                       new PricesClient<PricesDTO>(new HttpClient() { }, Configuration, Configuration["VTEX:Prices:Path"], _logger));

                   services.AddTransient<MotosService>();
                   services.AddTransient(provider =>
                       new MotosClient<MotosDocumentDTO>(new HttpClient() { }, Configuration, Configuration["VTEX:Motos:Path"], _logger));

                   services.AddTransient<FeedService>();
                   services.AddTransient(provider =>
                       new FeedClient<FeedDTO>(new HttpClient() { }, Configuration, Configuration["VTEX:Feed:Path"], _logger));

                   services.AddTransient<OrderService>();
                   services.AddTransient(provider =>
                       new OrderClient<OrderDTO>(new HttpClient() { }, Configuration, Configuration["VTEX:Order:Path"], _logger));

                   // Add app
                   services.AddSingleton<ConsumerBackgroundService>();


                   //Unit of work
                   services.AddScoped<IUnitOfWorkProduccion,UnitOfWork>();
                   //Unit of work test
                   services.AddScoped<IUnitOfWorkTest,UnitOfWorkTest>();




                   
                   services.AddAutoMapper(configuration =>
                   {
                       configuration.CreateMap<Usr_Sttgsh, SpecificationGroupDTO>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Usr_Sttgsh_Idvtex))
                       .ForMember(dest => dest.CategoryId, opt => opt.MapFrom<MapperHelp.SpecificationsGroupResolver.IdCategoryResolver>())
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Usr_Sttgsh_Nombre))
                       .ForMember(dest => dest.Position, opt => opt.MapFrom(src => Convert.ToInt32(src.Usr_Sttgsh_Positi)));



                       configuration.CreateMap<Usr_Sttcaa, SpecificationDTO>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Usr_Sttcaa_Idvtex))
                       .ForMember(dest => dest.FieldTypeId, opt => opt.MapFrom(src => Convert.ToInt32(src.Usr_Sttcaa_Fieldt)))
                       .ForMember(dest => dest.CategoryId, opt => opt.MapFrom<MapperHelp.SpecificationsResolver.IdDepartmentResolver>())
                       .ForMember(dest => dest.FieldGroupId, opt => opt.MapFrom(src => src.Usr_Sttcaa_Grunam))
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Usr_Sttcaa_Nombre))
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

                       configuration.CreateMap<Usr_Sttcax, SpecificationDTO>()

                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Usr_Sttcax_Idvtex))
                       .ForMember(dest => dest.FieldTypeId, opt => opt.MapFrom(src => Convert.ToInt32(src.Usr_Sttcax_Fieldt)))
                       .ForMember(dest => dest.CategoryId, opt => opt.MapFrom<MapperHelp.SpecificationsResolver.IdCategoryResolver>())
                       .ForMember(dest => dest.FieldGroupId, opt => opt.MapFrom(src => src.Usr_Sttcax_Grunam))
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Usr_Sttcax_Nombre))
                       .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Usr_Sttcax_Descrp))
                       .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Usr_Sttcax_Positi))
                       .ForMember(dest => dest.IsFilter, opt => opt.MapFrom(src => src.Usr_Sttcax_Isfilt == "S"))
                       .ForMember(dest => dest.IsRequired, opt => opt.MapFrom(src => src.Usr_Sttcax_Isrequ == "S"))
                       .ForMember(dest => dest.IsOnProductDetails, opt => opt.MapFrom(src => src.Usr_Sttcax_Isonpr == "S"))
                       .ForMember(dest => dest.IsStockKeepingUnit, opt => opt.MapFrom(src => src.Usr_Sttcax_Isssku == "S"))
                       .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Usr_Sttcax_Isacti == "S"))
                       .ForMember(dest => dest.IsTopMenuLinkActive, opt => opt.MapFrom(src => src.Usr_Sttcax_Topmen == "S"))
                       .ForMember(dest => dest.IsSideMenuLinkActive, opt => opt.MapFrom(src => src.Usr_Sttcax_Sidmen == "S"))
                       .ForMember(dest => dest.DefaultValue, opt => opt.MapFrom(src => src.Usr_Sttcax_Defaul));

                       configuration.CreateMap<Usr_Sttcay, SpecificationDTO>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Usr_Sttcay_Idvtex))
                       .ForMember(dest => dest.FieldTypeId, opt => opt.MapFrom(src => Convert.ToInt32(src.Usr_Sttcay_Fieldt)))
                       .ForMember(dest => dest.CategoryId, opt => opt.MapFrom<MapperHelp.SpecificationsResolver.IdSubcategoryResolver>())
                       .ForMember(dest => dest.FieldGroupId, opt => opt.MapFrom(src => src.Usr_Sttcay_Grunam))
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Usr_Sttcay_Nombre))
                       .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Usr_Sttcay_Descrp))
                       .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Usr_Sttcay_Positi))
                       .ForMember(dest => dest.IsFilter, opt => opt.MapFrom(src => src.Usr_Sttcay_Isfilt == "S"))
                       .ForMember(dest => dest.IsRequired, opt => opt.MapFrom(src => src.Usr_Sttcay_Isrequ == "S"))
                       .ForMember(dest => dest.IsOnProductDetails, opt => opt.MapFrom(src => src.Usr_Sttcay_Isonpr == "S"))
                       .ForMember(dest => dest.IsStockKeepingUnit, opt => opt.MapFrom(src => src.Usr_Sttcay_Isssku == "S"))
                       .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Usr_Sttcay_Isacti == "S"))
                       .ForMember(dest => dest.IsTopMenuLinkActive, opt => opt.MapFrom(src => src.Usr_Sttcay_Topmen == "S"))
                       .ForMember(dest => dest.IsSideMenuLinkActive, opt => opt.MapFrom(src => src.Usr_Sttcay_Sidmen == "S"))
                       .ForMember(dest => dest.DefaultValue, opt => opt.MapFrom(src => src.Usr_Sttcay_Defaul));


                       configuration.CreateMap<Usr_Sttcah, CategoryDTO>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Convert.ToInt32(src.Usr_Sttcah_Deptos)))
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Usr_Sttcah_Descrp))
                       .ForMember(dest => dest.Keywords, opt => opt.MapFrom(src => src.Usr_Sttcah_Keywor))
                       .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Usr_Sttcah_Descrp))
                       .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Usr_Sttcah_Descri))
                       .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Usr_St_Debaja == "N"))
                       .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Usr_Sttcah_Scores));

                       configuration.CreateMap<Usr_Sttcai, CategoryDTO>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom<MapperHelp.CategorysResolver.IdCategoryResolver>())
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Usr_Sttcai_Descrp))
                       .ForMember(dest => dest.Keywords, opt => opt.MapFrom(src => src.Usr_Sttcai_Keywor))
                       .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Usr_Sttcai_Descrp))
                       .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Usr_Sttcai_Descri))
                       .ForMember(dest => dest.FatherCategoryId, opt => opt.MapFrom(src => Convert.ToInt32(src.Usr_Sttcai_Deptos).ToString()))
                       .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Usr_Sttcai_Isacti == "S"))
                       .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Usr_Sttcai_Scores));

                       configuration.CreateMap<Usr_Sttcas, CategoryDTO>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom<MapperHelp.CategorysResolver.IdSubcategoryResolver>())
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Usr_Sttcas_Descrp))
                       .ForMember(dest => dest.Keywords, opt => opt.MapFrom(src => src.Usr_Sttcas_Keywor))
                       .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Usr_Sttcas_Descrp))
                       .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Usr_Sttcas_Descri))
                       .ForMember(dest => dest.FatherCategoryId, opt => opt.MapFrom<FatherSubcategoryIdResolver>())
                       .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Usr_Sttcas_Isacti == "S"))
                       .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Usr_Sttcas_Scores));

                       configuration.CreateMap<Usr_Sttmah, BrandDTO>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Usr_Sttmah_Codigo))
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Usr_Sttmah_Descrp))
                       .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Usr_Sttmah_Textos))
                       .ForMember(dest => dest.Keywords, opt => opt.MapFrom(src => src.Usr_Sttmah_Keywor))
                       .ForMember(dest => dest.SiteTitle, opt => opt.MapFrom(src => src.Usr_Sttmah_Sittit))
                       .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Usr_St_Debaja == "N"))
                       .ForMember(dest => dest.MenuHome, opt => opt.MapFrom(src => src.Usr_Sttmah_Menhom == "S"))
                       .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Usr_Sttmah_Scores))
                       .ForMember(dest => dest.LinkId, opt => opt.MapFrom(src => src.Usr_Sttmah_Descrp.Replace(' ', '-')));


                       configuration.CreateMap<Stmpdh, SkuDTO>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Usr_Stmpdh_IdSKUvtex))
                       .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => Convert.ToInt32(src.Usr_Stmpdh_Father)))
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Stmpdh_Descrp))
                       .ForMember(dest => dest.RefId, opt => opt.MapFrom(src => src.Stmpdh_Indcod))
                       .ForMember(dest => dest.IsKit, opt => opt.MapFrom(src => src.Stmpdh_Kitsfc == "S"))
                       .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Usr_Vtex_Isacti == "S"))
                       .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.PackagedHeight))
                       .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.PackagedWeightKg))
                       .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.PackagedWidth))
                       .ForMember(dest => dest.WeightKg, opt => opt.MapFrom(src => src.PackagedWeightKg))
                       .ForMember(dest => dest.ActivateIfPossible, opt => opt.MapFrom(src => src.ActivateIfPossible=="S"));
                       //.ForMember(dest => dest.MeasurementUnit, opt => opt.MapFrom(src => src.Stmpdh_Unimed));

                       configuration.CreateMap<Stmpdh, ProductDTO>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Usr_Stmpdh_Idvtex))
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Stmpdh_Descrp))
                       .ForMember(dest => dest.CategoryId, opt => opt.MapFrom<MapperHelp.ProductsSKUResolver.IdCategoryVTEXResolver>())
                       .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Usr_Stmpdh_Marcas))
                       .ForMember(dest => dest.LinkId, opt => opt.MapFrom(src => src.Stmpdh_Descrp.Replace(' ', '-')))
                       .ForMember(dest => dest.RefId, opt => opt.MapFrom(src => src.Stmpdh_Indcod))
                       .ForMember(dest => dest.IsVisible, opt => opt.MapFrom(src => src.Usr_Stmpdh_Intnet == "S"))
                       .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Stmpdh_Descrp))
                       .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.Stmpdh_Fecalt))
                       .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Stmpdh_Descrp))
                       .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Stmpdh_Debaja == "N"))
                       .ForMember(dest => dest.KeyWords, opt => opt.MapFrom(src => src.Usr_Stmpdh_Keywor));

                       configuration.CreateMap<Usr_Stmpph, ProductDTO>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Usr_Stmpph_Idvtex))
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Usr_Stmpph_Descrp))
                       .ForMember(dest => dest.CategoryId, opt => opt.MapFrom<MapperHelp.ProductsFatherResolver.IdCategoryVTEXResolver>())
                       .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Usr_Stmpph_Marcas))
                       .ForMember(dest => dest.LinkId, opt => opt.MapFrom(src => src.Usr_Stmpph_Descrp.Replace(' ', '-')))
                       .ForMember(dest => dest.RefId, opt => opt.MapFrom(src => src.Usr_Stmpph_Indcod))
                       .ForMember(dest => dest.IsVisible, opt => opt.MapFrom(src => src.Usr_Stmpph_Intnet == "S"))
                       .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Usr_Stmpph_Descrp))
                       .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.Usr_St_Fecalt))
                       .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Usr_Stmpph_Descrp))
                       .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Usr_St_Debaja == "N"))
                       .ForMember(dest => dest.Stmpdh_Oalias, opt => opt.MapFrom(src => src.Usr_St_Oalias));

                       configuration.CreateMap<Usr_Sttvai, SpecificationValueDTO>()
                       .ForMember(dest => dest.FieldValueId, opt => opt.MapFrom(src => src.Usr_Sttvai_Idvtex))
                       .ForMember(dest => dest.FieldId, opt => opt.MapFrom(src => src.Usr_Sttvai_Fielid))
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Usr_Sttvai_Valor))
                       .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Usr_Sttvai_Textos))
                       .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Usr_St_Debaja == "N"))
                       .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Usr_Sttvai_Positi));

                       configuration.CreateMap<Usr_Pratri, ProductSpecificationDTO>()
                       //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Usr_Pratri_Idvtex))
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Usr_Pratri_Campo))
                       .ForMember(dest => dest.Value, opt => opt.MapFrom<MapperHelp.ProductSpecificationsValuesResolver.ProductSpecificationsValuesResolver>())
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Usr_Pratri_Textos));


                       configuration.CreateMap<Usr_Pratri, SKUSpecificationDTO>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Usr_Pratri_Idvtex))
                       .ForMember(dest => dest.FieldId, opt => opt.MapFrom(src => src.Usr_Pratri_Campo))
                       .ForMember(dest => dest.FieldValueId, opt => opt.MapFrom(src => src.Usr_Pratri_Valor))
                       .ForMember(dest => dest.SKUId, opt => opt.MapFrom(src => src.ProductId));

                       configuration.CreateMap<Usr_Stmppa, ProductSpecificationDTO>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Usr_Stmppa_Campo))
                       .ForMember(dest => dest.Value, opt => opt.MapFrom<MapperHelp.ProductFatherSpecificationsValuesResolver.ProductFatherSpecificationsValuesResolver>())
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Usr_Stmppa_Textos));

                       configuration.CreateMap<Usr_Stimpr, SKUFileDTO>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Usr_Stimpr_Idvtex))
                       .ForMember(dest => dest.IsMain, opt => opt.MapFrom(src => src.Usr_Stimpr_Orden == 1))
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Usr_Stimpr_Name))
                       .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Usr_Stimpr_Imgdps));

                       configuration.CreateMap<Usr_Prmoto, MotosDocumentDTO>()
                       .ForMember(dest => dest.idERP, opt => opt.MapFrom(src => src.Usr_Prmoto_Idmoto))
                       .ForMember(dest => dest.marca, opt => opt.MapFrom(src => src.Usr_Prmoto_Marca))
                       .ForMember(dest => dest.modelo, opt => opt.MapFrom(src => src.Usr_Prmoto_Modelo))
                       .ForMember(dest => dest.cilindrada, opt => opt.MapFrom(src => src.Usr_Prmoto_Cilind))
                       .ForMember(dest => dest.version, opt => opt.MapFrom(src => src.Usr_Prmoto_Version))
                       .ForMember(dest => dest.anios, opt => opt.MapFrom<MapperHelp.MotosResolver.AniosResolver>())
                       .ForMember(dest => dest.DocumentId, opt => opt.MapFrom(src => src.Usr_Prmoto_Idvtex));

                       configuration.CreateMap<FeedDTO, Usr_Vtexha>()
                       .ForMember(dest => dest.Usr_Vtexha_Ordid, opt => opt.MapFrom(src => src.OrderId));
                   }
                       , typeof(Program));

                   services.AddHostedService<ConsumerBackgroundService>();


               });
            //ConfigureServices(services);

            //// Create service provider
            //Log.Information("Building service provider");
            //IServiceProvider serviceProvider = services.BuildServiceProvider();

            // Print connection string to demonstrate configuration object is populated
            //Console.WriteLine(Configuration.GetConnectionString("DataConnection"));

            //try
            //{

            //    Log.Information("Comenzando servicio de categorias");
            //    await serviceProvider.GetService<ConsumerBackgroundService>().RunAsync(new CancellationTokenSource()
            //                                                                                .Token);
            //    Log.Information("Terminando servicio de categorias");
            //}

            //catch (Exception ex)
            //{
            //    Log.Fatal(ex, "Error running service");
            //    throw ex;
            //}
            //finally
            //{
            //    Log.CloseAndFlush();
            //}
        }

        //private static void ConfigureServices(Iservices services)
        //{
            
        //}
    }
}
