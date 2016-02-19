using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface ICustomerOrderLineStatuService
    {
        IEnumerable<CustomerOrderLineStatu> GetAll();
        CustomerOrderLineStatu GetById(Guid id);
        void CreateEntity(CustomerOrderLineStatu data);
        void SaveEntity();
    }

    public class CustomerOrderLineStatuService : ICustomerOrderLineStatuService
    {
        private readonly ICustomerOrderLineStatuRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerOrderLineStatuService(ICustomerOrderLineStatuRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CustomerOrderLineStatu> GetAll() => _repository.GetAll();

        public CustomerOrderLineStatu GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(CustomerOrderLineStatu data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
