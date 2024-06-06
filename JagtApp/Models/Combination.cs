using JagtApp.Enums;

namespace JagtApp.Models
{
    public class Combination
    {
        public int Id { get; set; }
        public string CombiName { get; set; } //Lidt uklart om denne egentlig er nødvendig
        public GameRequirements LegalityRequirements { get; set; }
        public bool IsLegal { get; set; }
        public double V0 { get; set; } //Mundingshastighed
        public double E0 { get; set; } //Mundingsenergi
        public Cartridge AssociatedCartridge { get; set; }
        public double V100 { get; set; } //Hastighed v. 100 meter
        public double E100 { get; set; } //Anslagsenergi v. 100 meter
        public GameClass GameClass { get; set; }
        public Firearm AssociatedFirearm { get; set; }

        private double CalculateV100(double v0, Bullet bullet)
        {
            double dragCoefficient = 0.3; //Omtrentlig "drag coefficient"
            double densityAir = 1.225; //Loven er fuldstændig uklar på hvor der måles, så jeg har bestemt, at vi beregner med luftdensiteten ved havniveau (i kg/m^3).
            double bulletWeight = bullet.BulletWeight;
            double bc = bullet.BallisticCoefficient;
            double distance = 100; //Jeg vælger at hardcode'e afstanden til 100 meter, da det er den eneste afstand, der nævnes i lovteksten, men dette kunne ændres, hvis man ville bruge appen til andet og mere.

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
                return true;
            }

            if (gameClass == GameClass.Klasse1)
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
            else if (gameClass == GameClass.Klasse2)
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
            else if (gameClass == GameClass.Klasse3)
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
            else if (gameClass == GameClass.Klasse4)
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
            else if (gameClass == GameClass.Klasse5)
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
            Id = combiId;
            CombiName = combiName;
            AssociatedCartridge = cartridge;
            AssociatedFirearm = firearm;
            IsLegal = isLegal;
            V0 = v0;
            V100 = CalculateV100(v0, cartridge.AssociatedBullet);
            E0 = CalculateE0(v0, cartridge.AssociatedBullet);
            E100 = CalculateE100(V100, cartridge.AssociatedBullet);
        }
    }
}
