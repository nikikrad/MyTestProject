using MyTestProject.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestProject.BLL.Services.Interfaces
{
    public interface IPCService
    {
        public Task<List<PC>> Get();
        public Task Create(PC entity);
        public Task Delete(PC entity);
        public Task Update(PC entity);
    }
}
