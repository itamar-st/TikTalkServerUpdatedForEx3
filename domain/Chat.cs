using System.ComponentModel.DataAnnotations;
namespace Domain

public class Chat
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string From { get; set; }
    [Required]
    public string To { get; set; }
    [Required]
    public List<Message> messages { get; set; }
}
