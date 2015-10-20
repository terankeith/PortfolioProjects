using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Data.OrderRepos;
using FlooringProgram.Data.TaxRates;
using System.IO;

namespace FlooringProgram.Operations
{
    public class OrderOps
    {
        // GetOrdersOnDay()

        public void AddOrder()
        {
            Order OrderToAdd = AskToAdd();
            AddOrderResponse resp = GetAddResponse(OrderToAdd);
        }

        // EditOrder()

        // Remove Order()

        public AddOrderResponse GetAddResponse(Order anOrder)
        {
            IOrderRepo repo1 = OrderRepoFactory.GetOrderRepository();
            var AllOrders = repo1.GetOrders();
            AllOrders.Add(anOrder);
            Console.WriteLine(AllOrders);
            
            return new AddOrderResponse();
        }

        public Order AskToAdd()
        {
            bool valid = false;
            Order newOrder = new Order();

            do
            {
                Console.Write("Customer's Name: ");
                newOrder.CustomerName = setCustomerName(Console.ReadLine());
                newOrder.State = setState();
                TaxRateOperations tops = new TaxRateOperations();
                TaxRate t1 = tops.GetTaxRateFor(newOrder.State);
                newOrder.TaxRate = t1.TaxPercent;
                newOrder.ProductType = setProductType();
                ProductOps p1 = new ProductOps();
                Product prod1 = p1.GetProduct(newOrder.ProductType);
                newOrder.CostPerSquareFoot = prod1.CostPerSquareFoot;
                newOrder.LaborCostPerSquareFoot = prod1.LaborCostPerSquareFoot;
                newOrder.Area = setArea();
                newOrder.LaborCost = (newOrder.LaborCostPerSquareFoot * newOrder.Area);
                newOrder.MaterialCost = (newOrder.CostPerSquareFoot * newOrder.Area);
                newOrder.Tax = ((newOrder.LaborCost + newOrder.MaterialCost) * newOrder.TaxRate);
                newOrder.Total = newOrder.LaborCost + newOrder.MaterialCost + newOrder.Tax;

                Console.WriteLine("The order to be added:\n");
                Console.WriteLine("Customer Name: {0}", newOrder.CustomerName);
                Console.WriteLine("State: {0}", newOrder.State);
                Console.WriteLine("Tax Rate: {0}", newOrder.TaxRate);
                Console.WriteLine("ProductType: {0}", newOrder.ProductType);
                Console.WriteLine("Area: {0}", newOrder.Area);
                Console.WriteLine("Cost Per Sq Ft: {0}", newOrder.CostPerSquareFoot);
                Console.WriteLine("Labor Cost Per Sq Ft: {0}", newOrder.LaborCostPerSquareFoot);
                Console.WriteLine("Labor Cost: {0}", newOrder.LaborCost);
                Console.WriteLine("Material Cost: {0}", newOrder.MaterialCost);
                Console.WriteLine("Tax: {0}", newOrder.Tax);
                Console.WriteLine("Total: {0}", newOrder.Total);

                Console.Write("\n\nCommit this order?(Y/N)");

                string input = Console.ReadLine();
                if (input == "Y")
                    valid = true;
                else
                    valid = false;

              } while (!valid);


            return newOrder;
            
        }

        public void displayOrders()
        {
            Console.Clear();
            Console.WriteLine("Enter a date (MM/DD/YYYY): ");
            string userInput = convertDate(Console.ReadLine());
            string[] orderFiles = Directory.GetFiles("Data");
            foreach (string str in orderFiles)
            {
                if (str.Contains(userInput))
                {
                    Console.WriteLine(File.ReadAllText(str));
                    break;
                }
                else
                {
                    Console.WriteLine("That file does not exist.");
                    break;
                }
            }
            Console.ReadLine();
        }

        private string convertDate(string userInput)
        {
            DateTime newDate = DateTime.Parse(userInput);
            return newDate.ToString("MMddyyyy");
        }

        private static string setCustomerName(string name)
        {
            return name;
        }

        private static string setState()
        {
            bool isValid = false;
            string state;
            do
            {
                Console.Write("State: ");
                state = Console.ReadLine();

                TaxRateOperations taxOps = new TaxRateOperations();
                if (taxOps.IsAllowedState(state))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("We do not operate in that state.");
                }
            } while (!isValid);

            return state;
        }

        private static string setProductType()
        {
            bool isValid = false;
            string type;
            do
            {
                Console.Write("Product Type: ");
                type = Console.ReadLine();
                if (ProductOps.isValidProductType(type))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("We do not have that type of product.");
                }
            } while (!isValid);

            return type;
        }

        private static decimal setArea()
        {
            string userArea;
            bool isValid = false;
            decimal userDec;
            do
            {
                Console.Write("Area: ");
                userArea = Console.ReadLine();
                if (decimal.TryParse(userArea, out userDec))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("That was not valid, please enter your value again.");
                }
            } while (!isValid);

            return userDec;
        }
    }
}
