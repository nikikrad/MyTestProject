using MyTestProject.BLL.Entities;
using MyTestProject.BLL.Finder;
using MyTestProject.BLL.Repositories;
using MyTestProject.BLL.Services.Interfaces;
using MyTestProject.BLL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestProject.BLL.Services
{
    public class OSService:IOSService
    {
        private readonly IRepository<OS> _repository;
        private readonly IOSFinder _osFinder;
        private readonly IUnitOfWork _unitOfWork;
        public OSService(IRepository<OS> repository, IOSFinder osFinder, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _osFinder = osFinder;
            _unitOfWork = unitOfWork;
        }

        public Task Create(OS entity)
        {
            _repository.Create(entity);
            return _unitOfWork.SaveChanges();
        }

        public Task Delete(OS entity)
        {
            _repository.Delete(entity);
            return _unitOfWork.SaveChanges();
        }

        public Task<List<OS>> Get()
        {
            return _osFinder.Get();
        }

        public Task<OS?> GetById(int id)
        {
            return _osFinder.GetById(id);
        }

        public Task Update(OS entity)
        {
            _repository.Update(entity);
            return _unitOfWork.SaveChanges();
        }
    }
}
