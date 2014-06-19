using Hubble.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubble.Metering
{
    public class DeploymentMeteringConfigSource : Hubble.Core.IDeploymentMeteringConfigSource
    {
        public Deployment GetDeployment()
        {
            Deployment deploy = new Deployment();
            var servers = new List<Server>();
            servers.Add(new Server()
            {
                ConnectionString = (new SqlConnectionStringBuilder()
                {
                    DataSource = "pjy6njvrba.database.windows.net",
                    UserID = "dpe",
                    Password = "P@ssw0rd"
                }).ConnectionString
            });
            deploy.Servers = servers;
            return deploy;
        }
    }
}
