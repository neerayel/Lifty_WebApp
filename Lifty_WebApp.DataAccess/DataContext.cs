using Lifty_WebApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lifty_WebApp.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Servicing> Servicings { get; set; }


        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
    }
}
