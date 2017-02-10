using SampleWebApiAspNetCore.Models;

namespace SampleWebApiAspNetCore.Services
{
    public interface IMoviesMapper
    {
        MovieDto MapToDto(MovieEntity MovieEntity);
        MovieEntity MapToEntity(MovieDto MovieDto);
    }
}