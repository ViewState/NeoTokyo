using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface ICustomerOrderLineStatusHistoryService
    {
        IEnumerable<CustomerOrderLineStatusHistory> GetAll();
        CustomerOrderLineStatusHistory GetById(Guid id);
        void CreateEntity(CustomerOrderLineStatusHistory data);
        void SaveEntity();
    }

    public class CustomerOrderLineStatusHistoryService : ICustomerOrderLineStatusHistoryService
    {
        private readonly ICustomerOrderLineStatusHistoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerOrderLineStatusHistoryService(ICustomerOrderLineStatusHistoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CustomerOrderLineStatusHistory> GetAll() => _repository.GetAll();

        public CustomerOrderLineStatusHistory GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(CustomerOrderLineStatusHistory data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
