using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTier.Dtos
{
    public class StoreDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal? TotalSale { get; set; }
    }
}
