using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JagtApp.Models;

namespace JagtApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GameAnimal> GameAnimals { get; set; }
        public DbSet<HuntingSeason> HuntingSeasons { get; set; }
        public DbSet<AmmunitionRequirements> AmmunitionRequirements { get; set; }
        public DbSet<AllowedFirearmType> AllowedFirearmTypes { get; set; }
        public DbSet<Bullet> Bullets { get; set; }
        public DbSet<Caliber> Calibers { get; set; }
        public DbSet<Cartridge> Cartridges { get; set; }
        public DbSet<UserAmmunition> UserAmmunitions { get; set; }
        public DbSet<Firearm> Firearms { get; set; }
        public DbSet<Combination> Combinations { get; set; }
        public DbSet<GameRequirements> GameRequirements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Eventuelle yderligere konfigurationer kan tilføjes her
        }
    }
}
