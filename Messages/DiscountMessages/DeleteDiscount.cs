﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.DiscountMessages
{
    public class DeleteDiscount : ICommand
    {
        public int Id { get; set; }
    }
}