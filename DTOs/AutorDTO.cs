namespace webapi.DTOs
{
    public class AutorDTO: Recurso  //hereda de Recuros y con eso puedo agregarle los enlaces de HATEOS
    {
        public int Id { get; set; }
        public string Name { get; set; }
      //  public List<LibroDTO> Libros { get; set; } // Vamos a ller un autor con sus libros
    }
}
