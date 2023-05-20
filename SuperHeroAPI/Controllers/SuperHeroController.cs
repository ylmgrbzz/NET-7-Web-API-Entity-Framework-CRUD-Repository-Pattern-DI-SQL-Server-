using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = await _superHeroService.GetAllHeroes();
            return Ok(heroes);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = await _superHeroService.GetSingleHero(id);
            if (hero == null)
            {
                return NotFound("hero not found");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var heroToAdd = await _superHeroService.AddHero(hero);
            return Ok(heroToAdd);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero hero)
        {
            var heroToUpdate = await _superHeroService.UpdateHero(id, hero);
            if (heroToUpdate == null)
            {
                return NotFound("hero not found");
            }
            return Ok(heroToUpdate);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var heroToDelete = await _superHeroService.DeleteHero(id);
            if (heroToDelete == null)
            {
                return NotFound("hero not found");
            }
            return Ok(heroToDelete);
        }
    }
}
