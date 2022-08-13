using MyTestProject.BLL.Entities;


namespace MyTestProject.BLL.Services.Interfaces
{
    public interface IGameService
    {
        public Task<List<Game>> Get(bool includePlayers = false);
        public Task Create(Game entity);
        public Task Update(Game entity);
        public Task Delete(Game entity);
        public Task<Game?> GetById(int id); 
        public Task<List<Game>> GetAllFreeGames();
        public Task<List<Game>> GetGamesForPrice(int price);


    }
}
