using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Model.Infrastructure;
using ViewState.ProcessScheduler.Model.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IResourceGroupService
    {
        IEnumerable<ResourceGroup> GetAll();
        ResourceGroup GetById(Guid id);
        void CreateEntity(ResourceGroup data);
        void SaveEntity();
    }

    public class ResourceGroupService : IResourceGroupService
    {
        private readonly IResourceGroupRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ResourceGroupService(IResourceGroupRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ResourceGroup> GetAll() => _repository.GetAll();

        public ResourceGroup GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(ResourceGroup data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
