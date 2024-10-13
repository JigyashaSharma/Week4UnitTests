//Task2: Add a new class and interface in the application tier that will add a new sale, note you must also add an interface
using IndustryConnect_Week_Microservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTier.Dtos
{
    public class SaleDto
    {
        public string? CustomerName { get; set; }

        public string? ProductName { get; set; }
        public DateTime? DateSold { get; set; }

        public string? StoreName { get; set; }

        public SaleDto(Sale s, Customer? c, Product? p, Store? st)
        {
            CustomerName = c?.FirstName + " " + c?.LastName;
            ProductName = p?.Name;
            DateSold = s?.DateSold;
            StoreName = st?.Name;
        }
    }
}
