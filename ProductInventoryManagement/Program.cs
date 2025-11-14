// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;

namespace ProductInventory
{
    public class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Please choose between the following options:\n" +
                    "1.Add New Product \n2.Remove Product \n3.Search Product \n4.Update Item \n5.View All Products");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // Add New Product
                        Console.WriteLine("Enter Product Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the Product Price:");
                        int price = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Product Quantity:");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        inventory.AddProduct(new Product(name, quantity, price));
                        break;

                    case "2": // Remove Product
                        Console.WriteLine("Enter the name of the product to remove:");
                        Console.ReadKey();
                        break;

                    case "3":// Search Product Details
                        Console.WriteLine("Enter the name of the product to search:");
                        inventory.GetProdDetails(Console.ReadLine());
                        break;
                    case "4":
                        Console.WriteLine("Please enter the name of the product to update:");
                        string prodName = Console.ReadLine();
                        Console.WriteLine("Enter the new Price:");
                        int newPrice = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the new Quantity:");
                        int newQuantity = int.Parse(Console.ReadLine());
                        inventory.UpdateProduct(prodName, newPrice, newQuantity);
                        break;
                    case "5": // View All Products
                        List<Product> products = inventory.GetProduct();
                        foreach (Product prod in products)
                        {
                            Console.WriteLine(prod.ToString());
                        }
                        break;

                }

                Console.ReadKey();
            }
        }

    }

    public class Product
    {
        private int _price;
        private int _quantity;
        private string _name;

        //constructor

        public Product(string name, int quantity, int price)
        {
            this._price = price;
            this._quantity = quantity;
            this._name = name;
        }

        // lets set some properties with basic validation
        public int Price
        {
            get { return _price; }

            set
            {
                if (value >= 0)
                {
                    _price = value;
                }
            }
        }

        public int Quantity
        {

            get { return _quantity; }

            set
            {
                if (value >= 0)
                {
                    _quantity = value;
                }
            }
        }

        public string Name
        {
            get { return _name; }

            set
            {
                if (value != null)
                {
                    _name = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} - ${Price} - {Quantity} units";
        }
    }

}


