using webApi.controllers.Entidades;

namespace webapi.Controllers.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AutorId { get; set; }
        public AutorBase Autor { get; set; } //propiedad de navegacion con esto vamos a relacionar autor con libros. 
    }
}
