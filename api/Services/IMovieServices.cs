//this services interface is a list of jobs that our services must implement
//our services speak in DTO, so the controller NEVER touches the entity
using api.Dtos;
using api.Models;

namespace api.Services
{
    public interface IMovieServices
    {

        //every method returns a task so the caller can await it
        //Task<bool> for example means a bool that will be ready later
        Task<List<MovieResponseDto>> GetAllAsync();
        Task<MovieResponseDto?> GetByIdAsync(int id);
        Task<MovieResponseDto> CreateAsync(CreateMovieDto dto);

        //this will return null if the movie doesn't exist
        Task<MovieResponseDto?> UpdateAsync(int id, UpdateMovieDto dto);

        //returns true if the movie is deleted
        Task<bool> DeleteAsync(int id);
    }
}