using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Migrations;
using api.Models;
using api.Repositories;

namespace api.Services
{
    public class ActorServices : IActorServices
    {
        private readonly IActorRepository _repository;
        public ActorServices(IActorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActorResponseDto> CreateAsync(CreateActorDto dto)
        {
            Actor actor = new Actor();
            actor.Name = dto.Name;
            actor.Country = dto.Country;
            actor.BirthYear = dto.BirthYear;

            Actor saved = await _repository.AddAsync(actor);
            return ToDto(saved);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Actor? actor = await _repository.GetByIdAsync(id);

            if (actor is null)
            {
                return false;
            }

            await _repository.DeleteAsync(actor);
            return true;
        }

        public async Task<List<ActorResponseDto>> GetAllAsync()
        {
            List<Actor> actors = await _repository.GetAllAsync();
            return actors.Select(ToDto).ToList();
        }

        public async Task<ActorResponseDto?> GetByIdAsync(int id)
        {
            Actor? actor = await _repository.GetByIdAsync(id);

            if (actor is null)
            {
                return null;
            }
            return ToDto(actor);
        }

        public async Task<ActorResponseDto?> UpdateAsync(int id, UpdateActorDto dto)
        {
            Actor? actor = await _repository.GetByIdAsync(id);
            if (actor is null)
            {
                return null;
            }

            actor.Name = dto.Name;
            actor.Country = dto.Country;
            actor.BirthYear = dto.BirthYear;

            actor.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(actor);
            return ToDto(actor);
        }

        //HELPER METHOD
        private static ActorResponseDto ToDto(Actor actor)
        {
            return new ActorResponseDto
            {
                Id = actor.Id,
                Name = actor.Name,
                Country = actor.Country,
                BirthYear = actor.BirthYear
            };
        }
    }
}