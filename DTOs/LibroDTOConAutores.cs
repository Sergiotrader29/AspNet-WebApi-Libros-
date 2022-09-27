using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.DTOs;

namespace WebAPIAutores.DTOs
{
    public class LibroDTOConAutores : LibroDTO
    {
        public List<AutorDTO> Autores { get; set; }
    }
}