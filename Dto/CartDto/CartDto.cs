using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.CartDto
{
    public class CartDto
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }
    }
}
