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
        //private readonly IMoviesMapper _MoviesMapper;
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
                //logg exception or do anything with it
                return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }

        /*[HttpGet("{id:int}", Name = "GetSingleMovies")]
        public IActionResult GetSingle(int id)
        {
            try
            {
                MovieEntity MovieEntity = _MoviesRepository.GetSingle(id);

                if (MovieEntity == null)
                {
                    return NotFound();
                }

                return Ok(_MoviesMapper.MapToDto(MovieEntity));
            }
            catch (Exception exception)
            {
                //logg exception or do anything with it
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPatch("{id:int}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<MovieDto> MoviesPatchDocument)
        {
            try
            {
                if (MoviesPatchDocument == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                MovieEntity MovieEntity = _MoviesRepository.GetSingle(id);

                if (MovieEntity == null)
                {
                    return NotFound();
                }

                MovieDto existingMovies = _MoviesMapper.MapToDto(MovieEntity);

                MoviesPatchDocument.ApplyTo(existingMovies, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _MoviesRepository.Update(_MoviesMapper.MapToEntity(existingMovies));

                return Ok(existingMovies);
            }
            catch (Exception exception)
            {
                //logg exception or do anything with it
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] MovieDto MovieDto)
        {
            try
            {
                if (MovieDto == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                MovieEntity MovieEntity = _MoviesMapper.MapToEntity(MovieDto);

                _MoviesRepository.Add(MovieEntity);
   
                return CreatedAtRoute("GetSingleMovies", new { id = MovieEntity.Id }, _MoviesMapper.MapToDto(MovieEntity));
            }
            catch (Exception exception)
            {
                //logg exception or do anything with it
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] MovieDto MovieDto)
        {
            try
            {
                if (MovieDto == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                MovieEntity MovieEntityToUpdate = _MoviesRepository.GetSingle(id);

                if (MovieEntityToUpdate == null)
                {
                    return NotFound();
                }

                MovieEntityToUpdate.ZipCode = MovieDto.ZipCode;
                MovieEntityToUpdate.Street = MovieDto.Street;
                MovieEntityToUpdate.City = MovieDto.City;

                _MoviesRepository.Update(MovieEntityToUpdate);

                return Ok(_MoviesMapper.MapToDto(MovieEntityToUpdate));
            }
            catch (Exception exception)
            {
                //logg exception or do anything with it
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                MovieEntity MovieEntityToDelete = _MoviesRepository.GetSingle(id);

                if (MovieEntityToDelete == null)
                {
                    return NotFound();
                }

                _MoviesRepository.Delete(id);

                return NoContent();
            }
            catch (Exception exception)
            {
                //logg exception or do anything with it
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }*/
    }
}
