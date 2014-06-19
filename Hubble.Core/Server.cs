using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubble.Core
{
    public class Server
    {
        public string ConnectionString { get; set; }
        public IEnumerable<Database> Databases { get; set; }
    }
}
