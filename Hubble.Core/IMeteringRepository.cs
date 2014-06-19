using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubble.Core
{
    public interface IMeteringRepository
    {
        void Persist(IEnumerable<EntityRecord> records);
    }
}
