﻿using System.ComponentModel.DataAnnotations;

namespace Фотоцентр.Models
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        public string Username { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Password_Hash { get; set; } = null!;
        public DateTime Date_Registered { get; set; }

    }
}