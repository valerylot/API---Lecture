
using api.Models;

namespace api.Repositories
{
    public interface IMovieRepository
    {

        //the repository interface: the list of database jobs for movie
        //repositories work with entities (movie). Never DTOs
        List<Movie> GetAll();
        Movie? GetById(int id); 
        //returns one movie, or null if no movie has that id (that's what the question mark means)
        Movie Add(Movie movie);
    }
}