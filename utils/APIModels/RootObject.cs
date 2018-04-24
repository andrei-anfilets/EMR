using System.Collections.Generic;

namespace utils
{
    public class RootObject
    {
        public RootObject()
        {
            data = new List<EMR.DAL.Models.CrmPerson>();
        }
        public int count { get; set; }
        public List<EMR.DAL.Models.CrmPerson> data { get; set; }
    }
}
