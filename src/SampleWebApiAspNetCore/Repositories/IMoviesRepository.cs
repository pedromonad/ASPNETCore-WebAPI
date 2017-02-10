using System.Collections.Generic;
using SampleWebApiAspNetCore.Models;
using System.Threading.Tasks;

namespace SampleWebApiAspNetCore.Repositories
{
    public interface IMoviesRepository
    {
        Task<List<MovieEntity>> GetAll();
       /* MovieEntity GetSingle(int id);
        MovieEntity Add(MovieEntity toAdd);
        MovieEntity Update(MovieEntity toUpdate);
        void Delete(int id);
        */
    }
}
