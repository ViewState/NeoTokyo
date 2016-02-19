using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface ICountryService
    {
        IEnumerable<Country> GetAll();
        Country GetById(Guid id);
        void CreateEntity(Country data);
        void SaveEntity();
    }

    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CountryService(ICountryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Country> GetAll() => _repository.GetAll();

        public Country GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(Country data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
