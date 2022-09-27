namespace webapi.Controllers.Entidades
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public int LibroId { get; set; }
        public Libro Libro { get; set; } //propiedades de navegacion me permiten hace joins  de un amanera sencilla
    }
}
