using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class ShipCoordinates
    {

        public Coordinate[] Coordinates { get; private set; }

        public Coordinate[] ShipCoordinator(PlaceShipRequest request)
        {
            switch (request.ShipType)
            {
                case ShipType.Destroyer:
                    CheckDirection(request.Coordinate, request.Direction, 2);
                    break;

                case ShipType.Submarine:
                    CheckDirection(request.Coordinate, request.Direction, 3);
                    break;

                case ShipType.Cruiser:
                    CheckDirection(request.Coordinate, request.Direction, 3);
                    break;

                case ShipType.Battleship:
                    CheckDirection(request.Coordinate, request.Direction, 4);
                    break;

                case ShipType.Carrier:
                    CheckDirection(request.Coordinate, request.Direction, 5);
                    break;
            }
            return Coordinates;
        }


        private void CheckDirection(Coordinate coordinate, ShipDirection direction, int numberOfSlots)
        {
            Coordinates = new Coordinate[numberOfSlots];

            Coordinates[0] = coordinate;

            switch (direction)
            {
                case ShipDirection.Up:
                    for (int i = 1; i < numberOfSlots; i++)
                    {
                        Coordinates[i] = new Coordinate(coordinate.XCoordinate, coordinate.YCoordinate - i);
                    }
                    break;

                case ShipDirection.Down:
                    for (int i = 1; i < numberOfSlots; i++)
                    {
                        Coordinates[i] = new Coordinate(coordinate.XCoordinate, coordinate.YCoordinate + i);
                    }
                    break;

                case ShipDirection.Left:
                    for (int i = 1; i < numberOfSlots; i++)
                    {
                        Coordinates[i] = new Coordinate(coordinate.XCoordinate - i, coordinate.YCoordinate);
                    }
                    break;

                case ShipDirection.Right:
                    for (int i = 1; i < numberOfSlots; i++)
                    {
                        Coordinates[i] = new Coordinate(coordinate.XCoordinate + i, coordinate.YCoordinate);
                    }
                    break;
            }
        }
    }
}
