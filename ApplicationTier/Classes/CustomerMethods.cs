using IndustryConnect_Week_Microservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationTier.Dtos;
using Microsoft.EntityFrameworkCore;
using ApplicationTier.Interfaces;
using System.ComponentModel;

namespace ApplicationTier.Classes
{
    public class CustomerMethods : ICustomerMethods
    {

        public CustomerMethods() { }

        public async Task<CustomerDto> AddCustomer(string firstName, string lastName, DateTime? dateOfBirth)
        {
            var context = new IndustryConnectWeek2Context();

            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };

            context.Add(customer);

            await context.SaveChangesAsync();
        
            return Mapper(customer);
       
        }

        public async Task<CustomerDto> GetCustomer(int CustomerId)
        {
            var context = new IndustryConnectWeek2Context();

            var customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == CustomerId);

            return Mapper(customer);
        }

        //Task 1: Extend the Customer API to have a method to remove the customer by Id
        static bool decideApproach = true;
        public async Task<string> DeleteCustomerAsync(int CustomerId)
        {
            try
            {
                var context = new IndustryConnectWeek2Context();

                var customer = await context.Customers
                    .Include(c => c.Sales)
                    .FirstOrDefaultAsync(c => c.Id == CustomerId);

                if (customer != null)
                {
                    //use the Remove to delete the customer
                    if (decideApproach == true)
                    {
                        //Separately need to delete the Sales record
                        //Without this Remove with Include just makes the CustomerID in Sales null
                        foreach (var sale in customer.Sales)
                        {
                            context.Sales.Remove(sale);
                        }

                        var entry = context.Customers.Remove(customer);
                        await context.SaveChangesAsync();
                        decideApproach = false;
                    }
                    else
                    {
                        //use the ExecuteDelete to delete the Customer
                        if (customer.Sales.Count > 0)
                        {
                            //Separately need to delete the Sales record
                            var saleRecDeleted = await context.Sales
                           .Where(s => s.CustomerId == CustomerId)
                           .ExecuteDeleteAsync();
                        }

                        var entry = await context.Customers
                            .Where(c => c.Id == CustomerId)
                            .ExecuteDeleteAsync();
                    
                        decideApproach = true;
                    }
                    
                    //Success return the message
                    return $"{customer.FirstName} {customer.LastName} with ID {customer.Id} Deleted successfully. " +
                        $"Also deleted {customer.Sales.Count} sales record for that customer.";
                }
                else
                {
                    return $"Customer with Id {CustomerId} does not exist!!!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private static CustomerDto Mapper(Customer? customer)
        {
            if (customer != null)
            {
                var customerDto = new CustomerDto
                {
                    FirstName = customer?.FirstName,
                    LastName = customer?.LastName,
                    DateOfBirth = customer?.DateOfBirth,
                    Id = customer.Id
                };

                return customerDto;
            }
            else
            {
                return null;
            }
           
        }

    }
}
