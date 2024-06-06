using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JagtApp.Konsol
{
    public class AmmunitionRequirements
    {
        public double MinimumCaliber { get; set; }
        public double MinimumEnergy { get; set; }
        public double MinimumE100 { get; set; }
        public double MinimumE0 { get; set; }
        public double MinimumV0 { get; set; }
        public bool RequiresExpandingProjectile { get; set; }
        public bool LeadFree { get; set; }
        public int MinShotSize { get; set; }  // For shotgun ammunition
        public int MaxShotSize { get; set; }  // For shotgun ammunition

        public AmmunitionRequirements(double minCaliber, double minEnergy, double minE100, double minE0, double minV0, bool requiresExpandingProjectile, bool leadFree)
        {
            MinimumCaliber = minCaliber;
            MinimumEnergy = minEnergy;
            MinimumE100 = minE100;
            MinimumE0 = minE0;
            MinimumV0 = minV0;
            RequiresExpandingProjectile = requiresExpandingProjectile;
            LeadFree = leadFree;
        }
    }
}
