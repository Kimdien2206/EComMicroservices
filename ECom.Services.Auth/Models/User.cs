using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Services.Auth.Models;

public partial class User
{
    [Key]
    [Column("phone_number")]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    [Column("firstname")]
    public string Firstname { get; set; } = null!;

    [Column("lastname")]
    public string? Lastname { get; set; }

    [Column("date_of_birth")]
    public DateTime DateOfBirth { get; set; }

    [Column("address")]
    [Required]
    public string Address { get; set; }

    [Column("avatar")]
    [DefaultValue("https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/avatar/default.png")]
    public string? Avatar { get; set; } = "https://lggcxbdwmetbsvmtuctl.supabase.co/storage/v1/object/public/avatar/default.png";

    [Column("email")]
    [Required]
    [ForeignKey("Account")]
    public string Email { get; set; } = null!;

    [Column("logged_date")]
    [Required]
    public DateTime LoggedDate { get; set; }

    public virtual Account Account { get; set; }


}
