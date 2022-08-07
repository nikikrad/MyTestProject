using Microsoft.EntityFrameworkCore;
using MyTestProject.BLL.Entities;

namespace MyTestProject.DAL
{
    public class StoreContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PC> PCs { get; set; }
        public DbSet<OS> OSs { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {

        }
    }
}
