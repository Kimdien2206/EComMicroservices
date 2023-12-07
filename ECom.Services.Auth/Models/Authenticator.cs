using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ECom.Services.Auth.Models
{
    public class Authenticator
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("email")]
        [StringLength(200)]
        public string Email { get; set; } = null!;

        [Required]
        [Column("code")]
        public int Code { get; set; }

        [Required]
        [Column("expiration")]
        public DateTime Expiration { get; set; }

    }
}
