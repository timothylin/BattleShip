using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{

    public static class ShipSetter
    {
        public static void SetShip(GameWorkflow game)
        {

            foreach (Ship ship in game.CurrentPlayer.Ships)
            {
                PlaceShipRequest placeShipRequest = new PlaceShipRequest();
                placeShipRequest.ShipType = ship.ShipType;
                string coordinateInput = "";
                char[] coordinateOutput = new char[2];
                bool isValidInput = false;
                ShipPlacement shipPlacement;

                do
                {
                    do
                    {
                        Console.WriteLine("{0}, place your {1} ship on the board which has {2} slots.", game.CurrentPlayer.Name,
                            ship.ShipType, ship.BoardPositions.Length);
                        Console.WriteLine();
                        Console.WriteLine("Here is the game board for your reference.");
                        Console.WriteLine();
                        BoardDrawer.DrawOwnShipBoard(game);
                        Console.WriteLine();
                        Console.WriteLine("Choose a position on the board, for example \"E5\": ");
                        coordinateInput = Console.ReadLine().ToUpper();
                        Console.WriteLine();


                        if (coordinateInput.Length == 2 && (coordinateInput[1] >= '1' && coordinateInput[1] <= '9') &&
                            (coordinateInput[0] >= 'A' && coordinateInput[0] <= 'J'))
                        {
                            isValidInput = true;
                            coordinateOutput = coordinateInput.ToCharArray();
                        }
                        else if (coordinateInput.Length == 3 && (coordinateInput[1] >= '1' && coordinateInput[2] <= '0') &&
                                 (coordinateInput[0] >= 'A' && coordinateInput[0] <= 'J'))
                        {
                            isValidInput = true;
                            coordinateOutput = coordinateInput.ToCharArray();
                        }
                        else
                        {
                            isValidInput = false;
                            Console.WriteLine("Invalid input {0}, please try again!", game.CurrentPlayer.Name);
                            ScreenCleaner.ClearBoard();
                        }
                    } while (!isValidInput);

                    Coordinate coordinateForShip;

                    if (coordinateOutput.Length == 3)
                    {
                        int yCoordinate =
                            int.Parse(string.Concat(coordinateOutput[1].ToString(), coordinateOutput[2].ToString()));
                        coordinateForShip = new Coordinate(coordinateOutput[0] - 'A' + 1, yCoordinate);
                    }
                    else
                    {
                        coordinateForShip = new Coordinate((coordinateOutput[0] - 'A' + 1), int.Parse(coordinateOutput[1].ToString()));
                    }

                    placeShipRequest.Coordinate = coordinateForShip;

                    isValidInput = false;
                    string directionInput = "";
                    bool needBoard = false;

                    do
                    {
                        if (needBoard)
                        {
                            Console.WriteLine("Here is the game board for your reference.");
                            Console.WriteLine();
                            BoardDrawer.DrawOwnShipBoard(game);
                            Console.WriteLine();
                            Console.WriteLine("Your coordinate input was: {0}", coordinateInput);
                            Console.WriteLine();
                        }
                        Console.WriteLine("Please choose the direction to place the ship: \"U\" up, \"D\" down, \n \"L\" left, or \"R \" right.");
                        directionInput = Console.ReadLine().ToUpper();

                        if ((directionInput.Length == 1) && directionInput == "U"
                            || directionInput == "D" || directionInput == "L" || directionInput == "R")
                        {
                            isValidInput = true;
                            needBoard = false;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Input not valid!");
                            ScreenCleaner.ClearBoard();
                            isValidInput = false;
                            needBoard = true;
                        }


                    } while (!isValidInput);

                    switch (directionInput)
                    {
                        case "U":
                            placeShipRequest.Direction = ShipDirection.Up;
                            break;
                        case "D":
                            placeShipRequest.Direction = ShipDirection.Down;
                            break;
                        case "L":
                            placeShipRequest.Direction = ShipDirection.Left;
                            break;
                        case "R":
                            placeShipRequest.Direction = ShipDirection.Right;
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("You need to enter a direction: either \"U\" up, \"D\" down,\n \"L\" left, or \"R\" right");
                            ScreenCleaner.ClearBoard();
                            break;
                    }

                    shipPlacement = game.CurrentPlayer.PlayerBoard.PlaceShip(placeShipRequest);

                    if (shipPlacement == ShipPlacement.NotEnoughSpace)
                    {
                        Console.WriteLine();
                        Console.WriteLine("There is not enough space on the board.  Please choose another direction.");
                        ScreenCleaner.ClearBoard();
                    }
                    else if (shipPlacement == ShipPlacement.Overlap)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You already have a ship placed there.  Please choose another direction");
                        ScreenCleaner.ClearBoard();
                    }
                    else
                    {
                        Console.WriteLine();

                        Console.WriteLine("{0} placed.", placeShipRequest.ShipType);

                        ShipCoordinates shipCoordinates = new ShipCoordinates();

                        Coordinate[] coordinates = shipCoordinates.ShipCoordinator(placeShipRequest);

                        for (int i = 0; i < coordinates.Length; i++)
                        {
                            game.CurrentPlayer.ShipLocations.Add(coordinates[i], placeShipRequest.ShipType);
                        }
                        ScreenCleaner.ClearBoard();
                    }
                }
                while (shipPlacement != ShipPlacement.Ok);
            }

            Console.WriteLine("This is your completed ship board, {0}.\n", game.CurrentPlayer.Name);
            BoardDrawer.DrawOwnShipBoard(game);
            ScreenCleaner.ClearBoard();

        }
    }
}
