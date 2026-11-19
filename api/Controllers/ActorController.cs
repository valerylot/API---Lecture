using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly IActorServices _services;
        public ActorController(IActorServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorResponseDto>>> GetAll()
        {
            return Ok(await _services.GetAllAsync());
        }

        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult<ActorResponseDto>> GetById(int id)
        {
            ActorResponseDto? actor = await _services.GetByIdAsync(id);

            if(actor == null)
            {
                return NotFound($"No actor found with ID {id}");
            }
            return Ok(actor);
        }

        [HttpPost("AddActor")]
        public async Task<ActionResult<ActorResponseDto>> AddActor([FromBody]CreateActorDto dto)
        {
            //this gathers a list of all the actors, so that we can do the isExisting check of actors in db
            List<ActorResponseDto> actors = await _services.GetAllAsync();

            bool isExisting = actors.Any(a => a.Name == dto.Name);

            if (isExisting)
            {
                return Conflict($"The actor {dto.Name} is already in the database.");
            }
            
            ActorResponseDto actor = await _services.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new{id = actor.Id}, actor);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<ActorResponseDto>> Update(int id, [FromBody]UpdateActorDto dto)
        {
            ActorResponseDto? actor = await _services.UpdateAsync(id, dto);

            if(actor is null)
            {
                return NotFound($"No actor found with ID {id}");
            }
            return Ok(actor);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _services.DeleteAsync(id);

            if (!isDeleted)
            {
                return NotFound($"No actor found with ID {id}");
            }
            return NoContent();
        }
    }
}