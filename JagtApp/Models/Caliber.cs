using System.ComponentModel.DataAnnotations;

namespace JagtApp.Models
{
    public class Caliber
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kalibernavn er påkrævet.")]
        [StringLength(50, ErrorMessage = "Kaliber navnet kan højst være 50 tegn.")]
        public string CaliberName { get; set; } // F.eks. "7x64 Brenneke"

        [Range(0.1, 25.0, ErrorMessage = "Diameteren af kaliberen skal være mellem 0,1 og 25 millimeter.")]
        public double CaliberDiameter { get; set; } // Denne variabel skal bruges til at sikre, at man kun kan vælge kugler (bullets) med den korrekte bredde.

        public Caliber() { }

        public Caliber(int caliberId, string caliberName, double caliberDiameter)
        {
            Id = caliberId;
            CaliberName = caliberName;
            CaliberDiameter = caliberDiameter;
        }
    }
}
