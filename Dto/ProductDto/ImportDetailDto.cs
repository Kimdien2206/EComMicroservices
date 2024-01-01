using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.ProductDto
{
    public class ImportDetailDto
    {
        public int Id { get; set; }

        public int Item { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public int ImportId { get; set; }

        public int TotalCost { get; set; }

        public virtual ProductDto Product { get; set; }
    }
}
