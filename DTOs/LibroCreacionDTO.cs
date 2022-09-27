using System.ComponentModel.DataAnnotations;
using webapi.Validation;

namespace webapi.DTOs
{
    public class LibroCreacionDTO
    {
        [FirstLetterMayusAtribute]
        [StringLength(maximumLength: 250)]
        [Required]
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public List<int> AutoresIds { get; set; } //con esto el cliente manda los ID de los autores. 
    }
}
