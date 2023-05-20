using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-2Q3K0QO\SQLEXPRESS;Database=SuperHeroAPI;Trusted_Connection=True;");
        }
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
