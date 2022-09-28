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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AutorLibro>() // esto es una configuracion especial de la entidad autorlibro
                .HasKey(al => new { al.AutorId, al.LibroId }); 
            //la entidad autorlibro va a tener una llave compuesta por Al
            //Lo que significa que esta creando un allave compuesta
        }

        public DbSet<AutorBase> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<AutorLibro> AutoresLibros { get; set; } //shshhshshs


    }
}
