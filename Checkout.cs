using System;
using System.Collections.Generic;

namespace Checkout
{

    class Checkout
    {
        // Set of legal items for sale
        public Dictionary<string, double> inventory = new Dictionary<string, double>();

        // Set of current items checked with quantity for each item
        private Dictionary<string, int> cart = new Dictionary<string, int>();

        public double returnTotal(string[] list)
        {
            parseList(list);
            printReceipt();
            return calculateTotal();
        }

        private void parseList(string[] list)
        {
            foreach (var token in list)
            {
                // Normalise tokens (lowercase)
                var x = token.ToLower();

                // If legal item, add to cart, else warn & continue

                if (inventory.ContainsKey(x))
                {
                    if (cart.ContainsKey(x))
                    {
                        cart[x]++;
                    }
                    else
                    {
                        cart.Add(x, 1);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid item: " + x + " isn't for sale!");
                }

            }
        }

        private double calculateTotal()
        {
            // For each item multiply cart counter with inventory price
            double total = 0;
            foreach (var x in cart)
            {
                total += x.Value * inventory[x.Key];
            }
            return total;
        }

        private void printReceipt()
        {
            calculateTotal();
            foreach (var x in cart) Console.WriteLine(x.Value+"x "+x.Key+" @ "+ inventory[x.Key].ToString() + " GBP");
            Console.WriteLine("Total: " + calculateTotal().ToString()+ " GBP");
        }

        public void reset()
        {
            cart.Clear();
            Console.WriteLine("\n[Checkout reset]");
        }
    }
}
