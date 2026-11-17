

using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    //the DbContext is Ef Core's connection to the database
    //our repositories use it to read and save rows (data to our database)
    public class AppDbContext : DbContext 
    {
        //the options (which database to use, and its connection string) come from Program.cs, through dependency injection
        //We just hand them to the DbContext base class
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        //each DbSet is ONE table, this one becomes the movies table
        public DbSet<Movie> Movies { get; set; }
    }
}