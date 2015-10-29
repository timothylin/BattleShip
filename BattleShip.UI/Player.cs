using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class Player
    {
        public string Name { get; set; }
        public Ship[] Ships { get; set; }
        public Board PlayerBoard { get; set; } = new Board();
        public Dictionary<Coordinate, ShipType> ShipLocations;

        public Player()
        {
            Name = "";
            Ships = new Ship[5];
            Ships[0] = ShipCreator.CreateShip(ShipType.Destroyer);
            Ships[1] = ShipCreator.CreateShip(ShipType.Cruiser);
            Ships[2] = ShipCreator.CreateShip(ShipType.Submarine);
            Ships[3] = ShipCreator.CreateShip(ShipType.Battleship);
            Ships[4] = ShipCreator.CreateShip(ShipType.Carrier);
            ShipLocations = new Dictionary<Coordinate, ShipType>();
        }
    }
}

