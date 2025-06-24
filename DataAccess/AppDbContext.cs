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

    }
}
