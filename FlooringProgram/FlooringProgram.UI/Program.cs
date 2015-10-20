using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Operations;

namespace FlooringProgram.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================\n\n");
            Console.WriteLine("Flooring Program\n\n");
            Console.WriteLine("1. Display Order");
            Console.WriteLine("\n2. Add Order");
            Console.WriteLine("\n3. Edit Order");
            Console.WriteLine("\n4. Remove Order");
            Console.WriteLine("\n5. Quit");
            Console.WriteLine("\n\n====================");
            Console.Write("Select an option 1-5: ");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    OrderOps example = new OrderOps();
                    example.displayOrders();
                    break;
                case "2":
                    OrderOps ops = new OrderOps();
                    ops.AddOrder();
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
            }

            Console.Clear();
            
            /* Console.Write("Enter a state: ");
            string state = Console.ReadLine();

            TaxRateOperations taxOps = new TaxRateOperations();
            if (taxOps.IsAllowedState(state))
            {
                Console.WriteLine("That is a valid state");
                TaxRate rate = taxOps.GetTaxRateFor(state);

                Console.WriteLine("The tax rate for {0} is {1:p}", rate.State, rate.TaxPercent);
            }
            else
            {
                Console.WriteLine("That is not a valid state");
            } */
            
            Console.ReadLine();
        }
    }
}
