using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Suberheroes.Data;
using Suberheroes.Models;

namespace Suberheroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroesController : ControllerBase
    {
        private readonly DataContext _ctx;
        public SuperheroesController(DataContext ctx)
        {
            this._ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var heroes = await _ctx.superheroes.ToListAsync();
            return Ok(heroes);
        }
        [HttpGet("/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var hero = _ctx.superheroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound("this hero not exist !");
            }
            return Ok(hero);
        }
        [HttpPost]
        public async Task<IActionResult> Creat(Superhero suberheroes)
        {
            _ctx.superheroes.Add(suberheroes);
            _ctx.SaveChanges();

            return Ok("Created");
        }

        [HttpDelete("/{id}")]
        public IActionResult Delete(int id)
        {
            var hero = _ctx.superheroes.Find(id);
            if (hero != null)
            {
                _ctx.superheroes.Remove(hero);
                _ctx.SaveChanges();
                return Ok("Deelted");
            }
            return NotFound("this hero not exist !");

        }

        [HttpPut("/{id}")]
        public IActionResult Update(int id , Superhero superhero)
        {
            if (id != superhero.Id)
            {
                return BadRequest("Id not match superhero id");
            }
            var hero = _ctx.superheroes.Find(id);
            if (hero != null)
            {
                hero.FirstName = superhero.FirstName;

                _ctx.SaveChanges();
                return Ok("Updated");
            }
            return NotFound("this hero not exist !");

        }
    }

}
