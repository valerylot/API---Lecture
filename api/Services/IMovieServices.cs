//this services interface is a list of jobs that our services must implement
//our services speak in DTO, so the controller NEVER touches the entity
using api.Dtos;
using api.Models;

namespace api.Services
{
    public interface IMovieServices
    {
        List<MovieResponseDto> GetAll();
        MovieResponseDto? GetById(int id);
        MovieResponseDto Create(CreateMovieDto dto);

        //this will return null if the movie doesn't exist
        MovieResponseDto? Update(int id, UpdateMovieDto dto);

        //returns true if the movie is deleted
        bool Delete(int id);
    }
}