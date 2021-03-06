﻿using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IContactTypeService
    {
        IEnumerable<ContactType> GetAll();
        ContactType GetById(Guid id);
        void CreateEntity(ContactType data);
        void SaveEntity();
    }

    public class ContactTypeService : IContactTypeService
    {
        private readonly IContactTypeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ContactTypeService(IContactTypeRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ContactType> GetAll() => _repository.GetAll();

        public ContactType GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(ContactType data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
