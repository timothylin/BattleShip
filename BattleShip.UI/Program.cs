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

            bool keepPlaying;

            do
            {

                GameWorkflow game = new GameWorkflow();

                game.SplashScreen();
                game.PromptPlayerName();
                game.PromptShipPlacement();
                ShipSetter.SetShip(game);
                game.NextTurn();
                game.PromptShipPlacement();
                ShipSetter.SetShip(game);
                game.NextTurn();
                GamePlay.PlayGame(game);

                keepPlaying = GamePlay.NewGame();

                Console.ReadLine();
                Console.Clear();

            } while (keepPlaying);
        }
    }
}
