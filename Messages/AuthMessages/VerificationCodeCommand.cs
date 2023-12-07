﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.AuthMessages
{
    public class VerificationCodeCommand : ICommand
    {
        public required int Code { get; set; }
        public required string Email { get; set; }
    }
}
