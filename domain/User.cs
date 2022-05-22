using System.ComponentModel.DataAnnotations;
namespace Domain;

public class User
{
    [Required]
    public string Id { get; set; } //username
    [Required]
    public string Name { get; set; } // Nickname
    
    [Required]
    public string ProfilePicURL { get; set; }
    [Required]
    public string Password { get; set; }
    public ICollection<Contact> Contacts { get; set; }


}
