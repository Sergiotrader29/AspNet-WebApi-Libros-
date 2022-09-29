using AutoMapper;
using webapi.Controllers.Entidades;
using webapi.DTOs;
using webApi.controllers.Entidades;
using WebAPIAutores.DTOs;

namespace webapi.Utilidades
{
    public class AutoMapperProfiles: Profile // viene de automapper
    {
        public AutoMapperProfiles() ///este es el contructor de la clase
        {
            CreateMap<AutorCreacionDTO, AutorBase>();
            CreateMap<AutorBase, AutorDTO>();
            CreateMap<AutorBase, AutorDTOConLibros>()
                .ForMember(autorDTO => autorDTO.Libros, opciones => opciones.MapFrom(MapAutorDTOLibros));

            CreateMap<LibroCreacionDTO, Libro>()
                .ForMember(libro => libro.AutoresLibros, opciones => opciones.MapFrom(MapAutoresLibros));
            CreateMap<Libro, LibroDTO>().ReverseMap();
            CreateMap<Libro, LibroDTOConAutores>()
                .ForMember(libroDTO => libroDTO.Autores, opciones => opciones.MapFrom(MapLibroDTOAutores));
            CreateMap<LibropatchDTO, Libro>().ReverseMap(); // cuando tengo dos mapper

            CreateMap<ComentarioCreacionDto, Comentario>();
            CreateMap<Comentario, ComentarioDTO>();
        }

        private List<LibroDTO> MapAutorDTOLibros(AutorBase autor, AutorDTO autorDTO)
        {
            var resultado = new List<LibroDTO>();

            if (autor.AutoresLibros == null) { return resultado; }

            foreach (var autorLibro in autor.AutoresLibros)
            {
                resultado.Add(new LibroDTO()
                {
                    Id = autorLibro.LibroId,
                    Titulo = autorLibro.Libro.Titulo
                });
            }

            return resultado;
        }

        private List<AutorDTO> MapLibroDTOAutores(Libro libro, LibroDTO LibroDTO) 
        {
            var resultado = new List<AutorDTO>();

            if (libro.AutoresLibros == null) { return resultado; } // si se esta creando un resultado nullo no importa

            foreach (var autorlibro in libro.AutoresLibros) //si hay autores aqui se procesan
            {
                resultado.Add(new AutorDTO()
                {
                    Id = autorlibro.AutorId,
                    Name = autorlibro.Autor.Name
                });
            }

            return resultado;
        }

        private List<AutorLibro> MapAutoresLibros(LibroCreacionDTO libroCreacionDTO, Libro libro) //se le colocan los parametros d eentrada
        {
            var resultado = new List<AutorLibro>();

            if (libroCreacionDTO.AutoresIds == null) { return resultado; } // si se esta creando un resultado nullo no importa

            foreach (var autorId in libroCreacionDTO.AutoresIds) //si hay autores aqui se procesan
            {
                resultado.Add(new AutorLibro() { AutorId = autorId });
            }

            return resultado;
        }
    }
}
