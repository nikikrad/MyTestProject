using MyTestProject.BLL.Entities;

namespace MyTestProject.BLL.Services.Interfaces
{
    public interface IGameService
    {
        public Task Create(Game entity);
        public Task Update(Game entity);
        public Task Delete(Game entity);
    }
}
