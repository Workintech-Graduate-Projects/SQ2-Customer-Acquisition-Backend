using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Common.Helpers
{
    public class AuthorizationHelper
    {
        public static bool HasAuthority(string role, Type classType, string method)
        {

            return true;

        }
    }
}
