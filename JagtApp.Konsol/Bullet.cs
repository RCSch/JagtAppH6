using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JagtApp.Konsol
{
    public class Bullet
    {
        public int BulletId { get; set; }
        public string BulletName { get; set; }
        public string BulletDescription { get; set; }
        public double BulletWeight { get; set; }
        public double BulletDiameter { get; set; }
        public bool LeadFree { get; set; }
        public bool Expanding { get; set; }

        public double SectionalDensity
        {
            get
            {
                return BulletWeight / Math.Pow(BulletDiameter, 2);
            }
        }
        public double BallisticCoefficient
        {
            get
            {
                // Constants for the estimation (helt plain havniveau-tal)
                double dragCoefficient = 0.3; // Approximate drag coefficient
                double densityAir = 1.225; // Air density at sea level (kg/m^3)

                // Estimate ballistic coefficient
                double bc = (2 * BulletWeight) / (dragCoefficient * densityAir * Math.Pow(BulletDiameter, 2));
                return bc;
            }
        }

        public Bullet(int bid, string bname, string bdes, double bw, double bd, bool lf, bool ex)
        {
            BulletId = bid;
            BulletName = bname;
            BulletDescription = bdes;
            BulletWeight = bw;
            BulletDiameter = bd;
            LeadFree = lf;
            Expanding = ex;
        }
    }
}
