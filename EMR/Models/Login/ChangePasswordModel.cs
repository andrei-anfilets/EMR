using System.ComponentModel.DataAnnotations;

namespace EMR.Models
{
    public class ChangePasswordModel
    {
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Текущий пароль")]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [MinLength(6, ErrorMessage = "Длина пароля должна быть не менее 6 символов на латинице")]
        [Compare("PasswordRepeat", ErrorMessage = "Пароли не совпадают")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Длина пароля должна быть не менее 6 символов на латинице")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Повтор пароля")]
        public string PasswordRepeat { get; set; }
    }
}