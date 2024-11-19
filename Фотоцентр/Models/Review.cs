using System.ComponentModel.DataAnnotations;

namespace Фотоцентр.Models
{
    public class Review
    {
        [Key]
        public int Review_Id { get; set; }
		public int Client_Id { get; set; }
		public int Photographer_Id { get; set; }
		public string? Review_Text { get; set; }
        public int Rate { get; set; }
        public DateTime Review_Date { get; set; }
        public int Order_Id { get; set; }
    }
}