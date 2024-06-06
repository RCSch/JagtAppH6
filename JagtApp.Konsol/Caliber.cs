using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JagtApp.Konsol
{
    public class Caliber
    {
        public int CaliberId { get; set; }
        public string CaliberName { get; set; }
        public double CaliberDiameter { get; set; }

        public Caliber() { }

        public Caliber(int caliberId, string caliberName, double caliberDiameter)
        {
            CaliberId = caliberId;
            CaliberName = caliberName;
            CaliberDiameter = caliberDiameter;
        }
    }
}
