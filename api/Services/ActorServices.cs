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

        public ActorResponseDto Create(CreateActorDto dto)
        {
            Actor actor = new Actor();
            actor.Name = dto.Name;
            actor.Country = dto.Country;
            actor.BirthYear = dto.BirthYear;

            Actor saved = _repository.Add(actor);
            return ToDto(saved);
        }

        public bool Delete(int id)
        {
            Actor? actor = _repository.GetById(id);

            if(actor is null)
            {
                return false;
            }

            _repository.Delete(actor);
            return true;
        }

        public List<ActorResponseDto> GetAll()
        {
            List<Actor> actors = _repository.GetAll();
            return actors.Select(ToDto).ToList();
        }

        public ActorResponseDto? GetById(int id)
        {
            Actor? actor = _repository.GetById(id);

            if(actor is null)
            {
                return null;
            }
            return ToDto(actor);
        }

        public ActorResponseDto? Update(int id, UpdateActorDto dto)
        {
            Actor? actor = _repository.GetById(id);
            if(actor is null)
            {
                return null;
            }

            actor.Name = dto.Name;
            actor.Country = dto.Country;
            actor.BirthYear = dto.BirthYear;

            actor.UpdatedAt = DateTime.UtcNow;

            _repository.Update(actor);
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