using ApplicationTier.Classes;

Console.WriteLine("Please enter your customer firstname?");

string firstname = Console.ReadLine();

Console.WriteLine("Please enter your customer lastname?");

string lastname = Console.ReadLine();

DateTime? dateOfBirth = DateTime.Now.AddYears(-20);


var customerMethods = new CustomerMethods();


var customer = await customerMethods.AddCustomer(firstname, lastname, dateOfBirth);


Console.WriteLine($"Your customer has been added. Customer name is {customer.FullName}, Id is {customer.Id}");

//Task2: Add a new class and interface in the application tier that will add a new sale, note you must also add an interface
var saleMethods = new SaleMethods();
var sale = await saleMethods.AddSaleAsync(customer.Id, 2, 2, DateTime.Now);

Console.WriteLine($"Sale added: {sale.CustomerName}, {sale.ProductName}, {sale.StoreName} {sale.DateSold}");
