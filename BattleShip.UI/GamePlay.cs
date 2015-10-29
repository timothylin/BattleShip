using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using Microsoft.Win32.SafeHandles;

namespace BattleShip.UI
{
    public static class GamePlay
    {
        public static void PlayGame(GameWorkflow game)
        {
            string coordinateInput = "";
            char[] coordinateOutput;
            bool isValidInput;
            Coordinate coordinate;
            FireShotResponse response = new FireShotResponse();

            Console.WriteLine("Your ships are set, let's start the game!");

            do
            {
                Console.WriteLine("{0}, it is now your turn.", game.CurrentPlayer.Name);
                Console.WriteLine();
                do
                {
                    do
                    {
                        Console.WriteLine("This is Your Shot History...");
                        Console.WriteLine();
                        BoardDrawer.DrawShotHistoryBoard(game.OtherPlayer);
                        Console.WriteLine();
                        Console.WriteLine("Here are your ships that got hit.");
                        Console.WriteLine();
                        BoardDrawer.DrawShotHistoryBoard(game.CurrentPlayer);
                        Console.WriteLine();
                        Console.WriteLine("{0}, pick a coordinate to fire at: ", game.CurrentPlayer.Name);
                        coordinateInput = Console.ReadLine().ToUpper();

                        isValidInput = InputChecker.CheckInput(coordinateInput);

                        if (!isValidInput)
                        {
                            Console.WriteLine();
                            Console.WriteLine("{0}, that was not a valid shot coordinate.  Please try again!",
                                game.CurrentPlayer.Name);
                            ScreenCleaner.ClearBoard();
                        }
                        else
                        {
                            coordinateOutput = coordinateInput.ToCharArray();
                            coordinate = GridConversion.CoordinateConversion(coordinateOutput);
                            response = game.OtherPlayer.PlayerBoard.FireShot(coordinate);
                        }
                    } while (!isValidInput);

                    switch (response.ShotStatus)
                    {
                        case ShotStatus.Invalid:
                            Console.WriteLine();
                            Console.WriteLine("Not a valid coordinate.");
                            ScreenCleaner.ClearBoard();
                            break;
                        case ShotStatus.Duplicate:
                            Console.WriteLine();
                            Console.WriteLine("Duplicate coordinate.");
                            ScreenCleaner.ClearBoard();
                            break;
                        case ShotStatus.Miss:
                            Console.WriteLine();
                            Console.WriteLine("That was a miss!");
                            ScreenCleaner.ClearBoard();
                            break;
                        case ShotStatus.Hit:
                            Console.WriteLine();
                            Console.WriteLine("You hit the {0} ship!", response.ShipImpacted);
                            ScreenCleaner.ClearBoard();
                            break;
                        case ShotStatus.HitAndSunk:
                            Console.WriteLine();
                            Console.WriteLine("You sank the {0} ship!", response.ShipImpacted);
                            ScreenCleaner.ClearBoard();
                            break;
                        case ShotStatus.Victory:
                            Console.WriteLine();
                            Console.WriteLine("Congratulations, {0}, you won!", game.CurrentPlayer.Name);
                            ScreenCleaner.ClearBoard();
                            break;
                    }

                } while (response.ShotStatus == ShotStatus.Invalid || response.ShotStatus == ShotStatus.Duplicate);

                game.NextTurn();

            } while (response.ShotStatus != ShotStatus.Victory);
        }

        public static bool NewGame()
        {
            bool isValidInput = false;
            bool keepPlaying = false;

            do
            {
                Console.WriteLine("Do you want to play again?  Type \"Yes\" to play again or \"Quit\" to exit.");
                string input = Console.ReadLine().ToUpper();

                switch (input)
                {
                    case "YES":
                        Console.WriteLine("OK!  Let's go!!");
                        isValidInput = true;
                        keepPlaying = true;
                        break;
                    case "QUIT":
                        Console.WriteLine("Thank you for playing!");
                        isValidInput = true;
                        keepPlaying = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input.  Please try again!");
                        isValidInput = false;
                        keepPlaying = false;
                        break;
                }
            } while (!isValidInput);

            return keepPlaying;
        }
    }
}
