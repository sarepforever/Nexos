using AutoMapper;
using BibliotecaApi.DTOs;
using BibliotecaApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BibliotecaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly DbContextBiblioteca _context;
        private readonly IMapper _mapper;

        public LibrosController(DbContextBiblioteca context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        /// <summary>
        /// Lista un conjunto de Libros Especifico Filtrando por: Titulo,Gegero,Autor,Editorial.
        /// </summary>
        /// <param name="value">Valor del Parametro por el Cual Filtrar</param>
        //GET: api/<LibrosController>
        [HttpGet]      
        [ProducesResponseType(typeof(List<GETLibroDTO>), 200)]
        public async Task<ActionResult<List<GETLibroDTO>>> GetLibros(string value)
        {
            if (value == null)
                value = "";
            var libros = await (from s in _context.tblLibro
                                select new GETLibroDTO
                                {
                                    idLibro = s.idLibro,
                                    titulo = s.titulo,
                                    ano = s.ano,
                                    genero = s.genero,
                                    numPag = s.numPag,
                                    idEditorial = s.idEditorial,
                                    idAutor = s.idAutor,
                                    tblAutor = new GETAutorDTO()
                                    {
                                        idAutor = s.tblAutor.idAutor,
                                        nombre = s.tblAutor.nombre,
                                        fechaNacimiento = s.tblAutor.fechaNacimiento,                                        
                                        ciudad = s.tblAutor.ciudad,
                                        mail = (s.tblAutor.mail!=null)?s.tblAutor.mail:"",
                                    },
                                    tblEditorial = new GETEditorialDTO()
                                    {
                                        idEditorial = s.tblEditorial.idEditorial,
                                        nombre = s.tblEditorial.nombre,
                                        direccion = s.tblEditorial.direccion,
                                        mail = s.tblEditorial.mail,
                                        numLibros = s.tblEditorial.numLibros,
                                        telefono = s.tblEditorial.telefono,

                                    },
                                }) .Where(s=> s.titulo.Contains(value) || s.genero.Contains(value) || s.tblAutor.nombre.Contains(value) || s.tblEditorial.nombre.Contains(value)).ToListAsync();
            return libros;
        }

        /// <summary>
        /// Lista un Libro Especifico
        /// </summary>
        /// <param name="id">Id del Libro a Listar</param>
        // GET api/<LibrosController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GETLibroDTO),200)]
        public async Task<ActionResult<GETLibroDTO>> GetLibro(int id)
        {
            var libro = await _context.tblLibro.FindAsync(id);

            if (libro == null)
            {
                return NotFound("Recurso no encontrado");
            }
            return _mapper.Map<GETLibroDTO>(libro);
        }

        /// <summary>
        /// Crear un Libro
        /// </summary>
        // POST api/<LibrosController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GETLibroDTO), 200)]
        public async Task<ActionResult<GETLibroDTO>> Post([FromBody] POSTLibroDTO libro)
        {
            if (!_context.tblAutor.Any(x => x.idAutor == libro.idAutor))
                return NotFound("El autor no está registrado.");

            var editorial = await _context.tblEditorial.FirstOrDefaultAsync(x => x.idEditorial == libro.idEditorial);

            if (editorial == null)
                return NotFound("La editorial no está registrada.");

            if (editorial.numLibros < editorial.tblLibro.Count+1 && editorial.numLibros > 0)
                return BadRequest("No es posible registrar el libro, se alcanzó el máximo permitido.");

            var Libro = _mapper.Map<TblLibro>(libro);

            _context.Add(Libro);
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

            var libroDTO = _mapper.Map<GETLibroDTO>(await _context.tblLibro.Include(s => s.tblAutor).FirstAsync(s=>s.idLibro== Libro.idLibro));

            return CreatedAtAction("GetLibro", new { id = libroDTO.idLibro }, libroDTO);
        }
    }
}
