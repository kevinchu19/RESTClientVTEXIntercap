using Microsoft.Extensions.Configuration;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Persistance
{
    public class UnitOfWork: IUnitOfWork
    {
        public ApiIntercapContext Context { get; }
        public IConfigurationRoot Configuration { get; }
        private IDepartmentSpecificationsRepository _departmentSpecifications { get; set; }
        private IDepartmentsRepository _department { get; set; }
        private ICategorysRepository _categorys { get; set; }
        private ISubcategorysRepository _subcategorys { get; set; }
        private IBrandsRepository _brands { get; set; }
        private ICategorySpecificationsRepository _categorySpecifications { get; set; }
        private IProductsFatherRepository _productsFather { get; set; }
        private IProductsSKURepository _productsSKU { get; set; }
        private ISpecificationsGroupRepository _specificationsGroup { get; set; }
        private ISubcategorySpecificationsRepository _subcategorySpecifications { get; set; }
        private ISpecificationsGroupRealRepository _specificationsGroupReal { get; set; }
        private IProductsFatherRealRepository _productsFatherReal { get; set; }
        private IProductsSKURealRepository _productsSKUReal { get; set; }
        private IDepartmentSpecificationsRealRepository _departmentsSpecificationsReal { get; set; }
        private ICategorySpecificationsRealRepository _categorySpecificationsReal { get; set; }
        private ISubcategorySpecificationsRealRepository _subcategorySpecificationsReal { get; set; }
        private ISpecificationValueRepository _specificationValues { get; set; }
        private ISpecificationValueRealRepository _specificationValuesReal { get; set; }
        private IProductsAndSKUSpecificationsRepository _productsAndSKUSpecifications { get; set; }
        private IProductsAndSKUSpecificationsRealRepository _productsAndSKUSpecificationsReal { get; set; }
        private IProductsFatherSpecificationsRealRepository _productsFatherSpecificationsReal { get; set; }
        private IProductsFatherMotoSpecificationsRepository _productsFatherMotoSpecifications { get; set; }
        private IProductsFatherMotoSpecificationsRealRepository _productsFatherMotoSpecificationsReal { get; set; }
        private IProductsFatherSpecificationsRepository _productsFatherSpecifications { get; set; }
        private ISKUFilesRepository _SKUFiles { get; set; }
        private ISKUFilesRealRepository _SKUFilesReal { get; set; }
        private IMotosRepository _Motos { get; set; }
        private IMotosRealRepository _MotosReal { get; set; }
        private IOrderHandlerRepository _OrderHandlerRepository { get; set; }
        private IOrderHeaderRepository _OrderHeaderRepository { get; set; }
        private IOrderItemsRepository _OrderItemsRepository { get; set; }
        private IOrderPaymentsRepository _OrderPaymentsRepository { get; set; }
        public UnitOfWork(ApiIntercapContext context, IConfigurationRoot configuration)
        {
            Context = context;
            Configuration = configuration;
        }

        public IDepartmentsRepository Departments
        {
            get
            {
                if (_department == null)
                {
                    _department = new DepartmentsRepository(Context);
                }
                return _department;
            }
        }

        public ICategorysRepository Categorys
        {
            get
            {
                if (_categorys == null)
                {
                    _categorys = new CategorysRepository(Context);
                }
                return _categorys;
            }
        }
        public ISubcategorysRepository Subcategorys
        {
            get
            {
                if (_subcategorys == null)
                {
                    _subcategorys = new SubcategorysRepository(Context);
                }
                return _subcategorys;
            }
        }
        public IDepartmentSpecificationsRepository DepartmentsSpecifications
        {
            get
            {
                if (_departmentSpecifications == null)
                {
                    _departmentSpecifications = new DepartmentSpecificationsRepository(Context);
                }
                return _departmentSpecifications;
            }
        }

        public IBrandsRepository Brands
        {
            get
            {
                if (_brands == null)
                {
                    _brands = new BrandsRepository(Context);
                }
                return _brands;
            }
        }

        public ICategorySpecificationsRepository CategorySpecifications
        {
            get
            {
                if (_categorySpecifications == null)
                {
                    _categorySpecifications = new CategorySpecificationsRepository(Context);
                }
                return _categorySpecifications;
            }
        }

        public IProductsFatherRepository ProductsFather
        {
            get
            {
                if (_productsFather == null)
                {
                    _productsFather = new ProductsFatherRepository(Context);
                }
                return _productsFather;
            }
        }

        public IProductsSKURepository ProductsSKU
        {
            get
            {
                if (_productsSKU == null)
                {
                    _productsSKU = new ProductsSKURepository(Context, Configuration);
                }
                return _productsSKU;
            }
        }

        public ISpecificationsGroupRepository SpecificationsGroup
        {
            get
            {
                if (_specificationsGroup == null)
                {
                    _specificationsGroup = new SpecificationsGroupRepository(Context);
                }
                return _specificationsGroup;
            }
        }
        public ISpecificationsGroupRealRepository SpecificationsGroupReal
        {
            get
            {
                if (_specificationsGroupReal == null)
                {
                    _specificationsGroupReal = new SpecificationsGroupRealRepository(Context);
                }
                return _specificationsGroupReal;
            }
        }

        public IProductsFatherRealRepository ProductsFatherReal
        {
            get
            {
                if (_productsFatherReal == null)
                {
                    _productsFatherReal = new ProductsFatherRealRepository(Context);
                }
                return _productsFatherReal;
            }
        }

        public IProductsSKURealRepository ProductsSKUReal
        {
            get
            {
                if (_productsSKUReal == null)
                {
                    _productsSKUReal = new ProductsSKURealRepository(Context);
                }
                return _productsSKUReal;
            }
        }

        public ISubcategorySpecificationsRepository SubcategorySpecifications
        {
            get
            {
                if (_subcategorySpecifications == null)
                {
                    _subcategorySpecifications = new SubcategorySpecificationsRepository(Context);
                }
                return _subcategorySpecifications;
            }
        }

        public IDepartmentSpecificationsRealRepository DepartmentsSpecificationsReal
        {
            get
            {
                if (_departmentsSpecificationsReal == null)
                {
                    _departmentsSpecificationsReal = new DepartmentSpecificationsRealRepository(Context);
                }
                return _departmentsSpecificationsReal;
            }
        }

        public ISubcategorySpecificationsRealRepository SubcategorySpecificationsReal
        {
            get
            {
                if (_subcategorySpecificationsReal == null)
                {
                    _subcategorySpecificationsReal = new SubcategorySpecificationsRealRepository(Context);
                }
                return _subcategorySpecificationsReal;
            }
        }

        public ICategorySpecificationsRealRepository CategorySpecificationsReal
        {
            get
            {
                if (_categorySpecificationsReal == null)
                {
                    _categorySpecificationsReal = new CategorySpecificationsRealRepository(Context);
                }
                return _categorySpecificationsReal;
            }
        }

        public ISpecificationValueRepository SpecificationValues
        {
            get
            {
                if (_specificationValues == null)
                {
                    _specificationValues = new SpecificationValuesRepository(Context);
                }
                return _specificationValues;
            }
        }

        public ISpecificationValueRealRepository SpecificationValuesReal
        {
            get
            {
                if (_specificationValuesReal == null)
                {
                    _specificationValuesReal = new SpecificationValuesRealRepository(Context);
                }
                return _specificationValuesReal;
            }
        }

        public IProductsAndSKUSpecificationsRepository ProductsAndSKUSpecifications
        {
            get
            {
                if (_productsAndSKUSpecifications == null)
                {
                    _productsAndSKUSpecifications = new ProductsAndSKUSpecificationsRepository(Context);
                }
                return _productsAndSKUSpecifications;
            }
        }

        public IProductsAndSKUSpecificationsRealRepository ProductsAndSKUSpecificationsReal
        {
            get
            {
                if (_productsAndSKUSpecificationsReal == null)
                {
                    _productsAndSKUSpecificationsReal = new ProductsAndSKUSpecificationsRealRepository(Context);
                }
                return _productsAndSKUSpecificationsReal;
            }
        }

        public IProductsFatherSpecificationsRealRepository ProductsFatherSpecificationsReal
        {
            get
            {
                if (_productsFatherSpecificationsReal == null)
                {
                    _productsFatherSpecificationsReal = new ProductsFatherSpecificationsRealRepository(Context);
                }
                return _productsFatherSpecificationsReal;
            }
        }


        public IProductsFatherMotoSpecificationsRepository ProductsFatherMotoSpecifications
        {
            get
            {
                if (_productsFatherMotoSpecifications == null)
                {
                    _productsFatherMotoSpecifications = new ProductsFatherMotoSpecificationsRepository(Context);
                }
                return _productsFatherMotoSpecifications;
            }
        }
        public IProductsFatherMotoSpecificationsRealRepository ProductsFatherMotoSpecificationsReal
        {
            get
            {
                if (_productsFatherMotoSpecificationsReal == null)
                {
                    _productsFatherMotoSpecificationsReal = new ProductsFatherMotoSpecificationsRealRepository(Context);
                }
                return _productsFatherMotoSpecificationsReal;
            }
        }


        public IProductsFatherSpecificationsRepository ProductsFatherSpecifications
        {
            get
            {
                if (_productsFatherSpecifications == null)
                {
                    _productsFatherSpecifications = new ProductsFatherSpecificationsRepository(Context);
                }
                return _productsFatherSpecifications;
            }
        }

        public ISKUFilesRepository SKUFiles
        {
            get
            {
                if (_SKUFiles == null)
                {
                    _SKUFiles = new SKUFilesRepository(Context);
                }
                return _SKUFiles;
            }
        }
        public ISKUFilesRealRepository SKUFilesReal
        {
            get
            {
                if (_SKUFilesReal == null)
                {
                    _SKUFilesReal = new SKUFilesRealRepository(Context);
                }
                return _SKUFilesReal;
            }
        }

        public IMotosRepository Motos
        {
            get
            {
                if (_Motos == null)
                {
                    _Motos = new MotosRepository(Context);
                }
                return _Motos;
            }
        }
        public IMotosRealRepository MotosReal
        {
            get
            {
                if (_MotosReal == null)
                {
                    _MotosReal = new MotosRealRepository(Context);
                }
                return _MotosReal;
            }
        }


        public IOrderHandlerRepository OrderHandlerRepository {
            get
            {
                if (_OrderHandlerRepository == null)
                {
                    _OrderHandlerRepository = new OrderHandlerRepository(Context);
                }
                return _OrderHandlerRepository;
            }
        }
        public IOrderHeaderRepository OrderHeaderRepository {
            get
            {
                if (_OrderHeaderRepository == null)
                {
                    _OrderHeaderRepository = new OrderHeaderRepository(Context);
                }
                return _OrderHeaderRepository;
            }
        }
        public IOrderItemsRepository OrderItemsRepository {
            get
            {
                if (_OrderItemsRepository == null)
                {
                    _OrderItemsRepository = new OrderItemsRepository(Context);
                }
                return _OrderItemsRepository;
            }
        }
        public IOrderPaymentsRepository OrderPaymentsRepository {
            get
            {
                if (_OrderPaymentsRepository == null)
                {
                    _OrderPaymentsRepository = new OrderPaymentsRepository(Context);
                }
                return _OrderPaymentsRepository;
            }
        }

        public async Task<int> Complete()
        {
            return await Context.SaveChangesAsync();
        }


        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
