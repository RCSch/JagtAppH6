namespace JagtApp.Konsol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Eksempel data
            Bullet generic308hunting = new Bullet(1, "Generic .308 Hunting Bullet", "A generic hunting bullet for .308 caliber.", 9.7, 7.62, true, true);
            Bullet FMJ7mm = new Bullet(2, "7mm FMJ", "Spidsskarp riffelkugle i 7 mm", 9.1, 7.25, false, false);
            Bullet RWS7mmHIT = new Bullet(3, "7mm RWS HIT", "Jagtkugle i kal. 7 mm med kontrolleret ekspansion", 9.1, 7.25, true, true);
            Bullet RWS7mmEVO = new Bullet(4, "7mm RWS Evolution Green", "Fragmenterende jagtkugle i kal. 7 mm", 8.2, 7.25, true, true);
            Bullet RWS22HIT = new Bullet(5, ".22 RWS HIT", "Jagtkugle i kal. .22 med kontrolleret ekspansion", 2.6, 5.6, true, true);
            Bullet CCIStinger = new Bullet(6, "CCI Stinger", "Jagtkugle i kal. .22 Hollowpoint", 2.07, 5.6, false, true);
            Bullet CCICopper = new Bullet(7, "CCI Copper", "Blyfri og ekspanderende jagtkugle i kal. .22", 1.36, 5.6, true, true);
            Bullet Magtech38SJSP = new Bullet(8, "Magtech .38 Semi Jackecet Soft Point", "Ekspanderende, kappet projektil i kal. 38 til både revolver og riffel", 10, 9.07, true, true);

            Caliber Winchester308 = new Caliber(1, ".308 Winchester", 7.62);
            Caliber Breneke7x64mm = new Caliber(2, "7x64 mm Breneke", 7.25);
            Caliber Hornet22 = new Caliber(3, ".22 Hornet", 5.6);
            Caliber LongRifle22 = new Caliber(4, ".22 Long Rifle", 5.6);
            Caliber Special38 = new Caliber(5, ".38 Special", 9.07);
            Caliber Magnum357 = new Caliber(6, ".357 Magnum", 9.07);
            Caliber Remington223 = new Caliber(7, ".223 Remington", 5.6);

            Cartridge Generic308huntingCartridge = new Cartridge(1, generic308hunting, "Generic .308 Cartridge");
            Cartridge RWS7x64FMJ = new Cartridge(2, FMJ7mm, "RWS spidsskarp 7x64");
            Cartridge RWS7x64HIT = new Cartridge(3, RWS7mmHIT, "RWS HIT 7x64");
            Cartridge RWS7x64EVO = new Cartridge(4, RWS7mmEVO, "RWS Evo Green 7x64");
            Cartridge RWS22HornetHIT = new Cartridge(5, RWS22HIT, "RWS HIT .22 Hornet");
            Cartridge CCI22Stinger = new Cartridge(6, CCIStinger, "CCI Stinger, kal. 22 LR");
            Cartridge CCI22Copper = new Cartridge(7, CCICopper, "CCI Copper, kal. 22 LR");
            Cartridge Magtech38SpSJSP = new Cartridge(8, Magtech38SJSP, "Magtech SJSP i .38 Special");
            Cartridge Magtech357SpSJSP = new Cartridge(9, Magtech38SJSP, "Magtech SJSP i .357 Magnum");
            Cartridge RWS223HIT = new Cartridge(10, RWS22HIT, "RWS HIT .223");

            List<Caliber> suppCal308 = new List<Caliber> { Winchester308 };
            List<Caliber> suppCal7x64 = new List<Caliber> { Breneke7x64mm };
            List<Caliber> suppCal22Hornet = new List<Caliber> { Hornet22 };
            List<Caliber> suppCal22LR = new List<Caliber> { LongRifle22 };
            List<Caliber> suppCal38and357 = new List<Caliber> { Special38, Magnum357 };
            List<Caliber> suppCal223 = new List<Caliber> { Remington223 };

            Firearm Generic308Rifle = new Firearm(1, "Sample Firearm", "Sample Brand", 50.8, FirearmType.Rifle, suppCal308);
            Firearm MannlicherSchonauerGK = new Firearm(2, "Mannlicher-Schönauer GK", "Steyr", 60.5, FirearmType.Rifle, suppCal7x64);
            Firearm Anschütz1432 = new Firearm(3, "M.1432", "Anschütz", 58.0, FirearmType.Rifle, suppCal22Hornet);
            Firearm Ruger7722 = new Firearm(4, "Model 77/22", "Ruger", 50.5, FirearmType.Rifle, suppCal22LR);
            Firearm Ruger77357 = new Firearm(5, "Model 77/357", "Ruger", 50.5, FirearmType.Rifle, suppCal38and357);
            Firearm SmithWesson27 = new Firearm(6, "Model 27", "Smith & Wesson", 14.5, FirearmType.Handgun, suppCal38and357);
            Firearm TikkaT3223 = new Firearm(7, "T3", "Tikka", 45, FirearmType.Rifle, suppCal223);

            // Ammunitionskrav til vildtklasserne 
            AmmunitionRequirements Class1Ammo = new AmmunitionRequirements(6.0, 2000.0, 0, 0, 0.0, true, true); //6mm, E100 = 2000 joule, ekspanderende
            AmmunitionRequirements Class2Ammo = new AmmunitionRequirements(5.5, 800.0, 0, 0.0, 0.0, true, true); //5.5mm, E100 = 800 joule, ekspanderende
            AmmunitionRequirements Class3Ammo = new AmmunitionRequirements(0.0, 175.0, 0, 0.0, 0.0, false, true); //E100 = E100 = 175 Joule
            AmmunitionRequirements Class4Ammo = new AmmunitionRequirements(0.0, 0, 150.0, 0.0, 0.0, false, true); //E0 = 150 Joule
            AmmunitionRequirements Class5Ammo = new AmmunitionRequirements(0.0, 0.0, 0, 200.0, 0.0, false, true); //V0 = 200 M/S

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

            // Liste af alle krav
            List<GameRequirements> allGameRequirements = new List<GameRequirements>
            {
                Class1Requirements,
                Class2Requirements,
                Class3Requirements,
                Class4Requirements,
                Class5Requirements
            };

            Combination genericCombination = new Combination(1, "Sample Combination", Generic308huntingCartridge, Generic308Rifle, 914.4);
            Combination MSGKRWSFMJ = new Combination(2, "Mannlicher-Schönauer GK m. RWS spidsskarp 7x64", RWS7x64FMJ, MannlicherSchonauerGK, 880);
            Combination MSGKRWSHIT = new Combination(3, "Mannlicher-Schönauer GK m. RWS 7x64 HIT", RWS7x64HIT, MannlicherSchonauerGK, 900);
            Combination MSGKRWSEVO = new Combination(4, "Mannlicher-Schönauer GK m. RWS 7x64 EVO", RWS7x64EVO, MannlicherSchonauerGK, 950);
            Combination Ansc22HornRWSHIT = new Combination(5, "Anshcütz M.1432 m. RWS .22 Hornet HIT", RWS22HornetHIT, Anschütz1432, 736);
            Combination Ruger22Sting = new Combination(6, "Ruger 77/22 m. CCI Stinger", CCI22Stinger, Ruger7722, 500);
            Combination Ruger22Copper = new Combination(7, "Ruger 77/22 m. CCI Copper", CCI22Copper, Ruger7722, 464);
            Combination Ruger35738SpecialSJSP = new Combination(8, "Ruger 77/357 m. Magtech .38 Special SJSP", Magtech38SpSJSP, Ruger77357, 275);
            Combination Ruger357357MagnumSJSP = new Combination(9, "Ruger 77/357 m. Magtech .357 Magnum SJSP", Magtech357SpSJSP, Ruger77357, 410);
            Combination SW2738SpecialSJSP = new Combination(10, "Smith & Wesson M.27 m. Magtech .38 Special SJSP", Magtech38SpSJSP, SmithWesson27, 230);
            Combination SW27357MagnumSJSP = new Combination(11, "Smith & Wesson M.27 m. Magtech .357 Magnum SJSP", Magtech357SpSJSP, SmithWesson27, 376);
            Combination TikkaT3RWS223HIT = new Combination(12, "Tikka T3 M. RWS 223 HIT", RWS223HIT, TikkaT3223, 919);

            // Udskriv resultatet af beregningen for hver kombination
            PrintCombinationDetails(MSGKRWSHIT);
            PrintCombinationDetails(MSGKRWSFMJ);
            PrintCombinationDetails(TikkaT3RWS223HIT);
            PrintCombinationDetails(Ansc22HornRWSHIT);
            PrintCombinationDetails(Ruger22Sting);
            PrintCombinationDetails(Ruger22Copper);
        }

        static void PrintCombinationDetails(Combination combination)
        {
            Console.WriteLine($"\nCombination Name: {combination.CombiName}");
            Console.WriteLine($"Associated Cartridge: {combination.AssociatedCartridge.CartridgeName}");
            Console.WriteLine($"Associated Firearm: {combination.AssociatedFirearm.FAName}");
            Console.WriteLine($"Muzzle Velocity (V0): {combination.V0} m/s");
            Console.WriteLine($"Muzzle Energy (E0): {combination.E0} joule");
            Console.WriteLine($"Velocity at 100m (V100): {combination.V100} m/s");
            Console.WriteLine($"Energy at 100m (E100): {combination.E100} joule");
            Console.WriteLine($"Bullet is lead free: {combination.AssociatedCartridge.AssociatedBullet.LeadFree}");

            var highestLegalGameClass = combination.CalculateHighestLegalGameClass();
            Console.WriteLine($"\nHighest Legal Game Class: {highestLegalGameClass}\n");

            if (highestLegalGameClass != GameClass.Ulovlig)
            {
                Console.WriteLine($"The combination of {combination.AssociatedFirearm.FAName} and {combination.AssociatedCartridge.CartridgeName} is legal for hunting {highestLegalGameClass} game. Knæk og bræk!\n");
            }
            else
            {
                Console.WriteLine($"The combination of {combination.AssociatedFirearm.FAName} and {combination.AssociatedCartridge.CartridgeName} is not legal for hunting any game. Hjem og skift!\n");
            }
        }
    }
}
