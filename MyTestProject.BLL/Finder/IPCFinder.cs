using MyTestProject.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestProject.BLL.Finder
{
    public interface IPCFinder
    {
        public Task<List<PC>> Get();
    }
}
