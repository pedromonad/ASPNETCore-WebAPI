using SampleWebApiAspNetCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SampleWebApiAspNetCore.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        readonly MoviesDbContext _context;

        public MoviesRepository(MoviesDbContext context)
        {
            _context = context;
        }

        public async Task<List<MovieEntity>> GetAll()
        {
            return await _context.Movies.ToListAsync();
        }

        /*

        public MovieEntity GetSingle(int id)
        {
            return _Moviess.FirstOrDefault(x => x.Key == id).Value;
        }

        public MovieEntity Add(MovieEntity toAdd)
        {
            int newId = !GetAll().Any() ? 1 : GetAll().Max(x => x.Id) + 1;
            toAdd.Id = newId;
            _Moviess.Add(newId, toAdd);
            return toAdd;
        }

        public MovieEntity Update(MovieEntity toUpdate)
        {
            MovieEntity single = GetSingle(toUpdate.Id);

            if (single == null)
            {
                return null;
            }

            _Moviess[single.Id] = toUpdate;
            return toUpdate;
        }

        public void Delete(int id)
        {
            _Moviess.Remove(id);
        }*/
    }
}