using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface ICustomerOrderLineService
    {
        IEnumerable<CustomerOrderLine> GetAll();
        CustomerOrderLine GetById(Guid id);
        void CreateEntity(CustomerOrderLine data);
        void SaveEntity();
    }

    public class CustomerOrderLineService : ICustomerOrderLineService
    {
        private readonly ICustomerOrderLineRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerOrderLineService(ICustomerOrderLineRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CustomerOrderLine> GetAll() => _repository.GetAll();

        public CustomerOrderLine GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(CustomerOrderLine data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
