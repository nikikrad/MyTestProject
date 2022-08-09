using MyTestProject.BLL.Entities;
using MyTestProject.BLL.Finder;
using MyTestProject.BLL.Repositories;
using MyTestProject.BLL.Services.Interfaces;
using MyTestProject.BLL.UnitOfWork;

namespace MyTestProject.BLL.Services
{
    public class GameService : IGameService
    {
        private readonly IRepository<Game> _gameRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Finder.IGameFinder _finder;

        public GameService(IRepository<Game> gameRepository, IUnitOfWork unitOfWork, Finder.IGameFinder finder)
        {
            _gameRepository = gameRepository;
            _unitOfWork = unitOfWork;
            _finder = finder;
        }
        public Task<IEnumerable<Game>> Get()
        {
            return _finder.GetData();
        }

        public Task Create(Game entity)
        {
            _gameRepository.Create(entity);
            return _unitOfWork.SaveChanges();
        }

        public Task Delete(Game entity)
        {
            _gameRepository.Delete(entity);
            return _unitOfWork.SaveChanges();
        }

        public Task Update(Game entity)
        {
            _gameRepository.Update(entity);
            return _unitOfWork.SaveChanges();
        }
    }
}
