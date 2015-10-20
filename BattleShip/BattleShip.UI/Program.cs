using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            GamePlay playGame = new GamePlay();
            do
            {
                playGame.displayMenu();
                playGame.play();
                if (QuitGame())
                {
                    quit = true;
                }
                else
                {
                    quit = false;
                }
            } while (!quit);
           
        }

        private static bool QuitGame()
        {
            bool isValid = false;
            bool quit = false;
            do
            {
                Console.Write("Would you like to Quit?(Y/N)");
                string input = Console.ReadLine().ToUpper();
                if (input == "Y" || input == "YES")
                {
                    isValid = true;
                    quit = true;
                }
                else if (input == "N" || input == "NO")
                {
                    isValid = true;
                    quit = false;
                }
                else
                {
                    Console.Write("Please respond (Y)es or (N)o.");
                }
            } while (!isValid);
            return quit;
        }
    }
}
