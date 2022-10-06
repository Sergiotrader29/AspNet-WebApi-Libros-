using System.ComponentModel.DataAnnotations;

namespace webapi.DTOs
{
    public class EditarAdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
