using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hubble.Core;

namespace Hubble.Repository
{
    public class MeteringRepository : IMeteringRepository
    {
        readonly string connString;
        public MeteringRepository(string connString)
        {
            this.connString = connString;
        }
        public void Persist(IEnumerable<EntityRecord> records)
        {
            // TODO
        }
    }
}
