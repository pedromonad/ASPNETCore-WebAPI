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

        public async Task<MovieEntity> GetSingle(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
        }

        
        public async Task<MovieEntity> Add(MovieEntity newMovie)
        {
             _context.Movies.Add(newMovie);
             await _context.SaveChangesAsync();
             return newMovie;
        }

        public async Task<MovieEntity> Update(MovieEntity toUpdate)
        {
            if (toUpdate == null)  return null; 

            _context.Movies.Update(toUpdate);
            await _context.SaveChangesAsync();
            return toUpdate;
        }

        public async Task Delete(int id)
        {
            MovieEntity model = await GetSingle(id);
            _context.Movies.Remove(model);
            await _context.SaveChangesAsync();
        }
        
    }
}