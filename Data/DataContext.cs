using Microsoft.EntityFrameworkCore;
using Suberheroes.Models;

namespace Suberheroes.Data
{
    public class DataContext:DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        }
        public DbSet<Superhero> superheroes { get; set; }
    }
}
