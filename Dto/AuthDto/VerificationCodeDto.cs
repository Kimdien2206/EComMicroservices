﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.AuthDto
{
    public class VerificationCodeDto
    {
        public required int Code { get; set; }
        public required string Email { get; set; }
    }
}
