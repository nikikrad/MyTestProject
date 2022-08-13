using MyTestProject.BLL.Entities;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestProject.BLL.Finder
{
    public interface IGameFinder
    {
        public Task<List<Game>> Get(bool includePlayers = false);
        public Task<Game?> GetById(int id);
        public Task<List<Game>> GetAllFreeGames();
        public Task<List<Game>> GetGamesForPrice(int price);
    }
}
