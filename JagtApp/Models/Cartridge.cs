using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JagtApp.Models
{
    public class Cartridge
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BulletId { get; set; }

        [ForeignKey("BulletId")]
        public Bullet? AssociatedBullet { get; set; }

        [Required]
        public int CaliberId { get; set; }

        [ForeignKey("CaliberId")]
        public Caliber? AssociatedCaliber { get; set; }

        [Required(ErrorMessage = "Navnet på patronen er påkrævet.")]
        [StringLength(100, ErrorMessage = "Navnet på patronen kan højst være 100 tegn.")]
        public string CartridgeName { get; set; }

        public Cartridge() { }

        public Cartridge(int cartridgeId, Caliber? associatedCaliber, Bullet? associatedBullet, string cartridgeName)
        {
            Id = cartridgeId;
            CaliberId = associatedCaliber?.Id ?? 0;
            BulletId = associatedBullet?.Id ?? 0;
            AssociatedCaliber = associatedCaliber;
            AssociatedBullet = associatedBullet;
            CartridgeName = cartridgeName;
        }
    }
}
