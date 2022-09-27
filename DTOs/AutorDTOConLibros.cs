using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.DTOs;

namespace WebAPIAutores.DTOs
{
    public class AutorDTOConLibros : AutorDTO //va a eredat de DTO
    {
        public List<LibroDTO> Libros { get; set; }
    }
}