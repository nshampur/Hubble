using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubble.Core
{
    public class Deployment
    {
        public IEnumerable<Server> Servers { get; set; }
    }
}
