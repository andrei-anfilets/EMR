using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMR.Models
{
    public class UserViewModel
    {
        [Key]
        public Int64 Id { get; set; }
        public String UserId { get; set; }
        [Required]
        [Display(Name = "Название")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Логин")]
        public String UserName { get; set; }
        [Required]
        [Compare("PasswordComfirm")]
        [Display(Name = "Пароль")]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля 6 символов!!!")]
        public String Password { get; set; }
        [Required]
        [Compare("Password")]
        [Display(Name = "Повтор пароля")]
        public String PasswordComfirm { get; set; }
        [Required]
        [Display(Name = "Роль")]
        public String Role_Id { get; set; }
    }
}