﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain;

public class User
{
    [Required]
    public string Id { get; set; } //username
    [Required]
    public string Name { get; set; } // Nickname

    [JsonIgnore]
    public string ProfilePic { get; set; } = "";
    [Required]
    public string Password { get; set; }
    [JsonIgnore]
    [ForeignKey("UserIdNum")]
    public List<Contact> Contacts { get; set; } = new List<Contact>();


}
