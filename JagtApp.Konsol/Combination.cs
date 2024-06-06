using System;
using System.Collections.Generic;

namespace JagtApp.Konsol
{
    public class Combination
    {
        public int CombiId { get; set; }
        public string CombiName { get; set; }
        public GameRequirements LegalityRequirements { get; set; }
        public bool IsLegal { get; set; }
        public double V0 { get; set; } // Muzzle velocity
        public double E0 { get; set; } //Muzzle energy
        public Cartridge AssociatedCartridge { get; set; }
        public double V100 { get; set; } // Velocity at 100 meters
        public double E100 { get; set; } // Energy at 100 meters
        public Shell AssociatedShell { get; set; }
        public GameClass GameClass { get; set; } // Game class for shotguns
        public double MaxRange { get; set; } // Maximum range for shotguns
        public Firearm AssociatedFirearm { get; set; } // Associated firearm

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

        public bool IsLegalForGameClass(GameClass gameClass)
        {
            if (LegalityRequirements == null)
            {
                // Legality requirements not defined, so by default legal
                return true;
            }

            if (gameClass == GameClass.Class1)
            {
                if (AssociatedCartridge != null)
                {
                    double bulletDiameter = AssociatedCartridge.AssociatedBullet.BulletDiameter;
                    double bulletWeightKg = AssociatedCartridge.AssociatedBullet.BulletWeight / 1000.0;
                    double v100 = CalculateV100(V0, AssociatedCartridge.AssociatedBullet);
                    E100 = v100 * v100 * bulletWeightKg;

                    if (bulletDiameter >= LegalityRequirements.AmmoRequirements.MinimumCaliber
                        && E100 >= LegalityRequirements.AmmoRequirements.MinimumE100)
                    {
                        return true;
                    }
                }
            }
            else if (gameClass == GameClass.Class2)
            {
                if (AssociatedCartridge != null)
                {
                    double bulletDiameter = AssociatedCartridge.AssociatedBullet.BulletDiameter;
                    double bulletWeightKg = AssociatedCartridge.AssociatedBullet.BulletWeight / 1000.0;
                    double v100 = CalculateV100(V0, AssociatedCartridge.AssociatedBullet);
                    E100 = v100 * v100 * bulletWeightKg;

                    if (bulletDiameter >= LegalityRequirements.AmmoRequirements.MinimumCaliber
                        && E100 >= LegalityRequirements.AmmoRequirements.MinimumE100)
                    {
                        return true;
                    }
                }
            }
            else if (gameClass == GameClass.Class3)
            {
                if (AssociatedCartridge != null)
                {
                    double bulletWeightKg = AssociatedCartridge.AssociatedBullet.BulletWeight / 1000.0;
                    double v100 = CalculateV100(V0, AssociatedCartridge.AssociatedBullet);
                    E100 = v100 * v100 * bulletWeightKg;

                    if (E100 >= LegalityRequirements.AmmoRequirements.MinimumE100)
                    {
                        return true;
                    }
                }
            }
            else if (gameClass == GameClass.Class4)
            {
                if (AssociatedCartridge != null)
                {
                    E0 = V0 * V0 * AssociatedCartridge.AssociatedBullet.BulletWeight;

                    if (E0 >= LegalityRequirements.AmmoRequirements.MinimumE0)
                    {
                        return true;
                    }
                }
            }
            else if (gameClass == GameClass.Class5)
            {
                if (AssociatedCartridge != null)
                {
                    if (V0 >= LegalityRequirements.AmmoRequirements.MinimumV0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public Combination() { }

        public Combination(int combiId, string combiName, Cartridge cartridge, Firearm firearm, bool isLegal, double v0)
        {
            CombiId = combiId;
            CombiName = combiName;
            AssociatedCartridge = cartridge;
            AssociatedFirearm = firearm;
            IsLegal = isLegal;
            V0 = v0;
            V100 = CalculateV100(v0, cartridge.AssociatedBullet);
            E0 = CalculateE0(v0, cartridge.AssociatedBullet);
            E100 = CalculateE100(V100, cartridge.AssociatedBullet);
        }

        public Combination(int combiId, string combiName, Shell shell, Firearm firearm, bool isLegal, double v0, GameClass gameClass)
        {
            CombiId = combiId;
            CombiName = combiName;
            AssociatedShell = shell;
            IsLegal = isLegal;
            V0 = v0;
            GameClass = gameClass;

            // Set the maximum range based on game class
            switch (gameClass)
            {
                case GameClass.Class2:
                    MaxRange = 20; // Class 2 game can be taken up to 20 meters
                    break;
                case GameClass.Class3:
                    MaxRange = 25; // Class 3 game can be taken up to 25 meters
                    break;
                case GameClass.Class4:
                case GameClass.Class5:
                    MaxRange = 30; // Class 4 and 5 game can be taken up to 30 meters
                    break;
                default:
                    MaxRange = 0; // Unknown game class
                    break;
            }

            AssociatedFirearm = firearm;
        }
    }
}
