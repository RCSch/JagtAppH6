namespace JagtApp.Models
{
    public class AmmunitionRequirements
    {
        public int Id { get; set; }
        public double MinimumCaliber { get; set; }
        public double MinimumE100 { get; set; }
        public double MinimumE0 { get; set; }
        public double MinimumV0 { get; set; }
        public bool RequiresExpandingProjectile { get; set; }
        public bool LeadFree { get; set; }
        public int MinShotSize { get; set; } //Kun relevant når jeg engang får tilføjet haglvåben
        public int MaxShotSize { get; set; } //Haglstørrelse er en tosset størrelse, fordi det går baglæns - man skal tænke det som en bræk. Ergo er 1 større end 3. 

        public AmmunitionRequirements() { } //Nødvendig for Entity Framework. 
        public AmmunitionRequirements(double minCaliber, double minE100, double minE0, double minV0, bool requiresExpandingProjectile, bool leadFree)
        {
            MinimumCaliber = minCaliber;
            MinimumE100 = minE100;
            MinimumE0 = minE0;
            MinimumV0 = minV0;
            RequiresExpandingProjectile = requiresExpandingProjectile;
            LeadFree = leadFree;
        }
    }
}
