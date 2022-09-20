using AutoMapper;
using webapi.DTOs;
using webApi.controllers.Entidades;

namespace webapi.Utilidades
{
    public class AutoMapperProfiles: Profile // viene de automapper
    {
        public AutoMapperProfiles() ///este es el contructor de la clase
        {
            CreateMap<AutorCreacionDTO, AutorBase>();
        }
    }
}
