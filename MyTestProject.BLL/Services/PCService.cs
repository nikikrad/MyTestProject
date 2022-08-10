using MyTestProject.BLL.Entities;
using MyTestProject.BLL.Finder;
using MyTestProject.BLL.Repositories;
using MyTestProject.BLL.Services.Interfaces;
using MyTestProject.BLL.UnitOfWork;

namespace MyTestProject.BLL.Services
{
    public class PCService : IPCService
    {
        private readonly IPCFinder _pcFinder;
        private readonly IRepository<PC> _repository;
        private readonly IUnitOfWork _uniteOfWork;
        public PCService(IPCFinder pcFinder, IRepository<PC> repository, IUnitOfWork unitOfWork)
        {
            _pcFinder = pcFinder;
            _repository = repository;
            _uniteOfWork = unitOfWork;
        }
        public Task Create(PC entity)
        {
            _repository.Create(entity);
            return _uniteOfWork.SaveChanges();
        }

        public Task Delete(PC entity)
        {
            _repository.Delete(entity);
            return _uniteOfWork.SaveChanges();
        }

        public Task<List<PC>> Get()
        {
            return _pcFinder.Get();
        }

        public Task<PC?> GetById(int id)
        {
            return _pcFinder.GetById(id);
        }

        public Task Update(PC entity)
        {
            _repository.Update(entity);
            return _uniteOfWork.SaveChanges();
        }
    }
}
