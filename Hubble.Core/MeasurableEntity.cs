using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubble.Core
{
    public class MeasurableEntity
    {
        public string EntityID { get; set;}
        public double cpu { get; set; }
        public int sess { get; set; }

        // Physical Data Reads (Avg Percent)
        public double pdr { get; set; }

        // Log writes (Avg Percent)
        public double lwr { get; set; }

        // Memory (Avg Percent)
        public double mem { get; set; }
    }
}
