using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMR.DAL2.Identity
{
    public class Menu
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public bool Deleted { get; set; }
        public List<Privilege> Privileges { get; set; }
        public Int64? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual Menu Parent { get; set; }
        public virtual ICollection<Menu> Childs { get; set; }
    }
}
