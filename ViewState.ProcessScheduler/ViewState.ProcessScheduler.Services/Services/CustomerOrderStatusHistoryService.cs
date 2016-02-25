using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface ICustomerOrderStatusHistoryService
    {
        IEnumerable<CustomerOrderStatusHistory> GetAll();
        CustomerOrderStatusHistory GetById(Guid id);
        void CreateEntity(CustomerOrderStatusHistory data);
        void SaveEntity();
    }

    public class CustomerOrderStatusHistoryService : ICustomerOrderStatusHistoryService
    {
        private readonly ICustomerOrderStatusHistoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerOrderStatusHistoryService(ICustomerOrderStatusHistoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CustomerOrderStatusHistory> GetAll() => _repository.GetAll();

        public CustomerOrderStatusHistory GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(CustomerOrderStatusHistory data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
