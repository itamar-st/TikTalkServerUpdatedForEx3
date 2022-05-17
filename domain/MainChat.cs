using System.ComponentModel.DataAnnotations;
namespace Domain;

public class MainChat
{
    [Required]
    public User user { get; set; }
    public Contact? CurrentContact { get; set; }
    public Chat? CurrentChat { get; set; }
}
