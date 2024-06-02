using JagtApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JagtApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        // DbSet properties for models
        public DbSet<AmmunitionRequirements> AmmunitionRequirements { get; set; }
        public DbSet<Bullet> Bullets { get; set; }
        public DbSet<Caliber> Calibers { get; set; }
        public DbSet<Cartridge> Cartridges { get; set; }
        public DbSet<Combination> Combinations { get; set; }
        public DbSet<Firearm> Firearms { get; set; }
        public DbSet<GameAnimal> GameAnimals { get; set; }
        public DbSet<GameRequirements> GameRequirements { get; set; }
        public DbSet<HuntingSeason> HuntingSeasons { get; set; }
    }
}
