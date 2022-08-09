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
    public class OSFinder: IOSFinder
    {
        private readonly DbSet<OS> _os;
        public OSFinder(DbSet<OS> os)
        {
            _os = os;
        }
        private IQueryable<OS> AsQueryable()
        {
            return _os.AsQueryable();
        }
        public Task<List<OS>> Get()
        {
            return AsQueryable().ToListAsync();
        }
    }
}
