using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface ICustomerContactMethodLinkService
    {
        IEnumerable<CustomerContactMethodLink> GetAll();
        CustomerContactMethodLink GetById(Guid id);
        void CreateEntity(CustomerContactMethodLink data);
        void SaveEntity();
    }

    public class CustomerContactMethodLinkService : ICustomerContactMethodLinkService
    {
        private readonly ICustomerContactMethodLinkRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerContactMethodLinkService(ICustomerContactMethodLinkRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CustomerContactMethodLink> GetAll() => _repository.GetAll();

        public CustomerContactMethodLink GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(CustomerContactMethodLink data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
