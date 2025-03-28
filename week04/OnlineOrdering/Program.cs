using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        // Order #1
        Console.WriteLine("\nOrder #1:\n");

        Address address1 = new Address("123 Maple Avenue", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Jane Doe", address1);

        Order order1 = new Order(customer1);

        Product product1 = new Product("EcoSmart Water Bottle", "ESWB-101", 13.50, 12);
        Product product2 = new Product("Quantum Bluetooth Speaker", "QBS-220", 23.38, 5);
        Product product3 = new Product("Stellar Desk Lamp", "SDL-330", 16.18, 8);

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.GetTotalPrice()}\n");

        // Order #2
        Console.WriteLine("\nOrder #2:\n");

        Address address2 = new Address("456 Wellington Road", "London", "SW1A", "United Kingdom");
        Customer customer2 = new Customer("John Smith", address2);

        Order order2 = new Order(customer2);

        Product product4 = new Product("Orbit Smartwatch", "OSW-440", 71.98, 3);
        Product product5 = new Product("PureTone Headphones", "PTH-550", 44.98, 6);
        Product product6 = new Product("BrightLife LED Bulbs (3-pack)", "BLB-660", 8.10, 10);
        Product product7 = new Product("BreezeAir Mini Fan", "BAMF-770", 23.38, 4);

        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);
        order2.AddProduct(product7);

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order2.GetTotalPrice().ToString("F2")}\n");
    }
}
