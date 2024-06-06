using System;
using System.Collections.Generic;

namespace JagtApp.Konsol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bullet generic308hunting = new Bullet(1, "Sample Bullet", "Description", 9.72, 7.62, true, true);
            Bullet FMJ7mm = new(2, "7mm FMJ", "Spidsskarp riffelkugle i 7 mm", 9.1, 7.25, false, false);
            Bullet RWS7mmHIT = new(3, "7mm RWS HIT", "Jagtkugle i kal. 7 mm med kontrolleret ekspansion", 9.1, 7.25, true, true);
            Bullet RWS7mmEVO = new(4, "7mm RWS Evolution Green", "Fragmenterende jagtkugle i kal. 7 mm", 8.2, 7.25, true, true);
            Bullet RWS22HIT = new(5, ".22 RWS HIT", "Jagtkugle i kal. .22 med kontrolleret ekspansion", 2.6, 5.6, true, true);
            Bullet CCIStinger = new(6, "CCI Stinger", "Jagtkugle i kal. .22 Hollowpoint", 2.07, 5.6, false, true);
            Bullet CCICopper = new(7, "CCI Copper", "Blyfri og ekspanderende jagtkugle i kal. .22", 1.36, 5.6, true, true);
            Bullet Magtech38SJSP = new(8, "Magtech .38 Semi Jackecet Soft Point", "Ekspanderende, kappet projektil i kal. 38 til både revolver og riffel", 10, 9.07, false, true);

            Caliber Winchester308 = new Caliber(1, "Caliber 7.62", 7.62);
            Caliber Breneke7x64mm = new(2, "7x64 mm Breneke", 7.25);
            Caliber Hornet22 = new(3, ".22 Hornet", 5.6);
            Caliber LongRifle22 = new(4, ".22 Long Rifle", 5.6);
            Caliber Special38 = new(5, ".38 Special", 9.07);
            Caliber Magnum357 = new(6, ".357 Magnum", 9.07);

            Cartridge Generic308huntingCartridge = new Cartridge(1, generic308hunting, "Generic .308 Cartridge");
            Cartridge RWS7x64FMJ = new(2, FMJ7mm, "RWS spidsskarp 7x64");
            Cartridge RWS7x64HIT = new(3, RWS7mmHIT, "RWS HIT 7x64");
            Cartridge RWS7x64EVO = new(4, RWS7mmEVO, "RWS Evo Green 7x64");
            Cartridge RWS22HornetHIT = new(5, RWS22HIT, "RWS HIT .22 Hornet");
            Cartridge CCI22Stinger = new(6, CCIStinger, "CCI Stinger, kal. 22 LR");
            Cartridge CCI22Copper = new(7, CCICopper, "CCI Copper, kal. 22 LR");
            Cartridge Magtech38SpSJSP = new(8, Magtech38SJSP, "Magtech SJSP i .38 Special");
            Cartridge Magtech357SpSJSP = new(9, Magtech38SJSP, "Magtech SJSP i .357 Magnum");

            List<Caliber> suppCal308 = new List<Caliber> { Winchester308 };
            List<Caliber> suppCal7x64 = new List<Caliber> { Breneke7x64mm };
            List<Caliber> suppCal22Hornet = new List<Caliber> { Hornet22 };
            List<Caliber> suppCal22LR = new List<Caliber> { LongRifle22 };
            List<Caliber> suppCal38and357 = new List<Caliber> { Special38, Magnum357 };

            Firearm Generic308Rifle = new Firearm(1, "Sample Firearm", "Sample Brand", 508, FirearmType.Rifle, suppCal308);
            Firearm MannlicherSchonauerGK = new Firearm(2, "Mannlicher-Schönauer GK", "Steyr", 605, FirearmType.Rifle, suppCal7x64);
            Firearm Anschütz1432 = new(3, "M.1432", "Anschütz", 580, FirearmType.Rifle, suppCal22Hornet);
            Firearm Ruger7722 = new(4, "Model 77/22", "Ruger", 505, FirearmType.Rifle, suppCal22LR);
            Firearm Ruger77357 = new(5, "Model 77/357", "Ruger", 505, FirearmType.Rifle, suppCal38and357);
            Firearm SmithWesson27 = new(6, "Model 27", "Smith & Wesson", 145, FirearmType.Handgun, suppCal38and357);

            Combination genericCombination = new Combination(1, "Sample Combination", Generic308huntingCartridge, Generic308Rifle, true, 914.4);
            Combination MSGKRWSFMJ = new Combination(2, "Mannlicher-Schönauer GK m. RWS spidsskarp 7x64", RWS7x64FMJ, MannlicherSchonauerGK, false, 880);
            Combination MSGKRWSHIT = new Combination(3, "Mannlicher-Schönauer GK m. RWS 7x64 HIT", RWS7x64HIT, MannlicherSchonauerGK, true, 900);
            Combination MSGKRWSEVO = new Combination(4, "Mannlicher-Schönauer GK m. RWS 7x64 EVO", RWS7x64EVO, MannlicherSchonauerGK, true, 950);
            Combination Ansc22HornRWSHIT = new(5, "Anshcütz M.1432 m. RWS .22 Hornet HIT", RWS22HornetHIT, Anschütz1432, true, 736);
            Combination Ruger22Sting = new Combination(6, "Ruger 77/22 m. CCI Stinger", CCI22Stinger, Ruger7722, false, 500);
            Combination Ruger22Copper = new Combination(7, "Ruger 77/22 m. CCI Copper", CCI22Copper, Ruger7722, true, 564);
            Combination Ruger35738SpecialSJSP = new Combination(8, "Ruger 77/357 m. Magtech .38 Special SJSP", Magtech38SpSJSP, Ruger77357, true, 275);
            Combination Ruger357357MagnumSJSP = new Combination(9, "Ruger 77/357 m. Magtech .357 Magnum SJSP", Magtech357SpSJSP, Ruger77357, true, 410);
            Combination SW2738SpecialSJSP = new Combination(10, "Smith & Wesson M.27 m. Magtech .38 Special SJSP", Magtech38SpSJSP, SmithWesson27, false, 230);
            Combination SW27357MagnumSJSP = new Combination(11, "Smith & Wesson M.27 m. Magtech .357 Magnum SJSP", Magtech357SpSJSP, SmithWesson27, false, 376);

            //Ammunitionskrav til vildtklasserne
            AmmunitionRequirements Class1Ammo = new AmmunitionRequirements(6.0, 2000.0, 0, 0.0, 0.0, true, true);
            AmmunitionRequirements Class2Ammo = new AmmunitionRequirements(5.5, 800.0, 0, 0.0, 0.0, true, true);
            AmmunitionRequirements Class3Ammo = new AmmunitionRequirements(0.0, 175.0, 0, 0.0, 0.0, false, true);
            AmmunitionRequirements Class4Ammo = new AmmunitionRequirements(0.0, 0, 150.0, 0.0, 0.0, false, true);
            AmmunitionRequirements Class5Ammo = new AmmunitionRequirements(0.0, 0.0, 0, 200.0, 0.0, false, true);

            //Tilladte våbentyper til vildtklasserne
            List<FirearmType> Class1AllowedFirearmTypes = new List<FirearmType> { FirearmType.Rifle };
            List<FirearmType> Class2AllowedFirearmTypes = new List<FirearmType> { FirearmType.Rifle, FirearmType.Shotgun };
            List<FirearmType> Class3AllowedFirearmTypes = new List<FirearmType> { FirearmType.Rifle, FirearmType.Shotgun };
            List<FirearmType> Class4AllowedFirearmTypes = new List<FirearmType> { FirearmType.Rifle, FirearmType.Shotgun };
            List<FirearmType> Class5AllowedFirearmTypes = new List<FirearmType> { FirearmType.Rifle, FirearmType.Shotgun };
            //Samlede krav til jagt på vildtklasserne
            GameRequirements Class1Requirements = new GameRequirements(GameClass.Class1, Class1Ammo, Class1AllowedFirearmTypes);
            GameRequirements Class2Requirements = new GameRequirements(GameClass.Class2, Class2Ammo, Class2AllowedFirearmTypes, 20);
            GameRequirements Class3Requirements = new GameRequirements(GameClass.Class3, Class3Ammo, Class3AllowedFirearmTypes, 25);
            GameRequirements Class4Requirements = new GameRequirements(GameClass.Class4, Class4Ammo, Class4AllowedFirearmTypes, 30);
            GameRequirements Class5Requirements = new GameRequirements(GameClass.Class5, Class5Ammo, Class5AllowedFirearmTypes, 30);

            //Jagtbare vildarter
            //Klasse 1
            Game Class1Game1 = new Game(1, "Krondyr", Class1Requirements);
            Game Class1Game2 = new Game(2, "Dådyr", Class1Requirements);
            Game Class1Game3 = new Game(3, "Sika", Class1Requirements);
            Game Class1Game4 = new Game(4, "Muflon", Class1Requirements);
            Game Class1Game5 = new Game(5, "Vildsvin", Class1Requirements);
            //Klasse 2
            Game Class2Game1 = new Game(6, "Rådyr", Class2Requirements);
            Game Class2Game2 = new Game(7, "Sæler", Class2Requirements);
            //Klasse 3
            Game Class3Game1 = new Game(8, "Ræv", Class3Requirements);
            Game Class3Game2 = new Game(9, "Vaskebjørn", Class3Requirements);
            Game Class3Game3 = new Game(10, "Mårhund", Class3Requirements);
            Game Class3Game4 = new Game(11, "Hare", Class3Requirements);
            Game Class3Game5 = new Game(12, "Sumpbæver", Class3Requirements);
            Game Class3Game6 = new Game(13, "Skarv", Class3Requirements);
            Game Class3Game7 = new Game(14, "Gås", Class3Requirements);
            //Klasse 4
            Game Class4Game1 = new Game(15, "Husmår", Class4Requirements);
            Game Class4Game2 = new Game(16, "Ilder", Class4Requirements);
            Game Class4Game3 = new Game(17, "Mink", Class4Requirements);
            Game Class4Game4 = new Game(18, "Vildkanin", Class4Requirements);
            Game Class4Game5 = new Game(19, "Bisamrotte", Class4Requirements);
            Game Class4Game6 = new Game(20, "Hønsefugl", Class4Requirements);
            Game Class4Game7 = new Game(21, "Blishøne", Class4Requirements);
            Game Class4Game8 = new Game(22, "And", Class4Requirements);
            Game Class4Game9 = new Game(23, "Måge", Class4Requirements);
            //Klasse 5
            Game Class5Game1 = new Game(24, "Due", Class5Requirements);
            Game Class5Game2 = new Game(25, "Kragefugl", Class5Requirements);
            Game Class5Game3 = new Game(26, "Vadefugl", Class5Requirements);
            Game Class5Game4 = new Game(27, "Stær", Class5Requirements);

          

            
            Console.WriteLine($"Combination Name: {genericCombination.CombiName}");
            Console.WriteLine($"Associated Cartridge: {genericCombination.AssociatedCartridge.CartridgeName}");
            Console.WriteLine($"Associated Firearm: {genericCombination.AssociatedFirearm.FAName}");
            Console.WriteLine($"Muzzle Velocity: {genericCombination.V0} m/s.");
            Console.WriteLine($"Muzzle Energy: {genericCombination.E0} joule.");
            Console.WriteLine($"100 m Velocity: {genericCombination.V100} m/s.");
            Console.WriteLine($"100 m Energy: {genericCombination.E100} joule.");

            if (genericCombination.IsLegal == true)
            {
                Console.WriteLine($"The combination of {genericCombination.AssociatedFirearm.FAName} and {genericCombination.AssociatedCartridge.CartridgeName} is legal for hunting class 1 game. Knæk og bræk!");
            }
            else
            {
                Console.WriteLine($"The combination of {genericCombination.AssociatedFirearm.FAName} and {genericCombination.AssociatedCartridge.CartridgeName} is not legal for hunting class 1 game. Hjem og skift!");
            }

            Console.WriteLine($"Combination Name: {Ansc22HornRWSHIT.CombiName}");
            Console.WriteLine($"Associated Cartridge: {Ansc22HornRWSHIT.AssociatedCartridge.CartridgeName}");
            Console.WriteLine($"Associated Firearm: {Ansc22HornRWSHIT.AssociatedFirearm.FAName}");
            Console.WriteLine($"Muzzle Velocity: {genericCombination.V0} m/s.");
            Console.WriteLine($"Muzzle Energy: {Ansc22HornRWSHIT.E0} joule.");
            Console.WriteLine($"100 m Velocity: {Ansc22HornRWSHIT.V100} m/s.");
            Console.WriteLine($"100 m Energy: {Ansc22HornRWSHIT.E100} joule.");

            if (Ansc22HornRWSHIT.IsLegal == true)
            {
                Console.WriteLine("This combination is legal for hunting class 1 game. Knæk og bræk!");
            }
            else
            {
                Console.WriteLine("This combination is not legal for hunting class 1 game. Hjem og skift!");
            }
        }
    }
}
