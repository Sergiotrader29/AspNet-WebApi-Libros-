using System.ComponentModel.DataAnnotations;
using webapi.Validation;
using webApi.controllers.Entidades;

namespace webapi.Controllers.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo {0} no debe tener más de {1} carácteres")]
        [FirstLetterMayusAtribute]
        public string Titulo { get; set; }
        public List<Comentario> Comentarios { get; set; } //me permite hacer joins de manera sencilla
        public List<AutorLibro> AutoresLibros { get; set; } //me permite hacer joins de manera sencilla

    }
}
