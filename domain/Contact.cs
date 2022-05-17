
using System.ComponentModel.DataAnnotations;
namespace Domain;

public class Contact
{
    [Required]
    public int Id { get; set; }
    [Required]

    [Key]
    public string UserName { get; set; }

    [Required]
    public string Nickname { get; set; }
    public string? ProfilePicURL { get; set; }
    [Required]
    public string Last { get; set; }
    public string LastDate { get; set; }
    public string Server { get; set; }
    public Chat? ChatWithContact { get; set; } 
}
