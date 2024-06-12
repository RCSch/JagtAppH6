using JagtApp.Enums;
using JagtApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Combination
{
    [Key]
    public int Id { get; set; }

    [StringLength(100, ErrorMessage = "Navnet på kombinationen kan højst være 100 tegn.")]
    public string? CombiName { get; set; }

    public GameRequirements? LegalityRequirements { get; set; }

    public bool IsLegal { get; set; }

    [Range(0.1, 10000.0, ErrorMessage = "Mundingshastigheden (V0) skal være mellem 0,1 og 10000 meter i sekundet.")]
    public double V0 { get; set; }

    public double E0 { get; set; }

    public Cartridge? AssociatedCartridge { get; set; }

    public double V100 { get; set; }

    public double E100 { get; set; }

    public GameClass GameClass { get; set; }

    public Firearm? AssociatedFirearm { get; set; }

    private double CalculateV100(double v0, Bullet bullet)
    {
        double dragCoefficient = 0.3;
        double densityAir = 1.225;
        double bulletWeight = bullet.BulletWeight;
        double bc = bullet.BallisticCoefficient;
        double distance = 100;

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

    public GameClass CalculateHighestLegalGameClass()
    {
        if (LegalityRequirements == null)
        {
            return GameClass.Ulovlig;
        }

        if (IsLegalForGameClass(GameClass.Klasse1))
        {
            return GameClass.Klasse1;
        }
        else if (IsLegalForGameClass(GameClass.Klasse2))
        {
            return GameClass.Klasse2;
        }
        else if (IsLegalForGameClass(GameClass.Klasse3))
        {
            return GameClass.Klasse3;
        }
        else if (IsLegalForGameClass(GameClass.Klasse4))
        {
            return GameClass.Klasse4;
        }
        else if (IsLegalForGameClass(GameClass.Klasse5))
        {
            return GameClass.Klasse5;
        }
        else
        {
            return GameClass.Ulovlig;
        }
    }

    private bool IsLegalForGameClass(GameClass gameClass)
    {
        if (gameClass == GameClass.Klasse1)
        {
            if (AssociatedCartridge != null)
            {
                double bulletDiameter = AssociatedCartridge.AssociatedBullet.BulletDiameter;
                double bulletWeightKg = AssociatedCartridge.AssociatedBullet.BulletWeight / 1000.0;
                double v100 = CalculateV100(V0, AssociatedCartridge.AssociatedBullet);
                E100 = v100 * v100 * bulletWeightKg;

                if (bulletDiameter >= LegalityRequirements?.AmmoRequirements.MinimumCaliber
                    && E100 >= LegalityRequirements?.AmmoRequirements.MinimumE100)
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

                if (bulletDiameter >= LegalityRequirements?.AmmoRequirements.MinimumCaliber
                    && E100 >= LegalityRequirements?.AmmoRequirements.MinimumE100)
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

                if (E100 >= LegalityRequirements?.AmmoRequirements.MinimumE100)
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

                if (E0 >= LegalityRequirements?.AmmoRequirements.MinimumE0)
                {
                    return true;
                }
            }
        }
        else if (gameClass == GameClass.Klasse5)
        {
            if (AssociatedCartridge != null)
            {
                if (V0 >= LegalityRequirements?.AmmoRequirements.MinimumV0)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public Combination() { }

    public Combination(int combiId, string? combiName, Cartridge? cartridge, Firearm? firearm, bool isLegal, double v0)
    {
        Id = combiId;
        CombiName = combiName;
        AssociatedCartridge = cartridge;
        AssociatedFirearm = firearm;
        IsLegal = isLegal;
        V0 = v0;
        V100 = CalculateV100(v0, cartridge?.AssociatedBullet!);
        E0 = CalculateE0(v0, cartridge?.AssociatedBullet!);
        E100 = CalculateE100(V100, cartridge?.AssociatedBullet!);
        GameClass = CalculateHighestLegalGameClass();
    }
}
