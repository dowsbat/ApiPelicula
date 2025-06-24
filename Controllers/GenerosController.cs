using ApiPelicula.DataAccess;
using ApiPelicula.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPelicula.Controllers
{
    [ApiController] // atributos
    [Route("/api/[controller]")] // de la clase
    public class GenerosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public GenerosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]// atributo del metodo
        public IActionResult GetAll()
        {
            var generos = _appDbContext.Generos.ToList();
            if (generos == null) return BadRequest("No hay datos");
            return Ok(generos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var genero = GetGenero(id);
            return Ok(genero);

        }

        [HttpPost]
        public IActionResult Post(GeneroInput model)
        {
            var genero = new Genero();
            genero.Nombre = model.Nombre;
            _appDbContext.Generos.Add(genero);
            if (_appDbContext.SaveChanges() > 0) return Ok();

            return BadRequest();

        }

        [HttpPost("Lista")]
        public IActionResult Post(List<GeneroInput> models)
        {
            var generos = new List<Genero>();

            foreach (var model in models)
            {
                var genero = new Genero();
                genero.Nombre = model.Nombre;
                generos.Add(genero);
            }
            _appDbContext.Generos.AddRange(generos);
            if (_appDbContext.SaveChanges() > 0) return Ok();

            return BadRequest();

        }

        [HttpPut("{id}")]

        public IActionResult Put(GeneroInput model, int id)
        {
            var genero = GetGenero(id); ;
            if (genero == null) return BadRequest();

            genero.Nombre = model.Nombre;
            if (_appDbContext.SaveChanges() > 0) return Ok();

            return BadRequest();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var genero = GetGenero(id); ;
            if (genero == null) return BadRequest();

            _appDbContext.Generos.Remove(genero);
            if (_appDbContext.SaveChanges() > 0) return NoContent();

            return BadRequest();

        }

        private Genero? GetGenero(int id)
        {
            return _appDbContext.Generos.FirstOrDefault(g => g.Id == id);
        }



        // Get, Post, Put, Delete

        /*status code
         * 200(200 a 299) son OK del controllerbase, son buenos - Ok
         * 
         * 400(400 a 499) que algo se pidio de mala manera - Bad Request
         * 
         * 500(500 a 599) algo jodio la api o el codigo - Internal Server Error
         * 
         * 
         * 
         */

    }

}
