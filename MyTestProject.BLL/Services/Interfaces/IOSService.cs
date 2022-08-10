using MyTestProject.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestProject.BLL.Services.Interfaces
{
    public interface IOSService
    {
        public Task<List<OS>> Get();
        public Task Create(OS entity);
        public Task Delete(OS entity);
        public Task Update(OS entity);
        public Task<OS?> GetById(int id);
    }
}
