using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JagtApp.Konsol
{
    public class Shell
    {
        public int ShellId { get; set; }
        public string ShellName { get; set; }
        public double Gauge { get; set; } // Should be within the range 12 to 20
        public int ShotSize { get; set; } // Legal shot sizes, e.g., 1 to 3
        public bool LeadFree { get; set; } // Whether it's lead-free or not

        public Shell(int shellId, string shellName, double gauge, int shotSizes, bool leadFree)
        {
            ShellId = shellId;
            ShellName = shellName;
            Gauge = gauge;
            ShotSize = shotSizes;
            LeadFree = leadFree;
        }
    }
}