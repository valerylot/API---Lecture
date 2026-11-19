

using System.Data.Common;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    //the repository layer: the ONLY layer that talks to the database
    //it uses AppDbContext (Ef Core) to read and save movie entities
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _db;

        //DI (dependency injection): we never write a "new AppDbContext()" ourselves
        //ASP.NET Core sees this constructor asks for one and passes it in for us
        public MovieRepository(AppDbContext db)
        {
            _db = db;
        }

        //async lets this method use await inside of it
        public async Task<List<Movie>> GetAllAsync()
        {
            //we are going into our db into the movies table and returning all movies
            //await: while our db is working, this thread is freed to handle other requests
            return await _db.Movies.ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            //FindAsync looks up a row by its primary key, it returns null if there is no match
            return await _db.Movies.FindAsync(id);
        }

        public async Task<Movie> AddAsync(Movie movie)
        {
            //add only marks the movie as new. Nothing is in the database yet
            //that's why Add has no await, it doesn't talk to the db
            _db.Movies.Add(movie);

            //SaveChanges() sends INSERT into the database. After this, the movie row is filled in
            await _db.SaveChangesAsync();
            return movie;
        }

        public async Task UpdateAsync(Movie movie)
        {
            //we mark the movie is changed, and then save those changes to the db
            _db.Movies.Update(movie);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Movie movie)
        {
            //we mark the movie for removal, then SaveChanges send the delete
            _db.Movies.Remove(movie);
            await _db.SaveChangesAsync();
        }
    }
}