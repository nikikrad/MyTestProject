using Microsoft.EntityFrameworkCore;
using MyTestProject.BLL.Entities;
using MyTestProject.BLL.Finder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestProject.DAL.Finder
{
    public class PCFinder: IPCFinder
    {
        private readonly DbSet<PC> _pc;
        public PCFinder(DbSet<PC> pc)
        {
            _pc = pc;
        }

        private IQueryable<PC> AsQueryable()
        {
            return _pc.AsQueryable();
        }

        public Task<List<PC>> Get()
        {
            return AsQueryable().ToListAsync();
        }

        public Task<PC?> GetById(int id)
        {
            return AsQueryable().FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
