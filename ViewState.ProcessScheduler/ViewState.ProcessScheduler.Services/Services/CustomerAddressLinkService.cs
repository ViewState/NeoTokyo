using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface ICustomerAddressLinkService
    {
        IEnumerable<CustomerAddressLink> GetAll();
        CustomerAddressLink GetById(Guid id);
        void CreateEntity(CustomerAddressLink data);
        void SaveEntity();
    }

    public class CustomerAddressLinkService : ICustomerAddressLinkService
    {
        private readonly ICustomerAddressLinkRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerAddressLinkService(ICustomerAddressLinkRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CustomerAddressLink> GetAll() => _repository.GetAll();

        public CustomerAddressLink GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(CustomerAddressLink data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
