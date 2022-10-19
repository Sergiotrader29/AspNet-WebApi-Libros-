﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Controllers.Entidades;
using webapi.DTOs;
using webapi.Utilidades;

namespace webapi.Controllers.v1
{

    [ApiController]
    [Route("api/V1/libros/{libroId:int}/comentarios")] // Con esta ruta decimos que comentarios depende de un Libro
    public class ComentariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;

        public ComentariosController(ApplicationDbContext context, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet(Name = "obtenerComentariosLibros")]
        public async Task<ActionResult<List<ComentarioDTO>>> Get(int libroId,
            [FromQuery] PaginacionDTO paginacionDTO)
        { 
            var existeLibro = await context.Libros.AnyAsync(libroDB => libroDB.Id == libroId);

            if (!existeLibro)
            {
                return NotFound();
            }

            var queryable = context.Comentarios.Where(comentarioDB => comentarioDB.LibroId == libroId).AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            var comentarios = await queryable.OrderBy(comentario => comentario.Id)
                .Paginar(paginacionDTO).ToListAsync();

            return mapper.Map<List<ComentarioDTO>>(comentarios);
        }

        [HttpGet("{id:int}", Name = "obtenerComentario")]
        public async Task<ActionResult<ComentarioDTO>> GetPorId(int id)
        {
            var comentario = await context.Comentarios.FirstOrDefaultAsync(comentarioDB => comentarioDB.Id == id);

            if (comentario == null)
            {
                return NotFound();
            }

            return mapper.Map<ComentarioDTO>(comentario);
        }


        [HttpPost(Name = "crearComentarios")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post(int libroId, ComentarioCreacionDto comentarioCreacionDto)
        {
            //busco el email con la funcion where y ponga la funcion . y el firorsdefault, ojo organizar mapeo en startup
            var emailclaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailclaim.Value;
            var usuario = await userManager.FindByEmailAsync(email); // primero inyectar independencia arriba de usermanager
            var usuarioId = usuario.Id; // me devuelve el id de el de arriba
            var existeLibro = await context.Libros.AnyAsync(libroDB => libroDB.Id == libroId);

            if (!existeLibro)
            {
                return NotFound();
            }

            var comentario = mapper.Map<Comentario>(comentarioCreacionDto);
            comentario.LibroId = libroId;
            comentario.UsuarioId = usuarioId;

            context.Add(comentario);
            await context.SaveChangesAsync();
            var comentarioDTO = mapper.Map<ComentarioDTO>(comentario);

            return CreatedAtRoute("obtenerComentario", new { id = comentario.Id, libroId }, comentarioDTO);
        }

        [HttpPut("{id:int}", Name = "actualizarComentarios")]
        public async Task<ActionResult> Put(int libroId, int id, ComentarioCreacionDto comentarioCreacionDTO)
        {
            var existeLibro = await context.Libros.AnyAsync(libroDB => libroDB.Id == libroId);

            if (!existeLibro)
            {
                return NotFound();
            }

            var existeComentario = await context.Comentarios.AnyAsync(comentarioDB => comentarioDB.Id == id);

            if (!existeComentario)
            {
                return NotFound();
            }

            var comentario = mapper.Map<Comentario>(comentarioCreacionDTO);
            comentario.Id = id;
            comentario.LibroId = libroId;
            context.Update(comentario);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}

