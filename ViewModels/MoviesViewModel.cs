using ApiPelicula.Models;

namespace ApiPelicula.ViewModels
{
    public class MoviesViewModel
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public int Estreno { get; set; }
        public string? Director { get; set; }
        public string? Sinopsis { get; set; }
        public double Rating { get; set; }
        public int GeneroId { get; set; }
        public string? Genero { get; set; }
    }
}
