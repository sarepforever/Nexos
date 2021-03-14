using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApi.DTOs
{
    public class POSTAutorDTO
    {        
        [MaxLength(80)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime fechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50)]
        public string ciudad { get; set; }

        [MaxLength(80)]
        [EmailAddress(ErrorMessage = "El campo {0} debe tener el formato correcto ('example@example.com')")]
        public string mail { get; set; }     
    }
    public class GETAutorDTO
    {
        public int idAutor { get; set; }

        public string nombre { get; set; }
      
        public DateTime fechaNacimiento { get; set; }
    
        public string ciudad { get; set; }

        public string mail { get; set; }
    }
}
