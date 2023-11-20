using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Services.Auth.Models;

public partial class Account
{
    [Key]
    [Column("email")]
    [StringLength(200)]
    public string Email { get; set; } = null!;

    [Required]
    [Column("password")]
    public string Password { get; set; } = null!;

    [DefaultValue(false)]
    [Column("is_admin")]    
    
    public bool IsAdmin { get; set; }
}
