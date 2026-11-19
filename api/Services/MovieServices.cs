//our services layer is the middle man between our controller and respository
//it maps our Dtos to entities (and back) and this is where our rules live
using api.Dtos;
using api.Models;
using api.Repositories;

namespace api.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly IMovieRepository _repository;

        //DI: in our Program.cs says IMovieRepository means MovieRepository
        public MovieServices(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<MovieResponseDto> CreateAsync(CreateMovieDto dto)
        {
            Movie movie = new Movie();
            movie.Title = dto.Title;
            movie.Director = dto.Director;
            movie.Rating = dto.Rating;
            movie.ReleaseYear = dto.ReleaseYear;

            Movie saved = await _repository.AddAsync(movie);
            //sending back the same movie but now with an Id
            return ToDto(saved);
        }


        //This method awaits the repository so it HAS to be async and return a Task too
        //Once the bottom layer is async, every layer that calls it becomes async as well
        public async Task<List<MovieResponseDto>> GetAllAsync()
        {

            //await waits for the db without blocking the thread
            List<Movie> movies = await _repository.GetAllAsync();

            //turning every Movie entity into a MovieResponseDto
            return movies.Select(ToDto).ToList();
        }

        public async Task<MovieResponseDto?> GetByIdAsync(int id)
        {
            Movie? movie = await _repository.GetByIdAsync(id);

            //if there is no movie, pass null up to the controller
            if (movie is null)
            {
                return null;
            }
            return ToDto(movie);
        }

        public async Task<MovieResponseDto?> UpdateAsync(int id, UpdateMovieDto dto)
        {
            //we must first load the movie from the database
            Movie? movie = await _repository.GetByIdAsync(id);

            //if our id isn't in the db, return null
            if (movie is null)
            {
                return null;
            }

            movie.Title = dto.Title;
            movie.Director = dto.Director;
            movie.Rating = dto.Rating;
            movie.ReleaseYear = dto.ReleaseYear;

            //Record when this movie is last changed
            movie.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(movie);
            return ToDto(movie);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Movie? movie = await _repository.GetByIdAsync(id);

            if (movie is null)
            {
                //false tells our controller no movie was found, send 404
                return false;
            }

            await _repository.DeleteAsync(movie);
            return true;

        }

        //We will create a Helper Function that maps our Dtos
        //Private because it doesn't need to be accessed outside of our class
        //Static because it doesn't have access to instance data
        //Movie models passed in as parameter because we're converting the model to Dto
        private static MovieResponseDto ToDto(Movie movie)
        {
            // MovieResponseDto dto = new MovieResponseDto();
            // dto.Id = movie.Id;
            // dto.Director = movie.Director;
            // dto.Rating = movie.Rating;
            // dto.ReleaseYear = movie.ReleaseYear;
            // dto.Title = movie.Title;

            // return dto;

            // ^ old way to do it V new way to do it

            return new MovieResponseDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = movie.Director,
                ReleaseYear = movie.ReleaseYear,
                Rating = movie.Rating
            };
        }
    }
}