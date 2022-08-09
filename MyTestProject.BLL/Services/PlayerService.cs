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
    public class PlayerService: IPlayerService
    {
        private readonly IRepository<Player> _repository;
        private readonly IPlayerFinder _playerFinder;
        private readonly IUnitOfWork _unitOfWork;
        public PlayerService(IRepository<Player> repository, IPlayerFinder playerFinder, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _playerFinder = playerFinder;
            _unitOfWork = unitOfWork;
        }        

        public Task<List<Player>> Get()
        {
            return _playerFinder.Get();
        }

        public Task Create(Player entity)
        {
            _repository.Create(entity);
            return _unitOfWork.SaveChanges();
        }

        public Task Delete(Player entity)
        {
            _repository.Delete(entity);
            return _unitOfWork.SaveChanges();
        }
        Task IPlayerService.Update(Player entity)
        {
            _repository.Update(entity);
            return _unitOfWork.SaveChanges();
        }
    }
}
