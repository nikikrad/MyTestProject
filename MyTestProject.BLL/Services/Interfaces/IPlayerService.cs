using MyTestProject.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestProject.BLL.Services.Interfaces
{
    public interface IPlayerService
    {
        public Task<List<Player>> Get();
        public Task Create(Player entity);
        public Task Update(Player entity);
        public Task Delete(Player entity);
    }
}
