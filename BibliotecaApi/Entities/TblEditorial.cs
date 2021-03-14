using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApi.Entities
{
    [Table("Editoria")]
    public class TblEditorial
    {
        [Key]
        public int idEditorial { get; set; }

        [MaxLength(80)]
        [Required]
        public string nombre { get; set; }

        [MaxLength(50)]
        public string direccion { get; set; }

        [MaxLength(20)]
        [Required]
        public string telefono { get; set; }

        [MaxLength(80)]
        [Required]
        public string mail { get; set; }

        public int? numLibros { get; set; }

        public bool? activo { get; set; }

        public virtual ICollection<TblLibro> tblLibro { get; set; }
    }
}
