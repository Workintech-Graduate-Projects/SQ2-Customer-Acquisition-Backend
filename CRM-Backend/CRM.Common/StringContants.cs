using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Common
{
    public class StringContants
    {
        public static string DbConnectionString { get; } = "Server=tcp:crm-api-server.database.windows.net,1433;Initial Catalog=CRM-DB;Persist Security Info=False;User ID=Admincrm;Password=Adminpass0;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}
