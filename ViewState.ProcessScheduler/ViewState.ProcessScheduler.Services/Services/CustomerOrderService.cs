using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface ICustomerOrderService
    {
        IEnumerable<CustomerOrder> GetAll();
        CustomerOrder GetById(Guid id);
        void CreateEntity(CustomerOrder data);
        void SaveEntity();
    }

    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly ICustomerOrderRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerOrderService(ICustomerOrderRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CustomerOrder> GetAll() => _repository.GetAll();

        public CustomerOrder GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(CustomerOrder data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
