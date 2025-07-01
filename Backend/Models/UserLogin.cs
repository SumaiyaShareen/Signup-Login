using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LOGINSYSTEM.Models;

public partial class UserLogin
{
    [Key]
    public int LoginId { get; set; }
    [ForeignKey("User")]  
    public int? UserId { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }
    [JsonIgnore]
    public UserDetail ?User { get; set; } // User details
}
