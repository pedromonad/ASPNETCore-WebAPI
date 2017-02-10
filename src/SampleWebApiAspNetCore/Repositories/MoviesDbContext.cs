using SampleWebApiAspNetCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApiAspNetCore.Repositories
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext() { }
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) {}

        public DbSet<MovieEntity> Movies { get; set; }
    }
}
