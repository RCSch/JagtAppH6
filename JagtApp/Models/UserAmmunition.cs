using JagtApp.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JagtApp.Models
{
    public class UserAmmunition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CartridgeId { get; set; }

        [ForeignKey("CartridgeId")]
        public Cartridge AssociatedCartridge { get; set; }

        [Required]
        public int Quantity { get; set; } // Mængden af ammunition

        [Required(ErrorMessage = "Ejerens ID er påkrævet.")]
        [ForeignKey("Owner")]
        public string OwnerId { get; set; }

        public ApplicationUser Owner { get; set; }

        public UserAmmunition() { }

        public UserAmmunition(int cartridgeId, int quantity, string ownerId)
        {
            CartridgeId = cartridgeId;
            Quantity = quantity;
            OwnerId = ownerId;
        }
    }
}
