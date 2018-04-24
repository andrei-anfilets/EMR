using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.DAL2.Identity
{
    public class AppUserManager : UserManager<AppUser>
    {
        
        public AppUserManager(IUserStore<AppUser> store)
                : base(store)
        {
           
        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options,
                                                IOwinContext context)
        {
            EF.EMRContext db = context.Get<EF.EMRContext>();
            AppUserManager manager = new AppUserManager(new UserStore<AppUser>(db));
            return manager;
        }

        public bool HasAccess(String userId, int MenuId, int ActionCode)
        {
            AppUser user = this.FindById(userId);
            if (user.Role.Privileges.Where(p => p.Privilege.Menu.Id == MenuId && p.Privilege.ActionCode == ActionCode).Count() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
