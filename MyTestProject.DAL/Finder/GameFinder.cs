using Microsoft.EntityFrameworkCore;
using MyTestProject.BLL.Entities;
using MyTestProject.BLL.Finder;

namespace MyTestProject.DAL.Finder
{
    public class GameFinder : IGameFinder
    {
        private readonly DbSet<Game> _games;

        public GameFinder(DbSet<Game> games)
        {
            _games = games;
        }

        protected IQueryable<Game> AsQueryable()
        {
            return _games.AsQueryable();
        }

        public Task<List<Game>> Get(bool includePlayers = false)
        {
            var res = AsQueryable();
            res = includePlayers
                ? res.Include(t => t.Players)
                : res;
            return res.ToListAsync();
        }

        public Task<Game?> GetById(int id)
        {
           return AsQueryable().FirstOrDefaultAsync(p => p.Id == id);
        }
        public Task<List<Game>> GetAllFreeGames()
        {
            return AsQueryable().Where(p => p.Price == 0).ToListAsync();
        }

        public Task<List<Game>> GetGamesForPrice(int price)
        {
            return AsQueryable().Where(p => p.Price >= price).ToListAsync();
        }
    }
}
