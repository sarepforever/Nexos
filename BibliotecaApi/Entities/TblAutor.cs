using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApi.Entities
{
    [Table("Autor")]
    public class TblAutor
    {
        [Key]
        public int idAutor { get; set; }

        [MaxLength(80)]
        [Required]
        public string nombre { get; set; }

        [Required]
        public DateTime fechaNacimiento { get; set; }

        [Required]
        [MaxLength(50)]
        public string ciudad { get; set; }

        [MaxLength(80)]
        public string mail { get; set; }

        public bool? activo { get; set; }

        public virtual ICollection<TblLibro> tblLibro { get; set; }
    }
}
