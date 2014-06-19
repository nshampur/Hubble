using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Hubble.Metering;
using Hubble.Repository;
using Hubble.Core;

namespace Metering_Worker
{
    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.TraceInformation("Metering_Worker entry point called");

            while (true)
            {
                Meter();
                Thread.Sleep(TimeSpan.FromMinutes(15));
                Trace.TraceInformation("Working");
            }
        }

        private void Meter()
        {
            DateTime end = DateTime.UtcNow;
            DateTime start = DateTime.UtcNow.AddMinutes(-15);
            
            DeploymentMeteringConfigSource configSource = new DeploymentMeteringConfigSource();
            var deployment = configSource.GetDeployment();
            DeploymentMeteringSource source = new DeploymentMeteringSource();
            var entities = source.Measure(start, end, deployment);

            string connString = "DefaultEndpointsProtocol=https;AccountName=njesri;AccountKey=y3a06kXxOmMejXnaxhFRtT9Qu9lvU1PVcH4ed1Ci6IgVy5kTxykYdTPp7u+6vGr3kAFQEk0/uyrZFpwcK3G3mw==";
            MeteringRepository repo = new MeteringRepository(connString);
            List<EntityRecord> records = new List<EntityRecord>(entities.Count());
            foreach(var entity in entities)
            {
                records.Add(new EntityRecord(entity.EntityID, start, end)
                {
                    cpu = entity.cpu,
                    mem = entity.mem,
                    sess = entity.sess,
                    lwr = entity.lwr,
                    pdr = entity.pdr,
                });
            }
            repo.Persist(records);
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }
    }
}
