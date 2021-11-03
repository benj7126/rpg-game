using System;
using System.Collections.Generic;
using System.Text;
using rpg_game.Game_Classes;

namespace rpg_game.Game_Classes
{
    class Location
    {
        public string name;
        public Vector pos;

        public Location(string locationName, Vector locationPos)
        {
            name = locationName;
            pos = locationPos;
        }

        public static Location[] locations =
        {
            new Location("The town of beginnigs", new Vector(0, 0)),
            new Location("The town of continuation", new Vector(10, 0))
        };
    }
}
