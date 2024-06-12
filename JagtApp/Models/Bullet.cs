using System.ComponentModel.DataAnnotations;

namespace JagtApp.Models
{
    public class Bullet
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Navnet på kuglen er påkrævet.")]
        [StringLength(100, ErrorMessage = "Navnet på kuglen kan højst være 100 tegn.")]
        public string BulletName { get; set; }

        [StringLength(100, ErrorMessage = "Beskrivelsen af kuglen kan højst være 100 tegn.")]
        public string? BulletDescription { get; set; }

        [Range(0.1, 100000.0, ErrorMessage = "Vægten af kuglen skal være mellem 0,1 gram og 100 kilogram.")]
        public double BulletWeight { get; set; }

        [Range(0.1, 25.0, ErrorMessage = "Diameteren af kuglen skal være mellem 0,1 og 25 millimeter.")]
        public double BulletDiameter { get; set; }
        public bool LeadFree { get; set; }
        public bool Expanding { get; set; }

        public double SectionalDensity => BulletWeight / Math.Pow(BulletDiameter, 2);
        public double BallisticCoefficient => (2 * BulletWeight) / (0.3 * 1.225 * Math.Pow(BulletDiameter, 2));

        public Bullet() { }
        public Bullet(int bulletId, string bulletName, string? bulletDescription, double bulletWeight, double bulletDiameter, bool leadFree, bool expanding)
        {
            Id = bulletId;
            BulletName = bulletName;
            BulletDescription = bulletDescription;
            BulletWeight = bulletWeight;
            BulletDiameter = bulletDiameter;
            LeadFree = leadFree;
            Expanding = expanding;
        }
    }
}
