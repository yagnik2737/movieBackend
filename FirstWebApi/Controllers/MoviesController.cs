using FirstWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesContext _smsContext;
        public MoviesController(MoviesContext context)
        {
            this._smsContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudent()
        {
            var Result = await _smsContext.MovieLists.ToListAsync();
            return Ok(Result);
        }

        [HttpGet("{movieID}")]
        public async Task<IActionResult> GetMovieId(int? movieID)
        {
            var result = await this._smsContext.MovieLists.Where(ar => ar.Id == movieID).FirstOrDefaultAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> createMovie(MovieList newStudent)
        {
            await _smsContext.MovieLists.AddAsync(newStudent);
            _smsContext.SaveChanges();
            return Ok(newStudent);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovies([FromQuery] MovieList std)
        {
            if (std.Id > 0)
            {
                _smsContext.Entry(std).State = EntityState.Modified;
                await _smsContext.SaveChangesAsync();
                return Ok(new { massage = " successfully updated" });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovies(int movieID)
        {
            if (movieID > 0)
            {
                var data = _smsContext.MovieLists.Where(ar => ar.Id == movieID).FirstOrDefault();
                if (data != null)
                {
                    _smsContext.MovieLists.Remove(data);
                    await _smsContext.SaveChangesAsync();
                }
                return Ok(new { massage = " successfully Deleted" });
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
