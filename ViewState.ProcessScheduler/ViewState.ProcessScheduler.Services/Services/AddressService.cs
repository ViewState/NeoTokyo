using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IAddressService
    {
        //IEnumerable<Address> GetAll();
        //Address GetById(Guid id);
        //void CreateEntity(Address data);
        //void SaveEntity();
    }
    public class AddressService : ServiceBase<Address>, IAddressService
    {
        public AddressService(IAddressRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork, repository)
        {
        }

    }
}
