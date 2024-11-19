namespace Фотоцентр.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Order_Id { get; set; }
        public string? Username { get; set; }
        public string? Service_Name { get; set; }
        public string? Description { get; set; }
        public DateTime Order_Date { get; set; }
        public decimal Total_Amount { get; set; }
        public int StatusId { get; set; }
        public int Photographer_Id { get; set; } = -1;
    }
}
