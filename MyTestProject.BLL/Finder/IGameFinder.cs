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
        public Task<List<Game>> Get();
        public Task<Game?> GetById(int id);
    }
}
