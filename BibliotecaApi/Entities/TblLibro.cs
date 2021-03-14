using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApi.Entities
{
    [Table("Libro")]
    public class TblLibro
    {
        [Key]
        public int idLibro { get; set; }

        [MaxLength(80)]
        [Required]
        public string titulo { get; set; }

        [Required]
        [Range(1500, 9999)]
        public int ano { get; set; }

        [MaxLength(50)]
        [Required]
        public string genero { get; set; }

        [Required]
        public int numPag { get; set; }

        public int idEditorial { get; set; }

        public int idAutor { get; set; }

        [ForeignKey("idEditorial")]
        public virtual TblEditorial tblEditorial { get; set; }

        [ForeignKey("idAutor")]
        public virtual TblAutor tblAutor { get; set; }

    }
}
