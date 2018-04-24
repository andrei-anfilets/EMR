using EMR.DAL.Models;
using EMR.DAL2.Identity;
using EMR.DAL2.Models;
using EMR.DAL2.Models.Common;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;



namespace EMR.DAL2.EF
{
    public class EMRContext : IdentityDbContext
    {
        public EMRContext() : base("EMR")
        {

        }

        public static EMRContext Create()
        {
            return new EMRContext();
        }

        //Identity sets
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<RolePrivilege> RolePrivileges { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> IdentityUsers { get; set; }
        public DbSet<Menu> Menus { get; set; }

        //Models
        public DbSet<Person> Persons { get; set; }
        public DbSet<CrmPerson> CrmPersons {get; set;}


        //Klass
        public DbSet<Category> Categories { get; set; }
        public DbSet<Klass> Klass { get; set; }

    }
}
