using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApi.DTOs
{
    public class POSTEditorialDTO
    {
       
        [MaxLength(80)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string nombre { get; set; }

        [MaxLength(50)]
        public string direccion { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string telefono { get; set; }

        [MaxLength(80)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El campo {0} debe tener el formato correcto ('example@example.com')")]
        public string mail { get; set; }

        public int? numLibros { get; set; }       
    }
    public class GETEditorialDTO
    {
        public int idEditorial { get; set; }

        public string nombre { get; set; }

        public string direccion { get; set; }
      
        public string telefono { get; set; }
        
        public string mail { get; set; }

        public int? numLibros { get; set; }
    }
}
