using System.ComponentModel.DataAnnotations;

namespace Фотоцентр.Models
{
    public class Photo
    {
        [Key]
        public int User_Id { get; set; }
        public int Order_Id { get; set; }
        public string? Photo_Url { get; set; }
        public DateTime? Upload_Date { get; set; }
    }
}