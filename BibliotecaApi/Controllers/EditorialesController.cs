using AutoMapper;
using BibliotecaApi.DTOs;
using BibliotecaApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialesController : ControllerBase
    {
        private readonly DbContextBiblioteca _context;
        private readonly IMapper _mapper;

        public EditorialesController(DbContextBiblioteca context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Lista una Editorial Especifica
        /// </summary>
        /// <param name="id">Id de la Editorial a Listar</param>
        // GET api/<EditorialesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GETEditorialDTO), 200)]
        public async Task<ActionResult<GETEditorialDTO>> GetEditorial(int id)
        {
            var editorial = await _context.tblEditorial.FindAsync(id);

            if (editorial == null)
            {
                return NotFound("Recurso no encontrado");
            }
            return _mapper.Map<GETEditorialDTO>(editorial); 
        }

        /// <summary>
        /// Crear una Editorial
        /// </summary>
        // POST api/<EditorialesController>
        [HttpPost]    
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GETLibroDTO), 200)]
        public async Task<ActionResult<GETEditorialDTO>> Post([FromBody] POSTEditorialDTO editorial)
        {
            var Editorial = _mapper.Map<TblEditorial>(editorial);
            await _context.AddAsync(Editorial);
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
            var editorialDTO = _mapper.Map<GETEditorialDTO>(Editorial);
            return CreatedAtAction("GetEditorial", new { id = editorialDTO.idEditorial }, editorialDTO);
        }       
    }
}
