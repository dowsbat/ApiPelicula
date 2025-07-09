using ApiPelicula.DataAccess;
using ApiPelicula.Models;
using ApiPelicula.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPelicula.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public MoviesController(AppDbContext appDbContext, IMapper mapper) // aqui recibe el db context uy el maper
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll(string? titulo, double? rating, int? duracion, string? director, int? estreno)
        {
            //var movies = _appDbContext.Movies.ToList(); Select all pero sin hacer consutlas a otra tabla
            var movies = _appDbContext.Movies.Include(m => m.Genero).ToList(); // el Include es como un inner Join
                                                                               // los input es loq ue el cliente recibe y el viewmodel es lo que el le vas a mostrar al cliente
            if (movies == null) return NotFound();
            //List es mas completo y Ienumerable solo trae lo basico 
            if (!string.IsNullOrEmpty(titulo))
            {
                movies = movies.Where(m => m.Titulo.StartsWith(titulo, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (rating != null)
            {
                movies = movies.Where(m => m.Rating >= rating).ToList(); // > mayor que  < menor que
            }
            if (duracion != null)
            {
                movies = movies.Where(m => m.Duracion > duracion).ToList();
            }
            if (!string.IsNullOrEmpty(director))
            {
                movies = movies.Where(m => m.Director.StartsWith(director, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (estreno != null)
            {
                movies = movies.Where(m => m.Estreno == estreno).ToList();
            }

            var resultado = _mapper.Map<IEnumerable<MoviesViewModel>>(movies);
            return Ok(resultado);

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = GetMovie(id);
            if (movie == null) return BadRequest();

            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Post(MovieInput movieInput)
        {
            /* var movie = new Movie();
            movie.Titulo = movieInput.Titulo;
            movie.Estreno = movieInput.Estreno;
            movie.Sinopsis = movieInput.Sinopsis;
            movie.Director = movieInput.Director;
            movie.Rating = movieInput.Rating;
            movie.GeneroId = movieInput.GeneroId;
            */
            var movie = _mapper.Map<Movie>(movieInput);
            _appDbContext.Movies.Add(movie);
            if (_appDbContext.SaveChanges() > 0) return Ok();

            return BadRequest();

        }

        [HttpPut("{id}")]
        public IActionResult Put(MovieInput movieInput, int id)
        {
            var movie = GetMovie(id);
            if (movie == null) return NotFound();
            /*
                        movie.Titulo = movieInput.Titulo;
                        movie.Estreno = movieInput.Estreno;
                        movie.Sinopsis = movieInput.Sinopsis;
                        movie.Director = movieInput.Director;
                        movie.Rating = movieInput.Rating;
                        movie.GeneroId = movieInput.GeneroId;
            */
            _mapper.Map(movieInput, movie);
            if (_appDbContext.SaveChanges() > 0) return Ok();

            return BadRequest();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = GetMovie(id);
            if (movie == null) return NotFound();

            _appDbContext.Movies.Remove(movie);
            if (_appDbContext.SaveChanges() > 0) return NoContent();
            return BadRequest();

        }

        private Movie? GetMovie(int id)
        {
            return _appDbContext.Movies.Include(m => m.Genero).FirstOrDefault(m => m.Id == id);
        }


    }
}
