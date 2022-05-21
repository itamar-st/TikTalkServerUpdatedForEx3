
using System.ComponentModel.DataAnnotations;
namespace Domain;

public class Contact
{
    [Required]
    public string Id { get; set; }   //Username
    [Required]
    public string Name { get; set; }  //nickname

    public string? Last { get; set; } = "";
    public string? Lastdate { get; set; } = "";
    [Required]
    public string Server { get; set; }
    public List<Message> ChatWithContact { get; set; } = new List<Message>();
}
