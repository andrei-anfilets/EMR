using System.Collections.Generic;

namespace EMR.DAL.Models
{
    public class RootObject
    {
        public int count { get; set; }
        public List<CrmPerson> data { get; set; }
    }
}
