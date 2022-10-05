﻿using Microsoft.AspNetCore.Mvc;
using webApi.controllers.Entidades;
using webapi;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using webapi.DTOs;
using WebAPIAutores.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApiAutores.controllers
{
    [ApiController]
    [Route("api/autores")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper; // esto significa que es inicializado como un campo. 

        public AutoresController(ApplicationDbContext context, IMapper mapper)s
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        
        public async Task<ActionResult<List<AutorDTO>>> Get()
        {
            var autores = await context.Autores.ToListAsync();
            return mapper.Map<List<AutorDTO>>(autores);
        }

        [HttpGet("{id:int}", Name = "obtenerAutor")]
        public async Task<ActionResult<AutorDTOConLibros>> Get(int id)
        {
            var autor = await context.Autores
                .Include(autorDB => autorDB.AutoresLibros)
                .ThenInclude(autorLibroDB => autorLibroDB.Libro)
                .FirstOrDefaultAsync(autorBD => autorBD.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            return mapper.Map<AutorDTOConLibros>(autor);
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<AutorDTO>>> Get([FromRoute] string nombre)
        {
            var autores = await context.Autores.Where(autorBD => autorBD.Name.Contains(nombre)).ToListAsync();

            return mapper.Map<List<AutorDTO>>(autores); //colocamos esto para no exponer nuestras entidades 
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AutorCreacionDTO autorCreacionDTO)
        {
            var existeAutorConElMismoNombre = await context.Autores.AnyAsync(x => x.Name == autorCreacionDTO.Name);

            if (existeAutorConElMismoNombre)
            {
                return BadRequest($"Ya existe un autor con el nombre {autorCreacionDTO.Name}");
            }

            var autor = mapper.Map<AutorBase>(autorCreacionDTO);

            context.Add(autor);
            await context.SaveChangesAsync();
            

            var autorDTO = mapper.Map<AutorDTO>(autor);

            return CreatedAtRoute("obtenerAutor", new { id = autor.Id }, autorDTO);
        }

        [HttpPut("{id:int}")] // api/autores/algo
        public async    Task<ActionResult> Put(AutorCreacionDTO autorCreacionDTO, int id)
        {

            var existe = await context.Autores.AnyAsync(x => x.Id == id); //busca en la lista y anysync significa en algun lado

            if (!existe)
            {
                return NotFound();   

            }

            var autor = mapper.Map<AutorBase>(autorCreacionDTO);
            autor.Id = id;

            context.Update(autor);
            await context.SaveChangesAsync();
            return NoContent(); //Retornar un 204
        }

        [HttpDelete("{id:int}")] // api/autores/algo
        public async Task<ActionResult> Delete(int id)
        {
            var existe =  await context.Autores.AnyAsync(x => x.Id == id); 

            if (!existe)
            {
                return NotFound();

            }

            context.Remove(new AutorBase() { Id = id }); 
            await context.SaveChangesAsync();
            return Ok();
        }
    }

}
