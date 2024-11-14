using System.ComponentModel.DataAnnotations;

namespace Фотоцентр.Models
{
    public class Payment
    {
        [Key]
        public int Payment_Id { get; set; }
        public int Order_Id { get; set; }
        public DateTime? Payment_Date { get; set; }
        public decimal? Amount_Paid { get; set; }
    }
}