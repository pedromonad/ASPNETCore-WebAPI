using System.Linq;
using SampleWebApiAspNetCore.Models;

namespace SampleWebApiAspNetCore.Services
{
    public class MoviesMapper : IMoviesMapper
    {
        public MovieDto MapToDto(MovieEntity MovieEntity)
        {
            return new MovieDto()
            {
                Id = MovieEntity.Id,
                Title = MovieEntity.Title,
                Director = MovieEntity.Director
            };
        }

        public MovieEntity MapToEntity(MovieDto MovieDto)
        {
            return new MovieEntity()
            {
                Id = MovieDto.Id,
                Title = MovieDto.Title,
                Director = MovieDto.Director
            };
        }
    }
}