using System.ComponentModel.DataAnnotations;

namespace JagtApp.Models
{
    public class Bullet
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Navnet på kuglen er påkrævet.")]
        [StringLength(100, ErrorMessage = "Navnet på kuglen kan højst være 100 tegn.")]
        public string BulletName { get; set; } //f.eks. "RWS 7mm 10,8 gram HIT"
        
        [StringLength(100, ErrorMessage = "Beskrivelsen af kuglen kan højst være 100 tegn.")]
        public string BulletDescription { get; set; } //f.eks. "Ekspanderende, blyfri kugle på XX gram"

        [Range(0.1, 100.0, ErrorMessage = "Vægten af kuglen skal være mellem 0,1 og 100 gram.")]
        public double BulletWeight { get; set; } //Anføres i gram, f.eks. 10.8
        
        [Range(0.1, 25.0, ErrorMessage = "Diameteren af kuglen skal være mellem 0,1 og 25 millimeter.")]
        public double BulletDiameter { get; set; } //anføres i millimeter, ideelt set med to decimaler, f.eks. 7.24
        public bool LeadFree { get; set; } //Det er lovligt at besidde blyholdig ammunition til banebrug, men ikke til jagt.
        public bool Expanding { get; set; } //Vildt i klasse 1 eller 2 kræver ekspanderende eller fragmenterende ammunition. Da der ikke skelnes, har jeg kun én variabel. 

        public double SectionalDensity => BulletWeight / Math.Pow(BulletDiameter, 2); 
        public double BallisticCoefficient => (2 * BulletWeight) / (0.3 * 1.225 * Math.Pow(BulletDiameter, 2));

        public Bullet() { }
        public Bullet(int bulletId, string bulletName, string bulletDescription, double bulletWeight, double bulletDiameter, bool leadFree, bool expanding)
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
