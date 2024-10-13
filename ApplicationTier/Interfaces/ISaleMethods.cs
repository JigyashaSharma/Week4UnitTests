//Task2: Add a new class and interface in the application tier that will add a new sale, note you must also add an interface
using ApplicationTier.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTier.Interfaces
{
    public interface ISaleMethods
    {
        public Task<SaleDto> AddSaleAsync(int customerId, int productId, int storeId, DateTime dateSold);
    }
}
