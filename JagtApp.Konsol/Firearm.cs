using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JagtApp.Konsol
{
    public class Firearm
    {
        public int FAId;
        public string FAName;
        public string FABrand;
        public double BarrelLength;
        public FirearmType Type { get; set; } // Add this property
        public List<Caliber> SupportedCalibers { get; set; }

        public Firearm()
        {
        }


        public Firearm(int fAId, string fAName, string fABrand, double barrelLength, FirearmType type, List<Caliber> supportedCalibers)
        {
            FAId = fAId;
            FAName = fAName;
            FABrand = fABrand;
            BarrelLength = barrelLength;
            Type = type; // Initialize the Type property
            SupportedCalibers = supportedCalibers;
        }
    }
    public enum FirearmType
    {
        Rifle,
        Shotgun,
        Handgun,
        // Add other firearm types as needed
    }
}
