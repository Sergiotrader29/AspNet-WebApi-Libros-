using System.ComponentModel.DataAnnotations;
using webapi.Validation;

namespace webapi.DTOs
{
    public class AutorCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        [FirstLetterMayusAtribute]
        public string Name { get; set; }
    }
}
