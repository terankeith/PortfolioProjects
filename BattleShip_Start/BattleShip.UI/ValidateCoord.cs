using BattleShip.BLL.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class ValidateCoord
    {
        //translates user input string coordinate into int coordinate
        //run this code everytime a user inputs a coordinate
        public static Coordinate getValidCoord(string userInput)
        {
            int x = 0;
            int y;
            bool valid = false;

            string XCoordinate = userInput.Substring(0, 1);
            string YCoordinate = userInput.Substring(1, userInput.Length - 1);
            switch (XCoordinate)
            {
                case "A":
                    x++;
                    break;
                case "B":
                    x += 2;
                    break;
                case "C":
                    x += 3;               
                    break;
                case "D":
                    x += 4;
                    break;
                case "E":
                    x += 5;
                    break;
                case "F":
                    x += 6;
                    break;
                case "G":
                    x += 7;
                    break;
                case "H":
                    x += 8;
                    break;
                case "I":
                    x += 9;
                    break;
                case "J":
                    x += 10;
                    break;
                default:
                    Console.Write("That was not vaild input.");
                    return null;
            }

            do
            {
                if (int.TryParse(YCoordinate, out y))
                {
                    if (y >= 1 && y <= 10)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("That coordinate is not on the board.");
                        valid = true;
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("That was not a valid input.");
                    valid = true;
                    return null;
                }
            } while (!valid);
            
            return new Coordinate(x, y);
            
        }
    }
}
