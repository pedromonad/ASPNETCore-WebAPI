using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SampleWebApiAspNetCore.Models;
using SampleWebApiAspNetCore.Repositories;
using SampleWebApiAspNetCore.Services;
using System.Threading.Tasks;

namespace SampleWebApiAspNetCore.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMoviesRepository _MoviesRepository;

        public MoviesController(
             IMoviesRepository MoviesRepository)
        {
            _MoviesRepository = MoviesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _MoviesRepository.GetAll());
            }
            catch (Exception exception)
            {
                Console.Write(exception.ToString());
                return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{id:int}", Name = "GetSingleMovies")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                MovieEntity MovieEntity = await _MoviesRepository.GetSingle(id);

                if (MovieEntity == null)
                {
                    return NotFound();
                }

                return Ok(MovieEntity);
            }
            catch (Exception exception)
            {
                Console.Write(exception.ToString());
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MovieEntity MovieEntity)
        {
            try
            {
                if (MovieEntity == null)
                {
                    return BadRequest();
                }

                await _MoviesRepository.Add(MovieEntity);
   
                return CreatedAtRoute("GetSingleMovies", new { id = MovieEntity.Id }, MovieEntity);
            }
            catch (Exception exception)
            {
                Console.Write(exception.ToString());
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] MovieEntity movieEntity)
        {
            try
            {
                if (movieEntity == null)
                {
                    return BadRequest();
                }

                MovieEntity movieEntityToUpdate = await _MoviesRepository.GetSingle(id);

                if (movieEntityToUpdate == null)
                {
                    return NotFound();
                }

                movieEntityToUpdate.Title = movieEntity.Title;
                movieEntityToUpdate.Director = movieEntity.Director;

                await _MoviesRepository.Update(movieEntityToUpdate);

                return Ok(movieEntityToUpdate);
            }
            catch (Exception exception)
            {
                Console.Write(exception.ToString());
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                MovieEntity MovieEntityToDelete = await _MoviesRepository.GetSingle(id);

                if (MovieEntityToDelete == null)
                {
                    return NotFound();
                }

                await _MoviesRepository.Delete(id);

                return NoContent();
            }
            catch (Exception exception)
            {
                Console.Write(exception.ToString());
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
