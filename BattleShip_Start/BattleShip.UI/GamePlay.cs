using BattleShip.BLL.Requests;
using BattleShip.BLL.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public class GamePlay
    {
        Player player1 = new Player();
        Player player2 = new Player();
        Board player1Board = new Board();
        Board player2Board = new Board();
        PlaceShipRequest Destroyer = new PlaceShipRequest();
        PlaceShipRequest Submarine = new PlaceShipRequest();
        PlaceShipRequest Cruiser = new PlaceShipRequest();
        PlaceShipRequest BattleShip = new PlaceShipRequest();
        PlaceShipRequest Carrier = new PlaceShipRequest();
        bool isVictory = false;
        bool isValidDes1 = false;
        bool isValidSub1 = false;
        bool isValidCru1 = false;
        bool isValidBat1 = false;
        bool isValidCar1 = false;
        bool isValidDes2 = false;
        bool isValidSub2 = false;
        bool isValidCru2 = false;
        bool isValidBat2 = false;
        bool isValidCar2 = false;


        public void play()
        {
            Destroyer.ShipType = ShipType.Destroyer;
            Submarine.ShipType = ShipType.Submarine;
            Cruiser.ShipType = ShipType.Cruiser;
            BattleShip.ShipType = ShipType.Battleship;
            Carrier.ShipType = ShipType.Carrier;

            //Set up for Player 1
            Console.Clear();
            Console.WriteLine("{0}: Place your ships", player1.name);
            do
            {
                SetUpBoard(Destroyer);
                switch (player1Board.PlaceShip(Destroyer))
                {
                    case ShipPlacement.Overlap:
                        Console.WriteLine("There is already a ship there.");
                        break;
                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine("Your ship is not on the board");
                        break;
                    default:
                        isValidDes1 = true;
                        break;
                }
            } while (!isValidDes1);

            do
            {
                SetUpBoard(Submarine);
                switch (player1Board.PlaceShip(Submarine))
                {
                    case ShipPlacement.Overlap:
                        Console.WriteLine("There is already a ship there.");
                        break;
                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine("Your ship is not on the board");
                        break;
                    default:
                        isValidSub1 = true;
                        break;
                }

            } while (!isValidSub1);

            do
            {
                SetUpBoard(Cruiser);
                switch (player1Board.PlaceShip(Cruiser))
                {
                    case ShipPlacement.Overlap:
                        Console.WriteLine("There is already a ship there.");
                        break;
                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine("Your ship is not on the board");
                        break;
                    default:
                        isValidCru1 = true;
                        break;
                }
            } while (!isValidCru1);

            do
            {
                SetUpBoard(BattleShip);
                switch (player1Board.PlaceShip(BattleShip))
                {
                    case ShipPlacement.Overlap:
                        Console.WriteLine("There is already a ship there.");
                        break;
                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine("Your ship is not on the board");
                        break;
                    default:
                        isValidBat1 = true;
                        break;
                }

            } while (!isValidBat1);

            do
            {
                SetUpBoard(Carrier);
                switch (player1Board.PlaceShip(Carrier))
                {
                    case ShipPlacement.Overlap:
                        Console.WriteLine("There is already a ship there.");
                        break;
                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine("Your ship is not on the board");
                        break;
                    default:
                        isValidCar1 = true;
                        break;
                }
            } while (!isValidCar1);


            //Set up for Player 2
            Console.Clear();
            Console.WriteLine("{0}: Place your ships", player2.name);
            do
            {
                SetUpBoard(Destroyer);
                switch (player2Board.PlaceShip(Destroyer))
                {
                    case ShipPlacement.Overlap:
                        Console.WriteLine("There is already a ship there.");
                        break;
                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine("Your ship is not on the board");
                        break;
                    default:
                        isValidDes2 = true;
                        break;
                }
            } while (!isValidDes2);

            do
            {
                SetUpBoard(Submarine);
                switch (player2Board.PlaceShip(Submarine))
                {
                    case ShipPlacement.Overlap:
                        Console.WriteLine("There is already a ship there.");
                        break;
                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine("Your ship is not on the board");
                        break;
                    default:
                        isValidSub2 = true;
                        break;
                }
            } while (!isValidSub2);

            do
            {
                SetUpBoard(Cruiser);
                switch (player2Board.PlaceShip(Cruiser))
                {
                    case ShipPlacement.Overlap:
                        Console.WriteLine("There is already a ship there.");
                        break;
                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine("Your ship is not on the board");
                        break;
                    default:
                        isValidCru2 = true;
                        break;
                }
            } while (!isValidCru2);

            do
            {
                SetUpBoard(BattleShip);
                switch (player2Board.PlaceShip(BattleShip))
                {
                    case ShipPlacement.Overlap:
                        Console.WriteLine("There is already a ship there.");
                        break;
                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine("Your ship is not on the board");
                        break;
                    default:
                        isValidBat2 = true;
                        break;
                }
            } while (!isValidBat2);

            do
            {
                SetUpBoard(Carrier);
                switch (player2Board.PlaceShip(Carrier))
                {
                    case ShipPlacement.Overlap:
                        Console.WriteLine("There is already a ship there.");
                        break;
                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine("Your ship is not on the board");
                        break;
                    default:
                        isValidCar2 = true;
                        break;
                }
            } while (!isValidCar2);


            //Turns
            do
            {
                player1Turn();
                if (isVictory)
                    break;
                player2Turn();
                if (isVictory)
                    break;
            } while (!isVictory);



        }

        public PlaceShipRequest SetUpBoard(PlaceShipRequest request)
        {
            bool isValid = false;
            Coordinate validCoord;
            do
            {
                Console.Write("Pick a coordinate for your {0}: ", request.ShipType.ToString());
                string userInput = Console.ReadLine().ToUpper();
                validCoord = ValidateCoord.getValidCoord(userInput);
                if (validCoord == null)
                {
                    Console.WriteLine("That was not a valid coordinate.");
                }
                else
                {
                    isValid = true;
                }
            } while (!isValid);

            request.Coordinate = validCoord;
            Console.Write("Choose a direction UP, DOWN, LEFT, RIGHT: ");
            string userDirection = Console.ReadLine().ToUpper();
            switch (userDirection)
            {
                case "UP":
                    request.Direction = ShipDirection.Up;
                    break;
                case "DOWN":
                    request.Direction = ShipDirection.Down;
                    break;
                case "LEFT":
                    request.Direction = ShipDirection.Left;
                    break;
                case "RIGHT":
                    request.Direction = ShipDirection.Right;
                    break;
            }
            Console.Clear();
            return request;
        }

        public void displayMenu()
        {
            bool isEmpty = true;

            Console.WriteLine(@"
  ____       _______ _______ _      ______  _____ _    _ _____ _____
 |  _ \   /\|__   __|__   __| |    |  ____|/ ____| |  | |_   _|  __ \ 
 | |_) | /  \  | |     | |  | |    | |__  | (___ | |__| | | | | |__) |
 |  _ < / /\ \ | |     | |  | |    |  __|  \___ \|  __  | | | |  ___/ 
 | |_) / ____ \| |     | |  | |____| |____ ____) | |  | |_| |_| |     
 |____/_/    \_\_|     |_|  |______|______|_____/|_|  |_|_____|_| 


                            Press Enter");
            Console.ReadLine();
            do
            {
                Console.Write("\nPlayer 1 Enter Your Name: ");
                player1.name = Console.ReadLine();
                Console.Write("\nPlayer 2 Enter Your Name: ");
                player2.name = Console.ReadLine();
                if (player1.name != "" && player2.name != "")
                {
                    isEmpty = false;
                }

            } while (isEmpty);

            Console.Clear();
        }

        public bool player1Turn()
        {

            bool isValid = false;
            FireShotResponse response = new FireShotResponse();


            do
            {
                Console.Clear();
                player2Board.DisplayBoard();
                Console.Write("{0}, where would you like to fire?", player1.name);
                string input = Console.ReadLine().ToUpper();
                Coordinate player1Coord = ValidateCoord.getValidCoord(input);
                if (player1Coord == null)
                {
                    Console.WriteLine("That was not a valid coordinate.");
                }
                else
                {
                    response = player2Board.FireShot(player1Coord);
                    switch (response.ShotStatus)
                    {
                        case ShotStatus.Duplicate:
                            Console.Write("You've already shot there. Try again.");
                            break;
                        case ShotStatus.Hit:
                            Console.WriteLine("YOU HAVE HIT A TARGET!");
                            isValid = true;
                            break;
                        case ShotStatus.HitAndSunk:
                            Console.WriteLine("You sunk a ship!!");
                            isValid = true;
                            break;
                        case ShotStatus.Invalid:
                            Console.Write("Sorry, that is not a valid Coordinate. Try again.");
                            break;
                        case ShotStatus.Miss:
                            Console.WriteLine("Awwww no ship was hit this turn.");
                            isValid = true;
                            break;
                        case ShotStatus.Victory:
                            Console.Write("Great Job!! You Won!!");
                            isValid = true;
                            isVictory = true;
                            break;
                    }
                    Console.ReadLine();
                }
            } while (!isValid);
            return isVictory;
        }

        public bool player2Turn()
        {

            bool isValid = false;
            FireShotResponse response = new FireShotResponse();

            do
            {
                Console.Clear();
                player1Board.DisplayBoard();
                Console.Write("{0}, where would you like to fire?", player2.name);
                string input = Console.ReadLine().ToUpper();
                Coordinate player2Coord = ValidateCoord.getValidCoord(input);
                if (player2Coord == null)
                {
                    Console.WriteLine("That was not a valid coordinate.");
                }
                else
                {
                    response = player1Board.FireShot(player2Coord);
                    switch (response.ShotStatus)
                    {
                        case ShotStatus.Duplicate:
                            Console.Write("You've already shot there. Try again.");
                            break;
                        case ShotStatus.Hit:
                            Console.Write("YOU HAVE HIT A TARGET!");
                            isValid = true;
                            break;
                        case ShotStatus.HitAndSunk:
                            Console.Write("You sunk a ship!!");
                            isValid = true;
                            break;
                        case ShotStatus.Invalid:
                            Console.Write("Sorry, that is not a valid Coordinate. Try again.");
                            break;
                        case ShotStatus.Miss:
                            Console.Write("Awwww no ship was hit this turn.");
                            isValid = true;
                            break;
                        case ShotStatus.Victory:
                            Console.Write("Great Job!! You Won!!");
                            isValid = true;
                            isVictory = true;
                            break;
                    }
                    Console.ReadLine();
                }
            } while (!isValid);


            return isVictory;
        }
    }
}
