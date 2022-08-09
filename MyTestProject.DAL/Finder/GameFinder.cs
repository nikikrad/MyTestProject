using Microsoft.EntityFrameworkCore;
using MyTestProject.BLL.Entities;
using MyTestProject.BLL.Finder;

namespace MyTestProject.DAL.Finder
{
    public class GameFinder : IGameFinder
    {
        private StoreContext db;
        public GameFinder(StoreContext context)
        {
            db = context;
        }

        async Task<IEnumerable<Game>> IGameFinder.GetData()
        {
            return await db.Games.ToListAsync();
        }
    }
}
