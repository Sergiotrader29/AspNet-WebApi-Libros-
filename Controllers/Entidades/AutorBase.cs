using webapi.Controllers.Entidades;

namespace webApi.controllers.Entidades
{
    public class AutorBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Libro> Libros { get; set; }
    }
}