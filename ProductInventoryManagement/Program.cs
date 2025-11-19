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

                        // --- asking for price with input validation -------------------------------------

                        Console.WriteLine("Enter the Product Price:");
                        /* int price = Convert.ToInt32(Console.ReadLine());// this is vulnerable to exceptions */
                        string price = Console.ReadLine();
                        bool isValidPrice = double.TryParse(price, out double parsedPrice);
                        while (!isValidPrice) {  //while loop to repet until valid input is provided 
                            Console.WriteLine("Please enter a valid number for the price.");
                            string newInput = Console.ReadLine();
                            isValidPrice = double.TryParse(newInput, out parsedPrice);
                        }

                        // -- asking for quantity with a slightly different approach. asking for only input one time rather than twice 

                        bool isValidQuantity = false;
                        int quantity =0;
                        while (!isValidQuantity){
                            Console.WriteLine("Enter the Product Quantity:");
                            bool quantityInput = int.TryParse(Console.ReadLine(), out quantity);
                            if (quantityInput){
                                isValidQuantity = true;
                                break;
                            }
                        }
                        inventory.AddProduct(new Product(name, quantity, parsedPrice));
                        break;

                    case "2": // Remove Product (Need to add in product not found handling)
                        Console.WriteLine("Enter the name of the product to remove:");
                        string prodToRemove = Console.ReadLine();
                        inventory.RemoveProduct(prodToRemove);
                        break;

                    case "3":// Search Product Details
                        Console.WriteLine("Enter the name of the product to search:");
                        inventory.GetProdDetails(Console.ReadLine());
                        break;
                    case "4": // update item (need to add edit name)
                        Console.WriteLine("Please enter the name of the product to update:");
                        string prodName = Console.ReadLine();
                        Console.WriteLine("Please enter the new name of the prodcut:");
                        string newName = Console.ReadLine();
                        Console.WriteLine("Enter the new Price:");
                        int newPrice = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the new Quantity:");
                        int newQuantity = int.Parse(Console.ReadLine());
                        inventory.UpdateProduct(prodName,newName, newPrice, newQuantity);
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
        private double _price;
        private int _quantity;
        private string _name;

        //constructor

        public Product(string name, int quantity, double price)
        {
            this._price = price;
            this._quantity = quantity;
            this._name = name;
        }

        // lets set some properties with basic validation
        public double Price
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


