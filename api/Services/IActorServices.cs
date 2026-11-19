using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Migrations;

namespace api.Services
{
    public interface IActorServices
    {
        Task<List<ActorResponseDto>> GetAllAsync();
        Task<ActorResponseDto?> GetByIdAsync(int id);
        Task<ActorResponseDto> CreateAsync(CreateActorDto dto);
        Task<ActorResponseDto?> UpdateAsync(int id, UpdateActorDto dto);
        Task<bool> DeleteAsync (int id);
    }
}