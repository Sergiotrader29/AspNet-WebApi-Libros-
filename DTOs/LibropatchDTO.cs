using System.ComponentModel.DataAnnotations;
using webapi.Validation;

namespace webapi.DTOs
{
    public class LibropatchDTO
    {
        [FirstLetterMayusAtribute]
        [StringLength(maximumLength: 250)]
        [Required]
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }
}
