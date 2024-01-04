using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.ProductDto
{
    public class ImportingCreateDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int TotalCost { get; set; }

        public int TotalAmount { get; set; }

        public virtual ICollection<ImportDetailCreateDto> ImportDetails { get; set; } = new List<ImportDetailCreateDto>();
    }
}
