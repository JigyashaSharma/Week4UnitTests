using ApplicationTier.Dtos;

namespace ApplicationTier.Interfaces
{
    public interface ICustomerMethods
    {
        Task<CustomerDto> AddCustomer(string firstName, string lastName, DateTime? dateOfBirth);

        Task<CustomerDto> GetCustomer(int CustomerId);

        
        //Task 1: Extend the Customer API to have a method to remove the customer by Id
        Task<string> DeleteCustomerAsync(int CustomerId);
    }
}
