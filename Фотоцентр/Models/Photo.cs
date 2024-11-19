using System.ComponentModel.DataAnnotations;

namespace Фотоцентр.Models
{
    public class Photo
    {
        [Key]
        public int Photo_Id { get; set; }
        public int Order_Id { get; set; }
        public string? Photo_Url { get; set; }
        public byte[]? Image { get; set; }
        public bool? Is_Final { get; set; }
        public string? Content_Type { get; set; }
    }
}