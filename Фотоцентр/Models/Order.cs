using System.ComponentModel.DataAnnotations;

namespace Фотоцентр.Models
{
    public class Order
    {
        [Key]
        public int Order_Id { get; set; }
        public int Client_Id { get; set; }
        public int Photographer_Id { get; set; }
		public int Service_Id { get; set; }
		public int Status_Id { get; set; }
		public DateTime Order_Date { get; set; }
		public decimal Total_Amount{ get; set; }
	}
}