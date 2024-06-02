using JagtApp.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JagtApp.Models
{
    public class AllowedFirearmType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GameRequirementId { get; set; }

        [ForeignKey("GameRequirementId")]
        public GameRequirements GameRequirement { get; set; }

        [Required]
        public FirearmType FirearmType { get; set; }

        public AllowedFirearmType() { }

        public AllowedFirearmType(int gameRequirementId, FirearmType firearmType)
        {
            GameRequirementId = gameRequirementId;
            FirearmType = firearmType;
        }
    }
}
