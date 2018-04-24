using System;
using System.ComponentModel.DataAnnotations;

namespace EMR.Models
{
    public class UserEditModel
    {
        [Key]
        public String Id { get; set; }
        public String UserId { get; set; }
        [Required]
        [Display(Name = "Название")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Логин")]
        public String UserName { get; set; }
        [Required]
        [Display(Name = "Роль")]
        public String Role_Id { get; set; }
    }
}