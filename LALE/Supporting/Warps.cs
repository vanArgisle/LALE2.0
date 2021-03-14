using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LALE.Core
{
    public class Warps
    {
        public byte type { get; set; }
        public byte region { get; set; }
        public byte map { get; set; }
        public byte x { get; set; }
        public byte y { get; set; }

        public Warps()
        {

        }
        
        public Warps(Warps w)
        {
            this.type = w.type;
            this.region = w.region;
            this.map = w.map;
            this.x = w.x;
            this.y = w.y;
        }
    }
}
