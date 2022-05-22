using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Domain;

public class Invitation
{
    [Required]
    public string From { get; set; }
    [Required]
    public string To { get; set; }
    [Required]
    public string Server { get; set; }
}
