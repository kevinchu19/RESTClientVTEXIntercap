using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentSpecificationsRepository DepartmentsSpecifications { get; }
        IDepartmentsRepository Departments { get; }
        ICategorysRepository Categorys { get; }
        ISubcategorysRepository Subcategorys { get; }
        IBrandsRepository Brands { get; }
        ICategorySpecificationsRepository CategorySpecifications { get; }
        IProductsFatherRepository ProductsFather { get; }
        IProductsSKURepository ProductsSKU { get; }
        ISpecificationsGroupRepository SpecificationsGroup { get; }
        ISpecificationsGroupRealRepository SpecificationsGroupReal { get; }
        ISubcategorySpecificationsRepository SubcategorySpecifications { get; }
        IProductsFatherRealRepository ProductsFatherReal { get; }
        IProductsSKURealRepository ProductsSKUReal { get; }
        IDepartmentSpecificationsRealRepository DepartmentsSpecificationsReal { get; }
        ICategorySpecificationsRealRepository CategorySpecificationsReal { get; }
        ISubcategorySpecificationsRealRepository SubcategorySpecificationsReal { get; }
        ISpecificationValueRepository SpecificationValues{ get; }
        ISpecificationValueRealRepository SpecificationValuesReal { get; }
        IProductsAndSKUSpecificationsRepository ProductsAndSKUSpecifications { get; }
        IProductsAndSKUSpecificationsRealRepository ProductsAndSKUSpecificationsReal { get; }
        IProductsFatherSpecificationsRealRepository ProductsFatherSpecificationsReal { get; }
        IProductsFatherSpecificationsRepository ProductsFatherSpecifications { get; }
        ISKUFilesRepository SKUFiles { get; }
        ISKUFilesRealRepository SKUFilesReal{ get; }
        Task<int> Complete();

    }
}
