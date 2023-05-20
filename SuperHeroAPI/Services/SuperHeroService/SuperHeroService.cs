using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private static List<SuperHero> hero = new List<SuperHero>
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

        private readonly DataContext _context;
        public SuperHeroService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.AddAsync(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }
        public async Task<List<SuperHero>> DeleteHero(int id)
        {
            var heroToDelete = await _context.SuperHeroes.FindAsync(id);
            if (heroToDelete == null)
            {
                return null;
            }
            _context.SuperHeroes.Remove(heroToDelete);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }
        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<List<SuperHero>> UpdateHero(int id, SuperHero hero)
        {
            var heroToUpdate = SuperHeroService.hero.Find(x => x.Id == id);
            if (heroToUpdate == null)
            {
                return null;
            }
            heroToUpdate.Name = hero.Name;
            heroToUpdate.FirstName = hero.FirstName;
            heroToUpdate.LastName = hero.LastName;
            heroToUpdate.Place = hero.Place;
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }


        public async Task<List<SuperHero>> GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            return await _context.SuperHeroes.ToListAsync();
        }

    }
}
