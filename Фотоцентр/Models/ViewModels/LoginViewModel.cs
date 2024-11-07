﻿

using System.ComponentModel.DataAnnotations;

namespace Фотоцентр.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = " ")]
        public string? UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage =" ")]
        public string? Password { get; set; }
    }
}
