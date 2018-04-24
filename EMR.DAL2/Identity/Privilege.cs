using System;

namespace EMR.DAL2.Identity
{
    public class Privilege
    {
        public Int64 Id { get; set; }
        public String ActionName { get; set; }
        public int ActionCode { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
