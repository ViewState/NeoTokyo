using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IContactMethodService
    {
        IEnumerable<ContactMethod> GetAll();
        ContactMethod GetById(Guid id);
        void CreateEntity(ContactMethod data);
        void SaveEntity();
    }

    public class ContactMethodService : IContactMethodService
    {
        private readonly IContactMethodRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ContactMethodService(IContactMethodRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ContactMethod> GetAll() => _repository.GetAll();

        public ContactMethod GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(ContactMethod data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
