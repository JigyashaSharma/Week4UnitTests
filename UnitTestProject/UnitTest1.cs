using ApplicationTier.Classes;
using ApplicationTier.Interfaces;
using IndustryConnect_Week_Microservices.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace UnitTestProject
{
    [TestFixture]
    public class CustomerMethodsTests
    {
        //Ideally we should mock EntityModel DbContext and set
        //but since we are creating instance of DbContext in each method
        //mocking is not possible.
        //These are more of EntityModel and ApplicationTier Integration Test
        //private Mock<IndustryConnectWeek2Context> _mockContext;
        //private Mock<DbSet<Customer>> _mockCustomerSet;

        private CustomerMethods _customerMethods;
        [SetUp]
        public void Setup()
        {
            _customerMethods = new CustomerMethods();
        }

        [Test]
        public async Task AddCustomerAsyncTest()
        {
            var fname = "Joe";
            var lname = "Tribe";
            var dob = DateTime.Now.AddYears(-30);

            //Testing the CustomerMethods AddCustomer
            var customer = await _customerMethods.AddCustomer(fname, lname, dob);

            Assert.IsNotNull(customer);

            Assert.That(fname, Is.EqualTo(customer.FirstName));
            Assert.That(lname, Is.EqualTo(customer.LastName));
            Assert.That(dob, Is.EqualTo(customer.DateOfBirth));
            Assert.That((fname + " " + lname), Is.EqualTo(customer.FullName));
        }

        [Test]
        public async Task DeleteCustomerAsync()
        {
            var fname = "Client";
            var lname = "Delete";
            var dob = DateTime.Now.AddYears(-25);

            //Adding customer before deleting it
            var customer = await _customerMethods.AddCustomer(fname, lname, dob);
            Assert.IsNotNull (customer);

            var resultExpected = $"{customer.FirstName} {customer.LastName} with ID {customer.Id} Deleted successfully. " +
                        $"Also deleted 0 sales record for that customer.";

            var result = await _customerMethods.DeleteCustomerAsync(customer.Id);

            Assert.IsNotNull(result);
            Assert.That(resultExpected, Is.EqualTo(result));
        }
    }
}