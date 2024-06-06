using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JagtApp.Konsol
{
    public class Cartridge
    {
        public int CartridgeId { get; set; }
        public Bullet AssociatedBullet { get; set; }
        public string CartridgeName { get; set; }

        public Cartridge() { }

        public Cartridge(int cartridgeId, Bullet associatedBullet, string cartridgeName)
        {
            CartridgeId = cartridgeId;
            AssociatedBullet = associatedBullet;
            CartridgeName = cartridgeName;
        }

    }
}
