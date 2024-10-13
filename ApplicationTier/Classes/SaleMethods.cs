//Task2: Add a new class and interface in the application tier that will add a new sale, note you must also add an interface
using ApplicationTier.Dtos;
using ApplicationTier.Interfaces;
using IndustryConnect_Week_Microservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTier.Classes
{
    public class SaleMethods : ISaleMethods
    {
        public SaleMethods() { }
        public async Task<SaleDto> AddSaleAsync(int customerId, int productId, int storeId, DateTime dateSold)
        {
            try
            {
                var context = new IndustryConnectWeek2Context();

                var customer = await context.Customers.FindAsync(customerId);
                var product = await context.Products.FindAsync(productId);
                var store = await context.Stores.FindAsync(storeId);

                var sale = new Sale
                {
                    CustomerId = customerId,
                    ProductId = productId,
                    StoreId = storeId,
                    DateSold = dateSold,
                    Customer = customer,
                    Product = product,
                    Store = store
                };

                context.Sales.Add(sale);
                await context.SaveChangesAsync();

                Console.WriteLine();
                return Mapper(sale);
            }
            catch (Exception ex)
            {
                //can do logging, or re-throw or other handling here
                throw new Exception(ex.Message + ex.InnerException?.Message);
            }
            
        }

        private static SaleDto Mapper(Sale sale)
        {
            return new SaleDto(sale, sale.Customer, sale.Product, sale.Store);
        }
    }
}
