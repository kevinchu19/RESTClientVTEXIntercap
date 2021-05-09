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
        private IDepartmentSpecificationsRepository _departmentSpecifications { get; set; }
        public IDepartmentsRepository _department { get; set; }
        public ICategorysRepository _categorys { get; set; }
        public ISubcategorysRepository _subcategorys { get; set; }
        public IBrandsRepository _brands { get; set; }
        public ICategorySpecificationsRepository _categorySpecifications { get; set; }
        public IProductsFatherRepository _productsFather { get; set; }
        public IProductsSKURepository _productsSKU { get; set; }
        public ISpecificationsGroupRepository _specificationsGroup { get; set; }
        public ISubcategorySpecificationsRepository _subcategorySpecifications { get; set; }
        public ISpecificationsGroupRealRepository _specificationsGroupReal { get; set; }
        public IProductsFatherRealRepository _productsFatherReal { get; set; }
        public IProductsSKURealRepository _productsSKUReal { get; set; }
        public IDepartmentSpecificationsRealRepository _departmentsSpecificationsReal { get; set; }
        public ICategorySpecificationsRealRepository _categorySpecificationsReal { get; set; }
        public ISubcategorySpecificationsRealRepository _subcategorySpecificationsReal { get; set; }
        public ISpecificationValueRepository _specificationValues { get; set; }
        public ISpecificationValueRealRepository _specificationValuesReal { get; set; }
        public IProductsAndSKUSpecificationsRepository _productsAndSKUSpecifications { get; set; }
        public IProductsAndSKUSpecificationsRealRepository _productsAndSKUSpecificationsReal { get; set; }
        public IProductsFatherSpecificationsRealRepository _productsFatherSpecificationsReal { get; set; }
        public IProductsFatherSpecificationsRepository _productsFatherSpecifications { get; set; }
        public ISKUFilesRepository _SKUFiles { get; set; }
        public ISKUFilesRealRepository _SKUFilesReal { get; set; }
        public UnitOfWork(ApiIntercapContext context)
        {
            Context = context;
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
                    _productsSKU = new ProductsSKURepository(Context);
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
