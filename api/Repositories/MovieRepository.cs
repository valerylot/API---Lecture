

using System.Data.Common;
using api.Data;
using api.Models;

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

        public List<Movie> GetAll()
        {
            //we are going into our db into the movies table and returning all movies
            return _db.Movies.ToList();
        }

        public Movie? GetById(int id)
        {
            //find looks up a row by its primary key, it returns null if there is no match
            return _db.Movies.Find(id);
        }

        public Movie Add(Movie movie)
        {
            //add only marks the movie as new. Nothing is in the database yet
            _db.Movies.Add(movie);

            //SaveChanges() sends INSERT into the database. After this, the movie row is filled in
            _db.SaveChanges();
            return movie;
        }

        public void Update(Movie movie)
        {
            //we mark the movie is changed, and then save those changes to the db
            _db.Movies.Update(movie);
            _db.SaveChanges();
        }

        public void Delete(Movie movie)
        {
            //we mark the movie for removal, then SaveChanges send the delete
            _db.Movies.Remove(movie);
            _db.SaveChanges();
        }
    }
}