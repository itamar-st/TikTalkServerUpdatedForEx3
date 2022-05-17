using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class MainChat
    {
        [Required]
        User user { get; set; }
        [Required]
        List<Contact> contacts { get; set; }
        [Required]
        Contact CurrentContact { get; set; }
        [Required]
        Chat Chat { get; set; }
    }
}
