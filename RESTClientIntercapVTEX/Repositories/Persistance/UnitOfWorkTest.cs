using Microsoft.Extensions.Configuration;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Entities.Test;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Repositories.Persistance
{
    public class UnitOfWorkTest: IUnitOfWorkTest
    {
        public ApiIntercapTestContext Context { get; }
        public IConfigurationRoot Configuration { get; }
        private IOrderHandlerRepository _OrderHandlerRepository { get; set; }
        private IOrderHeaderRepository _OrderHeaderRepository { get; set; }
        private IOrderItemsRepository _OrderItemsRepository { get; set; }
        private IOrderPaymentsRepository _OrderPaymentsRepository { get; set; }
        private IOrderVtexRepository _OrderVtexRepository { get; set; }
        private IOrderContactsRepository _OrderContactsRepository { get; set; }
        private IOrderShippingRepository _OrderShippingRepository { get; set; }
        public UnitOfWorkTest(ApiIntercapTestContext context, IConfigurationRoot configuration)
        {
            Context = context;
            Configuration = configuration;
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

        public IOrderVtexRepository OrderVtexRepository
        {
            get
            {
                if (_OrderVtexRepository == null)
                {
                    _OrderVtexRepository = new OrderVtexRepository(Context);
                }
                return _OrderVtexRepository;
            }
        }

        public IOrderContactsRepository OrderContactsRepository
        {
            get
            {
                if (_OrderContactsRepository == null)
                {
                    _OrderContactsRepository = new OrderContactsRepository(Context);
                }
                return _OrderContactsRepository;
            }
        }

        public IOrderShippingRepository OrderShippingRepository
        {
            get
            {
                if (_OrderShippingRepository == null)
                {
                    _OrderShippingRepository = new OrderShippingRepository(Context);
                }
                return _OrderShippingRepository;
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

        public IDepartmentSpecificationsRepository DepartmentsSpecifications => throw new NotImplementedException();

        public IDepartmentsRepository Departments => throw new NotImplementedException();

        public ICategorysRepository Categorys => throw new NotImplementedException();

        public ISubcategorysRepository Subcategorys => throw new NotImplementedException();

        public IBrandsRepository Brands => throw new NotImplementedException();

        public ICategorySpecificationsRepository CategorySpecifications => throw new NotImplementedException();

        public IProductsFatherRepository ProductsFather => throw new NotImplementedException();

        public IProductsSKURepository ProductsSKU => throw new NotImplementedException();

        public ISpecificationsGroupRepository SpecificationsGroup => throw new NotImplementedException();

        public ISpecificationsGroupRealRepository SpecificationsGroupReal => throw new NotImplementedException();

        public ISubcategorySpecificationsRepository SubcategorySpecifications => throw new NotImplementedException();

        public IProductsFatherRealRepository ProductsFatherReal => throw new NotImplementedException();

        public IProductsSKURealRepository ProductsSKUReal => throw new NotImplementedException();

        public IDepartmentSpecificationsRealRepository DepartmentsSpecificationsReal => throw new NotImplementedException();

        public ICategorySpecificationsRealRepository CategorySpecificationsReal => throw new NotImplementedException();

        public ISubcategorySpecificationsRealRepository SubcategorySpecificationsReal => throw new NotImplementedException();

        public ISpecificationValueRepository SpecificationValues => throw new NotImplementedException();

        public ISpecificationValueRealRepository SpecificationValuesReal => throw new NotImplementedException();

        public IProductsAndSKUSpecificationsRepository ProductsAndSKUSpecifications => throw new NotImplementedException();

        public IProductsAndSKUSpecificationsRealRepository ProductsAndSKUSpecificationsReal => throw new NotImplementedException();

        public IProductsFatherSpecificationsRealRepository ProductsFatherSpecificationsReal => throw new NotImplementedException();

        public IProductsFatherSpecificationsRepository ProductsFatherSpecifications => throw new NotImplementedException();

        public ISKUFilesRepository SKUFiles => throw new NotImplementedException();

        public ISKUFilesRealRepository SKUFilesReal => throw new NotImplementedException();

        public IMotosRepository Motos => throw new NotImplementedException();

        public IMotosRealRepository MotosReal => throw new NotImplementedException();

        public IProductsFatherMotoSpecificationsRepository ProductsFatherMotoSpecifications => throw new NotImplementedException();

        public IProductsFatherMotoSpecificationsRealRepository ProductsFatherMotoSpecificationsReal => throw new NotImplementedException();

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
