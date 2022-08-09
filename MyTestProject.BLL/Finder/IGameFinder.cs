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
        Task<IEnumerable<Game>> GetData();
    }
}
