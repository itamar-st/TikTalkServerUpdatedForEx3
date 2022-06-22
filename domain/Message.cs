using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain;

public class Message
{
    
    [Required]
    public int Id { get; set; } = 0;
    [Required]
    public string Created { get; set; } = "";
    [Required]
    public bool Sent { get; set; } = true;
    [Required]
    public string Content { get; set; } = "";
    [JsonIgnore]
    public string ContactIdNum { get; set; }
    [JsonIgnore]
    public string UserIdNum1 { get; set; }
    //public virtual Contact Contact { get; set; }

}
