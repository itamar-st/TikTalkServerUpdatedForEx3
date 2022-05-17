
using System.ComponentModel.DataAnnotations;
namespace Domain

public class Contact
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Nickname { get; set; }
    public string ProfilePicURL { get; set; }
    [Required]
    public string LastMessage { get; set; }
    public string LastMsgDate { get; set; }
    public string Server { get; set; }
}
