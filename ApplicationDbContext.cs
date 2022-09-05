using Microsoft.EntityFrameworkCore;
using webApi.controllers.Entidades;

namespace webapi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AutorBase> Autores { get; set; }
    }
}
