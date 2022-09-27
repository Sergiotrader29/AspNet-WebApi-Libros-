using webApi.controllers.Entidades;

namespace webapi.Controllers.Entidades
{
    public class AutorLibro
    {
        public int LibroId { get; set; }
        public int AutorId { get; set; }
        public int Orden { get; set; }
        public Libro Libro { get; set; }
        public AutorBase Autor { get; set; }
    }
}
