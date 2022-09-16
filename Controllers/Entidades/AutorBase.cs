using System.ComponentModel.DataAnnotations;
using webapi.Controllers.Entidades;
using webapi.Validation;

namespace webApi.controllers.Entidades
{
    public class AutorBase
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo {0} no debe tener más de {1} carácteres")]
        [FirstLetterMayusAtribute]
        public string Name { get; set; }
        public List<Libro> Libros { get; set; }
    }
}