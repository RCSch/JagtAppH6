using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JagtApp.Konsol
{
    public class Combination
    {
        public int Id { get; set; }
        public string CombiName { get; set; }
        public GameRequirements LegalityRequirements { get; set; }
        public double V0 { get; set; } // Muzzle velocity
        public double E0 { get; set; } //Muzzle energy
        public Cartridge AssociatedCartridge { get; set; }
        public double V100 { get; set; } // Velocity at 100 meters
        public double E100 { get; set; } // Energy at 100 meters
        public Firearm AssociatedFirearm { get; set; } // Associated firearm
        public GameClass GameClass { get; set; } // Game class

        private double CalculateV100(double v0, Bullet bullet)
        {
            double dragCoefficient = 0.3; // Approximate drag coefficient
            double densityAir = 1.225; // Air density at sea level (kg/m^3)
            double bulletWeight = bullet.BulletWeight;
            double bc = bullet.BallisticCoefficient;
            double distance = 100; // Assuming distance is in meters

            double v100 = Math.Sqrt(v0 * v0 - (2 * dragCoefficient * bulletWeight * densityAir * distance)) /
                          (1 + (0.5 * dragCoefficient * bulletWeight * densityAir * distance) / (bc * v0));

            return v100;
        }

        private double CalculateE0(double v0, Bullet bullet)
        {
            double bulletWeight = bullet.BulletWeight / 1000;
            return v0 * v0 * bulletWeight / 2;
        }

        private double CalculateE100(double v100, Bullet bullet)
        {
            double bulletWeight = bullet.BulletWeight / 1000;
            return v100 * v100 * bulletWeight / 2;
        }

       

        public Combination() { }

        public Combination(int combiId, string combiName, Cartridge cartridge, Firearm firearm, double v0)
        {
            Id = combiId;
            CombiName = combiName;
            AssociatedCartridge = cartridge;
            AssociatedFirearm = firearm;
            V0 = v0;
            V100 = CalculateV100(v0, cartridge.AssociatedBullet);
            E0 = CalculateE0(v0, cartridge.AssociatedBullet);
            E100 = CalculateE100(V100, cartridge.AssociatedBullet);
        }

        public GameClass CalculateHighestLegalGameClass()
        {
            if (AssociatedCartridge.AssociatedBullet.LeadFree == false)
            {
                return GameClass.Ulovlig;
            }

            if (E100 >= 2000 && AssociatedCartridge.AssociatedBullet.BulletDiameter >= 6 && AssociatedCartridge.AssociatedBullet.Expanding)
            {
                return GameClass.Class1;
            }
            else if (E100 >= 800 && AssociatedCartridge.AssociatedBullet.BulletDiameter >= 5.5 && AssociatedCartridge.AssociatedBullet.Expanding)
            {
                return GameClass.Class2;
            }
            else if (E100 >= 175)
            {
                return GameClass.Class3;
            }
            else if (E0 >= 150)
            {
                return GameClass.Class4;
            }
            else if (V0 >= 200)
            {
                return GameClass.Class5;
            }
            else
            {
                return GameClass.Ulovlig;
            }
        }
    }
}
