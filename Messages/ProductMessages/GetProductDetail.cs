﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.ProductMessages
{
    public class GetProductDetail : ICommand
    {
        public int ProductDetailId { get; set; }
    }
}
