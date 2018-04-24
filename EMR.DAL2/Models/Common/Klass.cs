using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.DAL2.Models.Common
{
    [Table("Klass")]
    public class Klass
    {
        [Key]
        public Int64 Id { get; set; }
        public int Type { get; set; }
        public int Code { get; set; }

        [MaxLength(200)]
        public String Name { get; set; }

        [MaxLength(200)]
        public String Name2 { get; set; }

        [MaxLength(200)]
        public String Name3 { get; set; }
        
        public bool Deleted { get; set; }
    }
}
