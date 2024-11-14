

using System.ComponentModel.DataAnnotations;

namespace Фотоцентр.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = " ")]
        public string Username { get; set; } = null!;
        [Required(AllowEmptyStrings = false, ErrorMessage =" ")]
        public string Password { get; set; } = null!;
    }
}
