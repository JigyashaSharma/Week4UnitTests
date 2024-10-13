using ApplicationTier.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTier.Interfaces
{
    public interface IStoreMethods
    {
        Task<StoreDto> AddStore(string name);

        Task<StoreDto> GetStore(int StoreId);
    }
}
