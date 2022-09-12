using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Controllers.Entidades;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LibrosController(ApplicationDbContext context)   //creo uun construtor de la instancia dbcontext y lo inicializamos como un campo

        {
            this.context = context;
        }
        [HttpGet("{id:int}")]   //Encerrando entre llaves podemos usar parametros de ruta
        public async Task<ActionResult<Libro>> Get(int id)
        {
            return await context.Libros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == id);     //Firstorder me permite traer el primer registro que concida con la condicion.
        }

        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {
            //primero quiero confirmar que el autor si exista
            var existerAutor = await context.Autores.AnyAsync(x => x.Id == libro.AutorId); //primero hacemos el query

            if (!existerAutor)
            {
                return BadRequest($"no existe el autori de ID: {libro.AutorId}"); //luego hacemos la verificacion
            }

            context.Add(libro); //si si existe el autor entonces añadir
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
