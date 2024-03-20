using Epsilon.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Epsilon.Server.Repositories
{
    public class EpsilonDbContext : DbContext
    {
        public EpsilonDbContext(DbContextOptions<EpsilonDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
