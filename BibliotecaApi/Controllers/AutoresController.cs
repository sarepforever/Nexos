using AutoMapper;
using BibliotecaApi.DTOs;
using BibliotecaApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly DbContextBiblioteca _context;
        private readonly IMapper _mapper;

        public AutoresController(DbContextBiblioteca context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        /// <summary>
        /// Lista un Autor Especifico
        /// </summary>
        /// <param name="id">Id del Autor a Listar</param>
        // GET api/<AutoresController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GETAutorDTO), 200)]
        public async Task<ActionResult<GETAutorDTO>> GetAutor(int id)
        {
            var Autor = await _context.tblAutor.FindAsync(id);

            if (Autor == null)
            {
                return NotFound("Recurso no encontrado");
            }
            return _mapper.Map<GETAutorDTO>(Autor);
        }
        /// <summary>
        /// Crear un Autor
        /// </summary>
        // POST api/<AutoresController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GETAutorDTO), 200)]
        public async Task<ActionResult<GETAutorDTO>> Post([FromBody] POSTAutorDTO autor)
        {
            var Autor = _mapper.Map<TblAutor>(autor);
            await _context.AddAsync(Autor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (e.InnerException is null)
                    return BadRequest(e.Message);
                else
                    return BadRequest(e.InnerException.Message);
            }
            var autorDTO = _mapper.Map<GETAutorDTO>(Autor);
            return CreatedAtAction("GetAutor", new { id = Autor.idAutor }, autorDTO);
        }
       
    }
}
