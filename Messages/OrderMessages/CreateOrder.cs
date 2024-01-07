using Dto.OrderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.OrderMessages
{
    public class CreateOrder : ICommand
    {
        public OrderCreateDto newOrder { get; set; }
    }
}
