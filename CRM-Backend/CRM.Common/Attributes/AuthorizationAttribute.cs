using CRM_Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Common.Attributes
{
    public class AuthorizationAttribute : Attribute
    {
        public AuthorizationAttribute(AuthorizationRole[] authorizationRole)
        {
            this.AuthorizationRole = authorizationRole;
        }

        public AuthorizationRole[] AuthorizationRole { get; set; }
    }
}
