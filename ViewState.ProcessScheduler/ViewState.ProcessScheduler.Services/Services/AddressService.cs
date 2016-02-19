using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IAddressService
    {
        IEnumerable<Address> GetAll();
        Address GetById(Guid id);
        void CreateEntity(Address data);
        void SaveEntity();
    }
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AddressService(IAddressRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Address> GetAll() => _repository.GetAll();

        public Address GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(Address data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
