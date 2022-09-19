using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapi.Controllers.Entidades;
using webApi.controllers.Entidades;

namespace webapi
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AutorBase> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
    }
}
