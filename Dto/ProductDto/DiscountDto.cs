using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.ProductDto
{
    public class DiscountDto
    { 
        public int Id { get; set; }

        public double DiscountAmount { get; set; }

        public string Name { get; set; } = null!;
    }
}
