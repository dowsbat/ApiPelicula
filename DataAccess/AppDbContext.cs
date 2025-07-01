using ApiPelicula.DataAccess.DataSeeder;
using ApiPelicula.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPelicula.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genero> Generos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)// es codigo que no se ejecuta, solamente lo hace al ejecutar migraciones ya que son configuraciones de la base datos
        {// se debe configurar en cada una de las tablas de manera manual
            modelBuilder.Entity<Movie>().Property(m => m.Titulo).IsRequired();
            modelBuilder.Entity<Movie>().HasIndex(m => m.Titulo).IsUnique();
            modelBuilder.Entity<Movie>().Property(m => m.Titulo).HasMaxLength(50);
            modelBuilder.Entity<Movie>().Property(m => m.Sinopsis).HasMaxLength(500);
 
            modelBuilder.Entity<Genero>().HasData(Seeder.Genero);// para colocar datos directamente en la base de datos 
            modelBuilder.Entity<Movie>().HasData(Seeder.Movie);
            base.OnModelCreating(modelBuilder);
        }
    }
}
