namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
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

        public List<SuperHero> AddHero(SuperHero hero)
        {

            superHeroes.Add(hero);
            return superHeroes;
        }
        public List<SuperHero> DeleteHero(int id)
        {
            var heroToDelete = superHeroes.Find(x => x.Id == id);
            if (heroToDelete == null)
            {
                return null;
            }
            superHeroes.Remove(heroToDelete);
            return superHeroes;

        }

        public List<SuperHero> GetAllHeroes()
        {
            return superHeroes;
        }

        public SuperHero GetSingleHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            //var heros = superHeroes.Find(x => x.Id == id);

            if (hero == null)
            {
                return null;
            }
            return hero;
        }

        public List<SuperHero> UpdateHero(int id, SuperHero hero)
        {
            var heroToUpdate = superHeroes.Find(x => x.Id == id);
            if (heroToUpdate == null)
            {
                return null;
            }
            heroToUpdate.Name = hero.Name;
            heroToUpdate.FirstName = hero.FirstName;
            heroToUpdate.LastName = hero.LastName;
            heroToUpdate.Place = hero.Place;
            return superHeroes;
        }
    }
}
