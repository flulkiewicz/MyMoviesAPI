using Microsoft.EntityFrameworkCore;
using MyMoviesAPI.Models;
using System.Data;

namespace MyMoviesAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public DbSet<Movie> Movies { get; set; }
        
    }
}
