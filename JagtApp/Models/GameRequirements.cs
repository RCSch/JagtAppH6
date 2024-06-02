using JagtApp.Enums;

namespace JagtApp.Models
{
    public class GameRequirements
    {
        public int Id { get; set; }
        public GameClass RequiredClass { get; set; }
        public AmmunitionRequirements AmmoRequirements { get; set; }
        public int MaxShotgunRange { get; set; }

        public GameRequirements(GameClass requiredClass, AmmunitionRequirements ammoRequirements, int maxShotgunRange)
        {
            RequiredClass = requiredClass;
            AmmoRequirements = ammoRequirements;
            MaxShotgunRange = maxShotgunRange;
        }

        public GameRequirements() { }
    }
}
