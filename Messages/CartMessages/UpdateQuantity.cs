﻿using Dto.CartDto;

namespace Messages.CartMessages
{
    public class UpdateQuantity : ICommand
    {
        public string PhoneNumber { get; set; }

        public List<CartDetailDto> Details { get; set; }
    }
}
