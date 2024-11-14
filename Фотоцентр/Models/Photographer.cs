using System.ComponentModel.DataAnnotations;

namespace Фотоцентр.Models
{
    public class Photographer
    {
        [Key]
        public int User_Id { get; set; }
        public int Rating { get; set; }
        public int Orders_Complete { get; set; }
		public int Orders_In_Progress { get; set; }
        public string Username { get; set; } = null!;
    }
}