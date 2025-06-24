using ApiPelicula.DataAccess;
using ApiPelicula.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPelicula.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public MoviesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var movies = _appDbContext.Movies.ToList();
            if (movies == null) return NotFound();

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _appDbContext.Movies.FirstOrDefault(x => x.Id == id);
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Post(MovieInput movieInput)
        {
            var movie = new Movie();
            movie.Titulo = movieInput.Titulo;
            movie.Estreno = movieInput.Estreno;
            movie.Sinopsis = movieInput.Sinopsis;
            movie.Director = movieInput.Director;
            movie.Rating = movieInput.Rating;
            movie.GeneroId = movieInput.GeneroId;
            _appDbContext.Movies.Add(movie);
            if (_appDbContext.SaveChanges() > 0) return Ok();

            return BadRequest();

        }

        [HttpPut("{id}")]
        public IActionResult Put(MovieInput movieInput, int id)
        {
            var movie = _appDbContext.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null) return NotFound();

            movie.Titulo = movieInput.Titulo;
            movie.Estreno = movieInput.Estreno;
            movie.Sinopsis = movieInput.Sinopsis;
            movie.Director = movieInput.Director;
            movie.Rating = movieInput.Rating;
            movie.GeneroId = movieInput.GeneroId;

            if (_appDbContext.SaveChanges() > 0) return Ok();

            return BadRequest();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _appDbContext.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null) return NotFound();

            _appDbContext.Movies.Remove(movie);
            if (_appDbContext.SaveChanges() > 0) return NoContent();
            return BadRequest();

        }


    }
}
