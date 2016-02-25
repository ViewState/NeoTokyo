using AutoMapper;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;
using ViewState.ProcessScheduler.ViewModels;

namespace ViewState.ProcessScheduler.Services
{
    public class AddressService : ServiceBase<Address, AddressViewModel>, IService<Address, AddressViewModel>
    {
        public AddressService(IAddressRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, repository, mapper)
        {
        }

        public void Update(AddressViewModel data)
        {
            var target = Repository.GetById(data.ID);

            target.Active = data.Active;
            target.AddressLine1 = data.AddressLine1;
            target.AddressLine2 = data.AddressLine2;
            target.AddressName = data.AddressName;
            target.CountryID = data.CountryID;
            target.County = data.County;
            target.PostCode = data.PostCode;
            target.Town = data.Town;

            Repository.Update(target);
        }
    }
}
