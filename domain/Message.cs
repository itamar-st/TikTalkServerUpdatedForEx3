using System.ComponentModel.DataAnnotations;
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
    
}
