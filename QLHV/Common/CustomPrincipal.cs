using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace QLHV.Common
{
    public class CustomPrincipal : IPrincipal
    {
        private UserLogin UserLogin;
        public CustomPrincipal(UserLogin UserLogin)
        {
            this.UserLogin = UserLogin;
            this.Identity = new GenericIdentity(UserLogin.UserName);

        } 
        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.UserLogin.Roles.Contains(r));
        }
    }
}