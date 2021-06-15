using AutoMapper;
using RESTClientIntercapVTEX.Client;
using RESTClientIntercapVTEX.Entities;
using RESTClientIntercapVTEX.Models;
using RESTClientIntercapVTEX.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESTClientIntercapVTEX.Services
{
    public class ServiceBase<TResource>
    {

        protected const int MAX_ELEMENTS_IN_QUEUE = 600;

        protected readonly ClientBase<TResource> _client;
        protected readonly IUnitOfWork _repository;
        protected readonly IMapper _mapper;

        public ServiceBase(ClientBase<TResource> client, IUnitOfWork repository, IMapper mapper)
        {
            _client = client;
            _repository = repository;
            _mapper = mapper;
        }        

    }

}
