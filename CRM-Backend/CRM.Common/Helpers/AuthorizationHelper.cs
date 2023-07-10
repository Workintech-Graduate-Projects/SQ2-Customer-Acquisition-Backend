using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Common.Helpers
{
    public class AuthorizationHelper
    {
        public static bool HasAuthority(string role, Type classType, string method)
        {
            List<int> apiAuthorities = (classType.GetMethod(method).GetCustomAttribute<Attributes.AuthorizationAttribute>()).AuthorizationRole.Select(r => (int)r).ToList();

            if (apiAuthorities.Contains(Convert.ToInt32(role)))
                return true;

            return false;

        }
    }
}
