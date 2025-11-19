
namespace ProductInventory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Inventory //this class will manage the list of products 
    {
        List<Product> products = new List<Product>(); //creating an empty list to hold product objects


        public void AddProduct(Product product) //method to add procuts to list
        {
            products.Add(product);
        }

        public List<Product> GetProduct() //method to return the entier list of the products
        {
            return products;
        }

        public void GetProdDetails(string name) //  method to return the details of the product based on the name provided
        {
            foreach (Product prod in products)
            {
                if (prod.Name == name)
                {
                    Console.WriteLine($"Product Name: {prod.Name}, Price: {prod.Price}, Quantity: {prod.Quantity}");
                }
            }

        }

        public void UpdateProduct(string name, string newName, double price, int quantity) //method to update the details of the current product
        {
            foreach (Product prod in products)
            {
                if (prod.Name == name)
                {
                    Console.WriteLine($"is this the correct product to update? Name:{prod.Name}, Price: {prod.Price}, Quantity: {prod.Quantity} Y/N");
                    string answer = Console.ReadLine();// add exception handling here 

                    switch (answer)
                    {
                        case "y":
                            prod.Name = newName;
                            prod.Price = price;
                            prod.Quantity = quantity;
                            Console.WriteLine("Product updated successfully.");
                            return;
                    }
                }
            }
        }

        public void RemoveProduct(string name) //method to remove a product from the inventory to remove 
        {
            for(int i = products.Count-1; i>=0; i--) //have to use for loop to avoid collection modified exception
            {
                
                if (products[i].Name == name)
                {
                    Console.WriteLine($"is this the correct product you want to remove? Name:{products[i].Name}, Price: {products[i].Price}, Quantity: {products[i].Quantity} Y/N");
                    string answer = Console.ReadLine().ToLower();

                    switch (answer)
                    {
                        case "y":
                            products.Remove(products[i]);
                            break;
                    }
                }
            }
        }
    }
}

