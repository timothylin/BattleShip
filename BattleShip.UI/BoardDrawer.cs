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
    public static class BoardDrawer
    {
        public static void DrawShotHistoryBoard(Player player)
        {

            char[] columnGrid = "\0ABCDEFGHIJ".ToCharArray();

            Console.Write("   ");
            for (int i = 1; i < 11; i++)
            {
                Console.Write(" {0} ", columnGrid[i]);
            }
            Console.WriteLine();

            for (int i = 1; i < 11; i++)
            {
                if (i == 10)
                {
                    Console.Write("{0} ", i);
                }
                else
                {
                    Console.Write("{0}  ", i);
                }

                for (int j = 1; j < 11; j++)
                {
                    Coordinate checkCoordinate = new Coordinate(j, i);
                    if (!player.PlayerBoard.ShotHistory.ContainsKey(checkCoordinate) ||
                        player.PlayerBoard.ShotHistory[checkCoordinate] == ShotHistory.Unknown)
                    {
                        Console.Write(" - ");
                    }
                    else if (player.PlayerBoard.ShotHistory[checkCoordinate] == ShotHistory.Hit)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" {0} ", "H");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (player.PlayerBoard.ShotHistory[checkCoordinate] == ShotHistory.Miss)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" {0} ", "M");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                Console.WriteLine();
            }
        }

        public static void DrawOwnShipBoard(GameWorkflow game)
        {
            char[] columnGrid = "\0ABCDEFGHIJ".ToCharArray();

            Console.Write("   ");
            for (int i = 1; i < 11; i++)
            {
                Console.Write(" {0} ", columnGrid[i]);
            }
            Console.WriteLine();

            for (int i = 1; i < 11; i++)
            {
                if (i == 10)
                {
                    Console.Write("{0} ", i);
                }
                else
                {
                    Console.Write("{0}  ", i);
                }

                for (int j = 1; j < 11; j++)
                {

                    Coordinate checkCoordinate = new Coordinate(j, i);
                    if (!game.CurrentPlayer.ShipLocations.ContainsKey(checkCoordinate))

                    {
                        Console.Write(" - ");
                    }
                    else if (game.CurrentPlayer.ShipLocations[checkCoordinate] == ShipType.Destroyer)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" {0} ", "D");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (game.CurrentPlayer.ShipLocations[checkCoordinate] == ShipType.Battleship)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(" {0} ", "B");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (game.CurrentPlayer.ShipLocations[checkCoordinate] == ShipType.Carrier)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" {0} ", "C");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (game.CurrentPlayer.ShipLocations[checkCoordinate] == ShipType.Cruiser)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" {0} ", "R");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (game.CurrentPlayer.ShipLocations[checkCoordinate] == ShipType.Submarine)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" {0} ", "S");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                }
                Console.WriteLine();
            }
        }
    }
}

