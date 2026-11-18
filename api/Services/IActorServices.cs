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
        List<ActorResponseDto> GetAll();
        ActorResponseDto? GetById(int id);
        ActorResponseDto Create(CreateActorDto dto);
        ActorResponseDto? Update(int id, UpdateActorDto dto);
        bool Delete (int id);
    }
}