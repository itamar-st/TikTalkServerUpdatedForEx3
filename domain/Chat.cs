using System.ComponentModel.DataAnnotations;
namespace Domain;

public class Chat
{
    [Required]
    public int Id { get; set; }
    public int ContactId { get; set; }
    [Required]
    public List<Message> messages { get; set; }
}
