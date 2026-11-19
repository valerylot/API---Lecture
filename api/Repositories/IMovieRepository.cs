
using api.Models;

namespace api.Repositories
{
    public interface IMovieRepository
    {

        //the repository interface: the list of database jobs for movie
        //repositories work with entities (movie). Never DTOs
        // List<Movie> GetAll();
        //Task<T> means "a T will be ready later" once the db answers 
        //the Async at the end of the name tells the caller to await it (its just a function name tho, not actually making it async)
        Task<List<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id); 
        //returns one movie, or null if no movie has that id (that's what the question mark means)
        Task<Movie> AddAsync(Movie movie);

        //a plain Task, no with <T> means no value comes back, but you can still await it
        Task UpdateAsync(Movie movie);

        Task DeleteAsync(Movie movie);
    }
}