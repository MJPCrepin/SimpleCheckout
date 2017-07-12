using System;

namespace Checkout
{
    public class Program
    {

        public static void Main(string[] args)
        {

            // Instantiate till and set legal items (could also be done from ext src)
            Checkout till = new Checkout();
            till.inventory.Add("apple", 0.6);
            till.inventory.Add("orange", 0.25);

            // Start tests
            initiateTests(till);

            // Normal operation mode
            Console.WriteLine("\nThank you for using SimpleCheckout, here is your receipt:");
            till.returnTotal(args);

            // Prevent Exit
            Console.ReadLine();
        }

        private static void initiateTests(Checkout till)
        {
            int testNumber = 1;

            Console.WriteLine("Initiating system tests: \n");

            // Check if legal items are set
            Console.WriteLine("\n"+testNumber + ": Check if legal items are set" + "\n");
            try
            {
                Console.WriteLine("Items currently for sale:");
                foreach (var x in till.inventory) Console.WriteLine(x.Key + ": " + x.Value + " GBP");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("\nExpected result:");
                Console.WriteLine("apple: 0.6 GBP");
                Console.WriteLine("orange: 0.25 GBP");

                testNumber++;
                till.reset();
                Console.WriteLine("-----------------------------------------------------");
            }


            // Check if you can add an apple from a list
            Console.WriteLine("\n" + testNumber + ": Check if you can add an apple from a list" + "\n");
            try
            {
                string[] args = { "apple" };
                till.returnTotal(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("\nExpected result:");
                Console.WriteLine("1x apple @ 0.6 GBP");
                Console.WriteLine("Total: 0.6 GBP");

                testNumber++;
                till.reset();
                Console.WriteLine("-----------------------------------------------------");
            }

            // Check if you can add an orange from a list
            Console.WriteLine("\n" + testNumber + ": Check if you can add an orange from a list" + "\n");
            try
            {
                string[] args = { "orange" };
                till.returnTotal(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("\nExpected result:");
                Console.WriteLine("1x orange @ 0.25 GBP");
                Console.WriteLine("Total: 0.25 GBP");

                testNumber++;
                till.reset();
                Console.WriteLine("-----------------------------------------------------");
            }

            // Add 3 apples and 3 oranges
            Console.WriteLine("\n" + testNumber + ": Add 3 apples and 3 oranges" + "\n");
            try
            {
                string[] args = { "apple","apple","apple","orange","orange","orange" };
                till.returnTotal(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("\nExpected result:");
                Console.WriteLine("3x apple @ 0.6 GBP");
                Console.WriteLine("3x orange @ 0.25 GBP");
                Console.WriteLine("Total: 2.55 GBP");

                testNumber++;
                Console.WriteLine("-----------------------------------------------------");
            }

            // Add 1 more of each
            Console.WriteLine("\n" + testNumber + ": Add 1 more of each" + "\n");
            try
            {
                string[] args = { "apple", "orange" };
                till.returnTotal(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("\nExpected result:");
                Console.WriteLine("4x apple @ 0.6 GBP");
                Console.WriteLine("4x orange @ 0.25 GBP");
                Console.WriteLine("Total: 3.4 GBP");

                testNumber++;
                till.reset();
                Console.WriteLine("-----------------------------------------------------");
            }

            // Try buying illegal item (avocado)
            Console.WriteLine("\n" + testNumber + ": Try buying illegal item" + "\n");
            try
            {
                string[] args = { "avocado" };
                till.returnTotal(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("\nExpected result:");
                Console.WriteLine("Invalid item: avocado isn't for sale!");
                Console.WriteLine("Total: 0 GBP");

                testNumber++;
                till.reset();
                Console.WriteLine("-----------------------------------------------------");
            }

            // Try buying legal item in non normalised form (ALL CAPS) (eg ORANGE)
            Console.WriteLine("\n" + testNumber + ": Try buying legal item in non normalised form (ALL CAPS)" + "\n");
            try
            {
                string[] args = { "ORANGE" };
                till.returnTotal(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("\nExpected result:");
                Console.WriteLine("1x orange @ 0.25 GBP");
                Console.WriteLine("Total: 0.25 GBP");

                testNumber++;
                till.reset();
                Console.WriteLine("-----------------------------------------------------");
            }

            // Try buying from empty list
            Console.WriteLine("\n" + testNumber + ": Try buying from empty list" + "\n");
            try
            {
                string[] args = {};
                till.returnTotal(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("\nExpected result:");
                Console.WriteLine("Total: 0 GBP");

                testNumber++;
                till.reset();
                Console.WriteLine("-----------------------------------------------------");
            }

        }


        
    }
}