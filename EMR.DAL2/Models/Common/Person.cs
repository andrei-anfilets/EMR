using EMR.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.DAL.Models
{
   public class Person
    {
        public Int64 Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime BithDate { get; set; }
        public Boolean Deleted { get; set; }
    }
}
