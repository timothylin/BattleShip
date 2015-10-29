using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class GameWorkflow
    {
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public Player OtherPlayer { get; private set; }
        public bool IsPlayer1 { get; private set; }

        public GameWorkflow()
        {
            Player1 = new Player();
            Player2 = new Player();
            CurrentPlayer = Player1;
            OtherPlayer = Player2;
            IsPlayer1 = true;
        }

        public void SplashScreen()
        {
            Console.WriteLine("Welcome to BattleShip!! \n\n\n\n\n\n\n\n");
            Console.WriteLine("Created by Chary Gurney and Timothy Lin \n\n\n\n\n\n\n\n");
            ScreenCleaner.ClearBoard();
        }

        public void PromptPlayerName()
        {
            Console.Write("Please enter your name: ");
            Player1.Name = Console.ReadLine();
            if (Player1.Name == "")
            {
                Player1.Name = "Player 1";
            }

            Console.WriteLine("Thank you, {0}, you will be player 1.", Player1.Name);
            Console.Write("Player 2, please enter your name: ");
            Player2.Name = Console.ReadLine();
            if (Player2.Name == "")
            {
                Player2.Name = "Player 2";
            }
            Console.WriteLine("Thank you, {0}, you will be player 2.", Player2.Name);
            ScreenCleaner.ClearBoard();
        }

        public void NextTurn()
        {
            IsPlayer1 = !IsPlayer1;
            CurrentPlayer = IsPlayer1 ? Player1 : Player2;
            OtherPlayer = IsPlayer1 ? Player2 : Player1;
        }

        public void PromptShipPlacement()
        {
            Console.WriteLine("{0}, please place your ships on the board.", CurrentPlayer.Name);

            if (IsPlayer1)
            {
                Console.WriteLine("{0}, please look away!!! No cheating!", Player2.Name);
            }
            else
            {
                Console.WriteLine("{0}, please look away!!! No cheating!", Player1.Name);
            }

            ScreenCleaner.ClearBoard();
            Console.WriteLine("Here is the game board: ");
            Console.WriteLine();
            BoardDrawer.DrawOwnShipBoard(this);
            ScreenCleaner.ClearBoard();
        }
    }
}
