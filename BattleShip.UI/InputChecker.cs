using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public static class InputChecker
    {

        public static bool CheckInput(string coordinate)
        {
            if (coordinate.Length == 2 && (coordinate[1] >= '1' && coordinate[1] <= '9') &&
                (coordinate[0] >= 'A' && coordinate[0] <= 'J'))
            {
                return true;
            }
            else if (coordinate.Length == 3 && (coordinate[1] >= '1' && coordinate[2] <= '0') &&
                     (coordinate[0] >= 'A' && coordinate[0] <= 'J'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
