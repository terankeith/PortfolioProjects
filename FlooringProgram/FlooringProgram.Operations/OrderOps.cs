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

            // changes
        public void AddOrder()
        {
            AddOrderResponse response = new AddOrderResponse();
            Order OrderToAdd = AskToAdd();

            OrderToAdd.OrderNumber = SetOrderNumber();
            List<Order> NewList = AddingOrder(OrderToAdd);
            response.text = "The order was succesfully added!\n(press enter to continue)";
            response.WasAdded = true;
            // else wasnt added display error
            Console.WriteLine(response.text);

            // if production mode
            string[] NewOrders = new string[NewList.Count()];
            foreach (var order in NewList)
            {
                NewOrders[order.OrderNumber -1] = (order.OrderNumber + "," + order.CustomerName + "," + order.State + "," + order.TaxRate + "," + order.ProductType + "," + order.Area + "," + order.CostPerSquareFoot + "," + order.LaborCostPerSquareFoot + "," + order.MaterialCost + "," + order.LaborCost + "," + order.Tax + "," + order.Total);
            }
            File.WriteAllLines(@".\Data\Orders_06012013.txt", NewOrders);                       
            Console.ReadLine();
        }

        public int SetOrderNumber()
        {
            int x;
            IOrderRepo repo1 = OrderRepoFactory.GetOrderRepository();
            var AllOrders = repo1.GetOrders("06012013");
            x = AllOrders.Count();
            x += 1; // because list is zero index, order numbers are not
            return x;
        }

        public void AskToEdit()
        {            
            Console.Clear();
            IOrderRepo repo = OrderRepoFactory.GetOrderRepository();
            Console.Write("Enter a date (MM/DD/YYYY): ");
            string userInput = Console.ReadLine();
            string userDate = convertDate(userInput);
                       
            if (userDate == "Error")
            {
                Console.WriteLine("That was not a valid date.");
                Console.ReadLine();
            }  
            else
            {
                displayOrders(userInput);
                Console.Write("Enter an order number to edit: ");
                string stringNum = Console.ReadLine();
                int userInt = int.Parse(stringNum);
                Console.Clear();
                Console.WriteLine("This is the order to be edited.");
                EditOrder(userDate, userInt);
            }                    
        }

        public void RemoveOrder()
        {
            bool shouldRemove = false;

            IOrderRepo repo1 = OrderRepoFactory.GetOrderRepository();
            string[] str = PromptRemove();
            var AllOrders = repo1.GetOrders(str[0]);
            shouldRemove = ValidateRemove(str);
            if (shouldRemove == true && int.Parse(str[1]) > 0 && int.Parse(str[1]) <= AllOrders.Count())
            {
                List<Order> newList = MakeRemove(AllOrders, str[1]);
                newList = ResetOrderNumbs(newList);

                string[] NewOrders = new string[newList.Count()];
                foreach (var order in newList)
                {
                    NewOrders[order.OrderNumber - 1] = (order.OrderNumber + "," + order.CustomerName + "," + order.State + "," + order.TaxRate + "," + order.ProductType + "," + order.Area + "," + order.CostPerSquareFoot + "," + order.LaborCostPerSquareFoot + "," + order.MaterialCost + "," + order.LaborCost + "," + order.Tax + "," + order.Total);
                }

               
                File.WriteAllLines(@".\Data\Orders_06012013.txt", NewOrders); 
            }
            else
            {
                Console.WriteLine("Error. The order could not be removed.");
            }
        }

        public List<Order> ResetOrderNumbs(List<Order> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].OrderNumber = (i + 1);
            }
            return list;
        }

        public List<Order> MakeRemove(List<Order> orders, string orderNumb)
        {

            orders.RemoveAt(int.Parse(orderNumb) - 1);
              
            return orders;
        }

        public bool ValidateRemove(string[] string1)
        {
            Console.WriteLine("Remove the following order?\nDate of Order: {0}\nOrder Number: {1}", string1[0], string1[1]);
            string input = Console.ReadLine();
            if (input == "Y" || input == "y" || input == "Yes")
            {

                return true;
            }
            else
                return false;              
        }

        public string[] PromptRemove()
        {
            bool validDate = false;
            bool validNumb = false;
            int numb = 0;

            string[] arr = new string[2];
            do
            {
                Console.WriteLine("What is the date of the order you'd like to remove? (mm/dd/yyyy)");
                string date = Console.ReadLine();
                arr[0] = convertDate(date);
                if (arr[0] != "Error")
                    validDate = true;
            } while (!validDate);

            do
            {
                Console.WriteLine("Enter the order number to be removed.");
                arr[1] = Console.ReadLine();
                if (int.TryParse(arr[1], out numb) && int.Parse(arr[1]) > 0)
                    validNumb = true;
                else
                    Console.WriteLine("An error occured attempting to process your desired order number");
            } while (!validNumb);
            return arr;
        }
        
        public List<Order> AddingOrder(Order anOrder)
        {

            IOrderRepo repo1 = OrderRepoFactory.GetOrderRepository();
            var AllOrders = repo1.GetOrders("06012013");
            AllOrders.Add(anOrder);
            return AllOrders;
        }

        private Order AskToAdd()
        {
            bool valid = false;
            bool isValidName = true;
            bool isValidState = false;
            bool isValidArea = false;
            decimal userDec;
            Order newOrder = new Order();

            do
            {
                Console.Clear();
                do
                {
                    Console.Write("Customer's Name: ");
                    newOrder.CustomerName = Console.ReadLine();
                    if (newOrder.CustomerName == "")
                    {
                        isValidName = false;
                    }
                    else
                    {
                        isValidName = true;
                    }
                } while (!isValidName);
                do
                {
                    Console.Write("\nState: ");
                    string userState = Console.ReadLine().ToUpper();
                    if (userState != "")
                    {
                        TaxRateOperations taxOps = new TaxRateOperations();

                        if (taxOps.IsAllowedState(userState))

                        {
                            isValidState = true;
                            newOrder.State = userState;
                        }
                        else
                        {
                            Console.Write("\nWe do not operate in that state.\n");
                        }
                    }                                        
                } while (!isValidState);
             
                TaxRateOperations tops = new TaxRateOperations();
                TaxRate t1 = tops.GetTaxRateFor(newOrder.State);
                newOrder.TaxRate = t1.TaxPercent;
                
                newOrder.ProductType = setProductType();
                ProductOps p1 = new ProductOps();
                Product prod1 = p1.GetProduct(newOrder.ProductType);
                newOrder.CostPerSquareFoot = prod1.CostPerSquareFoot;
                newOrder.LaborCostPerSquareFoot = prod1.LaborCostPerSquareFoot;
                    
              
                do
                {
                    Console.Write("\nArea: ");
                    string userArea = Console.ReadLine();

                    if (decimal.TryParse(userArea, out userDec))
                    {
                        isValidArea = true;
                        newOrder.Area = userDec;
                    }
                    else
                    {
                        Console.WriteLine("\nThat was not a valid number.");
                    }
                } while (!isValidArea);
                Console.WriteLine("\n====================");
                newOrder.LaborCost = (newOrder.LaborCostPerSquareFoot * newOrder.Area);
                newOrder.MaterialCost = (newOrder.CostPerSquareFoot * newOrder.Area);
                newOrder.Tax = ((newOrder.LaborCost + newOrder.MaterialCost) * (newOrder.TaxRate / 100.0M));
                newOrder.Total = newOrder.LaborCost + newOrder.MaterialCost + newOrder.Tax;

                Console.WriteLine("\nThe order to be added:\n");
                Console.WriteLine("Customer Name: {0}", newOrder.CustomerName);
                Console.WriteLine("State: {0}", newOrder.State);
                Console.WriteLine("Tax Rate: {0}", newOrder.TaxRate);
                Console.WriteLine("ProductType: {0}", newOrder.ProductType.ToUpper());
                Console.WriteLine("Area: {0}", newOrder.Area);
                Console.WriteLine("Cost Per Sq Ft: {0}", newOrder.CostPerSquareFoot);
                Console.WriteLine("Labor Cost Per Sq Ft: {0}", newOrder.LaborCostPerSquareFoot);
                Console.WriteLine("Labor Cost: {0}", newOrder.LaborCost);
                Console.WriteLine("Material Cost: {0}", newOrder.MaterialCost);
                Console.WriteLine("Tax: {0}", newOrder.Tax);
                Console.WriteLine("Total: {0}", newOrder.Total);


                Console.Write("\n\nCommit this order?(Y/N) ");
                string input = Console.ReadLine().ToUpper();

                if (input == "Y")
                {
                    valid = true;
                }
                else 
                {
                    Console.WriteLine("\nPress enter to return to the main menu.");
                    //Console.ReadLine();
                    //MenuOps.displayMenu();
                }                 
              } while (!valid);
            
            return newOrder;           

            
        }

        public void displayOrders(string userInput)
        {
            string userDate = convertDate(userInput); 
            if (userDate == "Error")
            {
                Console.WriteLine("That was not a valid date.");
                Console.ReadLine();
            }
            else
            {
                IOrderRepo repo = OrderRepoFactory.GetOrderRepository();
                var AllOrders = repo.GetOrders(userDate);
                foreach (var order in AllOrders)
                {
                    Console.WriteLine("\nOrder Number: {0}", order.OrderNumber);
                    Console.WriteLine("Customer Name: {0}", order.CustomerName);
                    Console.WriteLine("State: {0}", order.State);
                    Console.WriteLine("Tax Rate: {0}", order.TaxRate);
                    Console.WriteLine("Product Type: {0}", order.ProductType);
                    Console.WriteLine("Area: {0}", order.Area);
                    Console.WriteLine("Cose Per Square Foot: {0}", order.CostPerSquareFoot);
                    Console.WriteLine("Labor Cost Per Square Foot: {0}", order.LaborCostPerSquareFoot);
                    Console.WriteLine("Material Cost: {0}", order.MaterialCost);
                    Console.WriteLine("Labor Cost: {0}", order.LaborCost);
                    Console.WriteLine("Tax: {0}", order.Tax);
                    Console.WriteLine("Total: {0}", order.Total);
                    Console.WriteLine("\n====================");
                }
                Console.ReadLine();
            }
            
        }

        private void DisplayOrderToEdit(string userDate, int userInt) // this can change it is only here to display the order to be edited, but the edit order method could do the same thing
        {
            IOrderRepo repo = OrderRepoFactory.GetOrderRepository();
            var AllOrders = repo.GetOrders(userDate);
            foreach (var order in AllOrders)
            {
                if (userInt == order.OrderNumber)
                {                 
                    Console.WriteLine("Customer Name: {0}", order.CustomerName);
                    Console.WriteLine("State: {0}", order.State);
                    Console.WriteLine("Product Type: {0}", order.ProductType);
                    Console.WriteLine("Area: {0}", order.Area);                    
                }
                // if the user enters an order number that is not there, what happens?
            }
            Console.ReadLine();           
        }

        private void EditOrder(string userDate, int userInt)
        {
            bool isValidState = true;
            decimal userDec;
            bool isValidArea = true;
            DisplayOrderToEdit(userDate, userInt);
            IOrderRepo repo = OrderRepoFactory.GetOrderRepository();
            var AllOrders = repo.GetOrders(userDate);

            foreach (var order in AllOrders)
            {
                if (userInt == order.OrderNumber)
                {                    
                    Console.Write("Customer's Name: ");                    
                    string userName = Console.ReadLine();
                    if (userName != "")
                    {
                        order.CustomerName = userName;
                    }

                    do
                    {
                        Console.Write("\nState: ");
                        string userState = Console.ReadLine().ToUpper();
                        if (userState != "")
                        {
                            TaxRateOperations taxOps = new TaxRateOperations();

                            if (taxOps.IsAllowedState(userState))

                            {
                                isValidState = true;
                                order.State = userState;
                            }
                            else
                            {
                                Console.Write("\nWe do not operate in that state.\n");
                                isValidState = false;
                            }
                        }
                    } while (!isValidState);

                    TaxRateOperations tops = new TaxRateOperations();
                    TaxRate t1 = tops.GetTaxRateFor(order.State);
                    order.TaxRate = t1.TaxPercent;

                    Console.Write("\nProduct Type: ");
                    string userType = Console.ReadLine();
                    if (userType != "")
                    {
                        order.ProductType = userType;
                    }

                    ProductOps p1 = new ProductOps();
                    Product prod1 = p1.GetProduct(order.ProductType);
                    order.CostPerSquareFoot = prod1.CostPerSquareFoot;
                    order.LaborCostPerSquareFoot = prod1.LaborCostPerSquareFoot;

                    do
                    {
                        Console.Write("\nArea: ");
                        string userArea = Console.ReadLine();
                        if (userArea != "")
                        {
                            if (decimal.TryParse(userArea, out userDec))
                            {
                                isValidArea = true;
                                order.Area = userDec;
                            }
                            else
                            {
                                Console.WriteLine("\nThat was not a valid number.");
                                isValidArea = false;
                            }
                        }
                    } while (!isValidArea);

   
                    order.LaborCost = (order.LaborCostPerSquareFoot * order.Area);
                    order.MaterialCost = (order.CostPerSquareFoot * order.Area);
                    order.Tax = ((order.LaborCost + order.MaterialCost) * (order.TaxRate / 100.0M));
                    order.Total = order.LaborCost + order.MaterialCost + order.Tax;

                    Console.WriteLine("\nThe order to be edited:\n");
                    Console.WriteLine("\nOrder Number: {0}", order.OrderNumber);
                    Console.WriteLine("Customer Name: {0}", order.CustomerName);
                    Console.WriteLine("State: {0}", order.State);
                    Console.WriteLine("Tax Rate:{0}", order.TaxRate);
                    Console.WriteLine("ProductType: {0}", order.ProductType);
                    Console.WriteLine("Area: {0}", order.Area);
                    Console.WriteLine("Cost Per Sq Ft: {0}", order.CostPerSquareFoot);
                    Console.WriteLine("Labor Cost Per Sq Ft: {0}", order.LaborCostPerSquareFoot);
                    Console.WriteLine("Labor Cost: {0}", order.LaborCost);
                    Console.WriteLine("Material Cost: {0}", order.MaterialCost);
                    Console.WriteLine("Tax: {0}", order.Tax);
                    Console.WriteLine("Total: {0}", order.Total);                   
                    
                    Console.ReadLine();                   
                }
                
                //string[] NewOrders = new string[AllOrders.Count];
                //{
                //    NewOrders[order.OrderNumber - 1] = (order.OrderNumber + "," + newOrder.CustomerName + "," + newOrder.State + "," + newOrder.TaxRate + "," + newOrder.ProductType + "," + newOrder.Area + "," + newOrder.CostPerSquareFoot + "," + newOrder.LaborCostPerSquareFoot + "," + newOrder.MaterialCost + "," + newOrder.LaborCost + "," + newOrder.Tax + "," + newOrder.Total);
                //}
                //File.WriteAllLines(@"C:\MasteryProject\FlooringProgram\FlooringProgram.UI\Data\Orders_06012013.txt", NewOrders); //Teran File Path      
            }

            string[] NewOrders = new string[AllOrders.Count()];
            foreach (var order in AllOrders)
            {
                NewOrders[order.OrderNumber - 1] = (order.OrderNumber + "," + order.CustomerName + "," + order.State + "," + order.TaxRate + "," + order.ProductType + "," + order.Area + "," + order.CostPerSquareFoot + "," + order.LaborCostPerSquareFoot + "," + order.MaterialCost + "," + order.LaborCost + "," + order.Tax + "," + order.Total);
            }
            File.WriteAllLines(@".\Data\Orders_06012013.txt", NewOrders); //Teran File Path      
        }
      
        private string convertDate(string userInput)
        {
            DateTime newDate;

            if (DateTime.TryParse(userInput, out newDate))
            {
                return newDate.ToString("MMddyyyy");
            }

            else
            {
                //Console.WriteLine("\nThat was not a valid date.");
                return "Error";
            }
        }

        private static string setState(string userState)
        {
            bool isValid = false;
            do
            {                
                TaxRateOperations taxOps = new TaxRateOperations();

                if (taxOps.IsAllowedState(userState.ToUpper()))

                {
                    isValid = true;
                }
                else
                {
                    Console.Write("\nWe do not operate in that state.");                    
                }
            } while (!isValid);

            return userState.ToUpper();
        }

        private static string setProductType()
        {
            bool isValid = false;
            string type;
            do
            {
                Console.Write("\nProduct Type: ");
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

        private static decimal setArea(string input)
        {
            bool isValid = false;
            decimal userDec;
            do
            {               
                if (decimal.TryParse(input, out userDec))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("That was not a valid number.");                  
                }
            } while (!isValid);

            return userDec;
        }
    }
}
