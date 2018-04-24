using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace EMR.DAL2.Identity
{
    public class AppRole : IdentityRole
    {        
        public virtual List<RolePrivilege> Privileges { get; set; }
    }
}
