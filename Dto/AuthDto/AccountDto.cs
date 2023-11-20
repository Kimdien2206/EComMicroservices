using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.AuthDto
{
    public class AccountDto
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool IsAdmin { get; set; }
    }
}
