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
            displayMenu();
        }


        public static void displayMenu()
        {
            OrderOps user = new OrderOps();
            bool quit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("====================\t\t{0}\n\n", DateTime.Now.ToString("MM/dd/yyyy"));
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
                        Console.Clear();
                        Console.Write("Enter a date (MM/DD/YYYY): ");
                        string userDate = Console.ReadLine();
                        user.displayOrders(userDate);
                        break;
                    case "2":
                        user.AddOrder();
                        break;
                    case "3":
                        user.AskToEdit();
                        break;
                    case "4":
                        user.RemoveOrder();
                        break;
                    case "5":
                        quit = QuitMenu();
                        break;
                    default:
                        Console.WriteLine("That was not a valid input.\nPress enter then try again.");
                        Console.ReadLine();
                        break;
                }
            } while (!quit);
        }

        public static bool QuitMenu()
        {
            Console.Write("Would you like to Quit the program? (Y/N) ");
            string userInput = Console.ReadLine().ToUpper();
            if (userInput == "Y")
            {
                return true;
            }
            else if (userInput == "N")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Please enter a Yes(Y) or No(N)");
                return false;
            }
        }
    }
}
