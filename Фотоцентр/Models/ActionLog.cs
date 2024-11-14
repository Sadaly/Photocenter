using System.ComponentModel.DataAnnotations;

namespace Фотоцентр.Models
{
    public class ActionLog
	{
        [Key]
        public int Log_Id { get; set; }
        public int User_Id { get; set; }
        public string? Action_Type { get; set; }
        public DateTime? Action_Timestamp { get; set; }
		public string? Details { get; set; }
		public string? Table_Name { get; set; }
        public string Severity_Level { get; set; } = null!;
    }
}