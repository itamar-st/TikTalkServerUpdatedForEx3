using System.ComponentModel.DataAnnotations;
namespace Domain
{
    public class Message
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public string Content { get; set; }
        
    }
}
