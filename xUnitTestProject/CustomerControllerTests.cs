using ApplicationTier.Dtos;
using ApplicationTier.Interfaces;
using CustomerApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace xUnitTestProject
{
    public class CustomerControllerTests
    {
        private readonly Mock<ICustomerMethods> _customerMethodsMock;
        private readonly CustomerController _controller;
        //Same cannot Mock DbContext
        public CustomerControllerTests ()
        {
            _customerMethodsMock = new Mock<ICustomerMethods> ();
            _controller = new CustomerController(_customerMethodsMock.Object);
        }

        [Fact]
        public async Task AddCustomerTest()
        {
            var fname = "Joe";
            var lname = "Tribe";

            //Setting up mock behavior
            var expectedCustomerDto = new CustomerDto { Id = 2000, FirstName = fname, LastName = lname,
                DateOfBirth = DateTime.Now.AddYears(-20)
            };

            //Mock the customer method AddCustomer

            _customerMethodsMock.Setup(m => m.AddCustomer(fname, lname, It.IsAny<DateTime>()))
                .ReturnsAsync (expectedCustomerDto);

            //Testing the CustomerMethods AddCustomer
            var result = await _controller.AddCustomer(fname, lname);

            var jsonResult = Assert.IsType<JsonResult>(result);
            var returnedCustomerDto = Assert.IsType<CustomerDto>(jsonResult.Value);

            Assert.Equal(fname, (returnedCustomerDto.FirstName));
            Assert.Equal(lname, (returnedCustomerDto.LastName));
            Assert.Equal(expectedCustomerDto.DateOfBirth, (returnedCustomerDto.DateOfBirth));
            Assert.Equal((fname + " " + lname), (returnedCustomerDto.FullName));
        }
    }
}
