using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LOGINSYSTEM.Models;

public partial class UserDetail
{
    [Key]
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public byte[]? ProfilePicture { get; set; }

    [JsonIgnore]
    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();
}
