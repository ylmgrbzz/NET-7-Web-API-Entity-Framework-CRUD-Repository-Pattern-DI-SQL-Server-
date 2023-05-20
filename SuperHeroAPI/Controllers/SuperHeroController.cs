using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id = 1,
                    Name = "Batman",
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    Place = "Gotham City"
                },
                new SuperHero
                {
                    Id = 2,
                    Name = "Superman",
                    FirstName = "Clark",
                    LastName = "Kent",
                    Place = "Metropolis"
                },
                new SuperHero
                {
                    Id = 3,
                    Name = "Spiderman",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York"
                }
            };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {

            return Ok(superHeroes);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            //var heros = superHeroes.Find(x => x.Id == id);

            if (hero == null)
            {
                return NotFound("Hero is not exist");
            }


            return Ok(superHeroes);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return Ok(superHeroes);
        }

    }
}
