using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.DAL2.Identity
{
    public class AppUser : IdentityUser
    {
        [MaxLength(300, ErrorMessage = "Макс длина 300")]
        [Display(Name = "Название")]
        public String Name { get; set; }
        [Display(Name = "Роль")]
        [ForeignKey("Role_Id")]
        public virtual AppRole Role { get; set; }
        public String Role_Id { get; set; }
    }
}
