using System.ComponentModel.DataAnnotations;

namespace Фотоцентр.Models
{
    public class Client
    {
        [Key]
        public int User_Id { get; set; }
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Adress { get; set; }
        public DateOnly? DateRegistered { get; set; }
    }
}