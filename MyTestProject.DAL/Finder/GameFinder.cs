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

        public Task<List<Game>> Get()
        {
            return AsQueryable().ToListAsync();
        }
    }
}
