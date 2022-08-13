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
        private readonly IGameFinder _gameFinder;

        public GameService(IRepository<Game> gameRepository, IUnitOfWork unitOfWork, IGameFinder gameFinder)
        {
            _gameRepository = gameRepository;
            _unitOfWork = unitOfWork;
            _gameFinder = gameFinder;
        }
        public Task<List<Game>> Get(bool includePlayers = false)
        {
            return _gameFinder.Get(includePlayers: includePlayers);
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

        public Task<Game?> GetById(int id)
        {
            return _gameFinder.GetById(id);
        }

        public Task<List<Game>> GetAllFreeGames()
        {
            return _gameFinder.GetAllFreeGames();
        }

        public Task<List<Game>> GetGamesForPrice(int price)
        {
            return _gameFinder.GetGamesForPrice(price);
        }
    }
}
