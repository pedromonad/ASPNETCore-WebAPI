using System.Collections.Generic;
using SampleWebApiAspNetCore.Models;
using System.Threading.Tasks;

namespace SampleWebApiAspNetCore.Repositories
{
    public interface IMoviesRepository
    {
        Task<List<MovieEntity>> GetAll();
        Task<MovieEntity> GetSingle(int id);
        Task<MovieEntity> Add(MovieEntity toAdd);
        Task<MovieEntity> Update(MovieEntity toUpdate);
        Task Delete(int id);
    }
}
