using System.ComponentModel.DataAnnotations;
namespace Domain;

public class User
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string ProfilePicURL { get; set; }
    [Required]
    public string Password { get; set; }
    public ICollection<Contact> Contacts { get; set; }


}
