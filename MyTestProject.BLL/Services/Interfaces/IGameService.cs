using MyTestProject.BLL.Entities;

namespace MyTestProject.BLL.Services.Interfaces
{
    public interface IGameService
    {
        public Task<List<Game>> Get();
        public Task Create(Game entity);
        public Task Update(Game entity);
        public Task Delete(Game entity);
        public Task<Game?> GetById(int id);
    }
}
