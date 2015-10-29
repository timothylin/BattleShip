using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public static class ScreenCleaner
    {
        public static void ClearBoard()
        {
            Console.WriteLine();
            Console.WriteLine("Please press enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
