using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            Address address1 = new Address("123 Main St", "New York", "NY", "USA");
            Customer customer1 = new Customer("John Doe", address1);

            Order order1 = new Order(customer1);
            order1.AddProduct(new Product("Book", "B001", 10.99, 2));
            order1.AddProduct(new Product("Pen", "P002", 1.50, 5));

            Address address2 = new Address("45 King Road", "Toronto", "ON", "Canada");
            Customer customer2 = new Customer("Jane Smith", address2);

            Order order2 = new Order(customer2);
            order2.AddProduct(new Product("Notebook", "N003", 6.99, 3));
            order2.AddProduct(new Product("Marker", "M004", 2.50, 4));

            DisplayOrder(order1);
            Console.WriteLine();
            DisplayOrder(order2);
        }

        static void DisplayOrder(Order order)
        {
            Console.WriteLine("PACKING LABEL");
            Console.WriteLine(order.GetPackingLabel());

            Console.WriteLine("SHIPPING LABEL");
            Console.WriteLine(order.GetShippingLabel());

            Console.WriteLine($"Total Price: ${order.GetTotalCost():F2}");
        }
    }
}