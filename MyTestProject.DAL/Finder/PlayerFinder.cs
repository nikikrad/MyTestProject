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
    public class PlayerFinder : IPlayerFinder
    {
        private readonly DbSet<Player> _players;
        public PlayerFinder(DbSet<Player> players)
        {
            _players = players;
        }

        private IQueryable<Player> AsQueryable()
        {
            return _players.AsQueryable();
        }
        public Task<List<Player>> Get()
        {
            return AsQueryable().ToListAsync();
        }
    }
}
