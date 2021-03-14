using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApi.Entities
{
    public class DbContextBiblioteca: DbContext
    {
        public DbContextBiblioteca(DbContextOptions<DbContextBiblioteca> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblEditorial>().Property(x => x.activo).HasDefaultValue(true);
            modelBuilder.Entity<TblEditorial>().Property(x => x.numLibros).HasDefaultValue(-1);
            modelBuilder.Entity<TblAutor>().Property(x => x.activo).HasDefaultValue(true);
            modelBuilder.Entity<TblAutor>().Property(x => x.fechaNacimiento).HasColumnType("date");
        }

        public DbSet<TblEditorial> tblEditorial { get; set; }
        public DbSet<TblAutor> tblAutor { get; set; }
        public DbSet<TblLibro> tblLibro { get; set; }
    }
}
