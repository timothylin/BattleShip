using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;

namespace BattleShip.UI
{
    public static class GridConversion
    {
        public static Coordinate CoordinateConversion(char[] coordinateInput)
        {
            Coordinate coordinate;

            if (coordinateInput.Length == 3)
            {
                int yCoordinate =
                    int.Parse(string.Concat(coordinateInput[1].ToString(), coordinateInput[2].ToString()));
                coordinate = new Coordinate(coordinateInput[0] - 'A' + 1, yCoordinate);
            }
            else
            {
                coordinate = new Coordinate((coordinateInput[0] - 'A' + 1), int.Parse(coordinateInput[1].ToString()));
            }

            return coordinate;
        }
    }
}
