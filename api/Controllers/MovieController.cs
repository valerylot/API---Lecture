
using api.Dtos;
using api.Services;
using Microsoft.AspNetCore.Mvc;

//our controller layer: takes in HTTP request and sends back HTTP responses (aka status codes)
//it only talks to our services, NEVER to our DB


namespace api.Controllers
{
    [ApiController] //This line turns on our API features like Automatic 400 Status code
    [Route("api/[controller]")] //makes every URL endpoint start with api/movie
    public class MovieController : ControllerBase
    {
        private readonly IMovieServices _services;
        public MovieController(IMovieServices services)
        {
            _services = services;
        }


        //async Tasks<...>: the action awaits the service, so it returns a task
        //ASP.NET Core awaits the Task for us, then sends the response       
        [HttpGet]
        public async Task<ActionResult<List<MovieResponseDto>>> GetAll()
        {
            //await frees this thread while the database works
            //so the server can handle other requests in the meantime
            return Ok(await _services.GetAllAsync());
        }

        //get api/movie/getbyid/{id}
        //return 200 with the movie or 400 if no movie is in the db
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<MovieResponseDto>> GetById(int id)
        {
            MovieResponseDto? movie = await _services.GetByIdAsync(id);

            if(movie == null)
            {
                return NotFound(); //sends a 404 response
            }
            return Ok(movie);
        }

        //Post api/movie/addmovie
        //JSON body becomes our CreateMovieDto
        //return 201 created with the new movie, plus our location headers
        [HttpPost("AddMovie")]
        public async Task<ActionResult<MovieResponseDto>> AddMovie([FromBody]CreateMovieDto dto)
        {
            MovieResponseDto movie = await _services.CreateAsync(dto);

            //created at action sends 201, it uses getby id action and the new id to build the location headers
            return CreatedAtAction(nameof(GetById), new{id = movie.Id}, movie);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<MovieResponseDto>> Update(int id, [FromBody] UpdateMovieDto dto)
        {
            MovieResponseDto? movie = await _services.UpdateAsync(id, dto);

            if(movie is null)
            {
                return NotFound(); //movie is not found in our database, send a 404
            }

            return Ok(movie);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _services.DeleteAsync(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            //this worked and there's nothing to send back 204 status codes
            return NoContent();
        }
    }
}