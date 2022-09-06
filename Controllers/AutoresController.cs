using Microsoft.AspNetCore.Mvc;
using webApi.controllers.Entidades;
using webapi;
using Microsoft.EntityFrameworkCore;

namespace WebApiAutores.controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorBase>>> Get()
        {
            return await context.Autores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(AutorBase autor )
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }

}