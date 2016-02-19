using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface ICustomerOrderStatuService
    {
        IEnumerable<CustomerOrderStatu> GetAll();
        CustomerOrderStatu GetById(Guid id);
        void CreateEntity(CustomerOrderStatu data);
        void SaveEntity();
    }

    public class CustomerOrderStatuService : ICustomerOrderStatuService
    {
        private readonly ICustomerOrderStatuRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerOrderStatuService(ICustomerOrderStatuRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CustomerOrderStatu> GetAll() => _repository.GetAll();

        public CustomerOrderStatu GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(CustomerOrderStatu data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
