using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubble.Core
{
    public interface IDeploymentMeteringSource
    {
        IEnumerable<MeasurableEntity> Measure(DateTime start, DateTime end, Deployment deployment);
    }
}
