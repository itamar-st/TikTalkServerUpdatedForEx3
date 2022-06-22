
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
    [JsonIgnore]
    public string UserIdNum { get; set; }
    //public virtual User User { get; set; }
    [JsonIgnore]
    [ForeignKey("ContactIdNum, UserIdNum1")]
    public List<Message> ChatWithContact { get; set; } = new List<Message>();
}
