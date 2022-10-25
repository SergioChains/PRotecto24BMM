using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class ApplicationDbContext
    {
        public class ApllicationDbContext : DbContext
        {
            public ApllicationDbContext(DbContextOptions<ApllicationDbContext> options) : base(options)
            {

            }
            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Rol> roles { get; set; }

        }
    }
}
