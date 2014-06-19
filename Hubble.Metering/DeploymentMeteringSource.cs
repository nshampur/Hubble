using Hubble.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubble.Metering
{
    public class DeploymentMeteringSource : IDeploymentMeteringSource
    {
        public IEnumerable<MeasurableEntity> Measure(DateTime start, DateTime end, Deployment deployment)
        {
            return new MeasurableEntity[1]{
                 new MeasurableEntity(){ cpu = 20, pdr = 10, lwr = 40, sess = 5, EntityID = "mydb.server", mem = 69}
            };
        }
    }
}
