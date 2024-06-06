using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JagtApp.Konsol;

namespace JagtApp.Konsol
{
        public class GameRequirements
    {
        public GameClass RequiredClass { get; set; }
        public AmmunitionRequirements AmmoRequirements { get; set; }
        public List<FirearmType> AllowedFirearmTypes { get; set; }
        public int MaxShotgunRange { get; set; }

        public GameRequirements(GameClass requiredClass, AmmunitionRequirements ammoRequirements, List<FirearmType> allowedFirearmTypes)
        {
            RequiredClass = requiredClass;
            AmmoRequirements = ammoRequirements;
            AllowedFirearmTypes = allowedFirearmTypes;
        }

        public GameRequirements(GameClass requiredClass, AmmunitionRequirements ammoRequirements, List<FirearmType> allowedFirearmTypes, int maxShotgunRange)
        {
            RequiredClass = requiredClass;
            AmmoRequirements = ammoRequirements;
            AllowedFirearmTypes = allowedFirearmTypes;
            MaxShotgunRange = maxShotgunRange;
        }

        public GameRequirements() { }
    }
}