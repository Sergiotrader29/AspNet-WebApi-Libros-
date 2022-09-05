using Microsoft.AspNetCore.Mvc;
using webApi.controllers.Entidades;

namespace WebApiAutores.controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AuctoresController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<AutorBase>> Get()
        {
            return new List<AutorBase>()
            {
                new AutorBase() { Id = 1, Name = "Felipe" },
                new AutorBase() { Id = 2, Name = "Claudia" }
            };
        }
    }

}