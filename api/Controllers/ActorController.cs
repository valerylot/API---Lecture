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
        public ActionResult<List<ActorResponseDto>> GetAll()
        {
            return Ok(_services.GetAll());
        }

        [HttpGet("getbyid/{id}")]
        public ActionResult<ActorResponseDto> GetById(int id)
        {
            ActorResponseDto? actor = _services.GetById(id);

            if(actor == null)
            {
                return NotFound();
            }
            return Ok(actor);
        }

        [HttpPost("AddActor")]
        public ActionResult<ActorResponseDto> AddActor([FromBody]CreateActorDto dto)
        {
            ActorResponseDto actor = _services.Create(dto);

            bool isExisting = _services.GetAll().Any(a => a.Name == actor.Name);
            if (isExisting)
            {
                return Conflict($"The actor {actor.Name} is already in the database.");
            }

            return CreatedAtAction(nameof(GetById), new{id = actor.Id}, actor);
        }

        [HttpPut("update/{id}")]
        public ActionResult<ActorResponseDto> Update(int id, [FromBody]UpdateActorDto dto)
        {
            ActorResponseDto? actor = _services.Update(id, dto);

            if(actor is null)
            {
                return NotFound();
            }
            return Ok(actor);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            bool isDeleted = _services.Delete(id);

            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}