using System.ComponentModel.DataAnnotations;

namespace Фотоцентр.Models
{
    public class OrderStatus
    {
        [Key]
        public int Status_Id { get; set; }
        public string? Status_Name { get; set; }
        public DateTime Change_Date{ get; set; }
    }
}