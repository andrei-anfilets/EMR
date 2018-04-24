using System;

namespace EMR.DAL2.Identity
{
    public class RolePrivilege
    {
        public Int64 Id { get; set; }
        public virtual Privilege Privilege { get; set; }
        public virtual AppRole AppRole { get; set; }
    }
}
