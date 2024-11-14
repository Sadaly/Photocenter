using System.ComponentModel.DataAnnotations;

namespace Фотоцентр.Models
{
    public class Service
    {
        [Key]
        public int Service_Id { get; set; }
        public string? Service_Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
    }
}