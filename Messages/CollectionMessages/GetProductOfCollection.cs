﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.CollectionMessages
{
    public class GetProductOfCollection : ICommand
    {
        public int Id { get; set; }
    }
}
