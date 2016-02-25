using System;
using System.Collections.Generic;
using ViewState.ProcessScheduler.Entities;
using ViewState.ProcessScheduler.Interfaces;
using ViewState.ProcessScheduler.Repositories;

namespace ViewState.ProcessScheduler.Services
{
    public interface IStaffResourceGroupLinkService
    {
        IEnumerable<StaffResourceGroupLink> GetAll();
        StaffResourceGroupLink GetById(Guid id);
        void CreateEntity(StaffResourceGroupLink data);
        void SaveEntity();
    }

    public class StaffResourceGroupLinkService : IStaffResourceGroupLinkService
    {
        private readonly IStaffResourceGroupLinkRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public StaffResourceGroupLinkService(IStaffResourceGroupLinkRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<StaffResourceGroupLink> GetAll() => _repository.GetAll();

        public StaffResourceGroupLink GetById(Guid id) => _repository.GetById(id);

        public void CreateEntity(StaffResourceGroupLink data) => _repository.Add(data);

        public void SaveEntity() => _unitOfWork.Commit();
    }
}
