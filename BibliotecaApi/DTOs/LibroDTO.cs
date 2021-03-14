using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApi.DTOs
{
    public class POSTLibroDTO
    {
        [MaxLength(80)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string titulo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1500, 9999)]
        public int ano { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string genero { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int numPag { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int idEditorial { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int idAutor { get; set; }
    }
    public class GETLibroDTO
    {
        public int idLibro { get; set; }

        public string titulo { get; set; }

        public int ano { get; set; }
       
        public string genero { get; set; }
       
        public int numPag { get; set; }
      
        public int idEditorial { get; set; }
      
        public int idAutor { get; set; }

        public GETAutorDTO tblAutor { get; set; }

        public GETEditorialDTO tblEditorial { get; set; }

    }
}
