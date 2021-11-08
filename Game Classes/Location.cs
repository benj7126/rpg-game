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
            new Location("The town of beginnings", new Vector(0, 0)),
            new Location("The town of continuation", new Vector(60, 20)),
            new Location("The church of Socks and Sandals", new Vector (-30, 20)),
            new Location("The town of the little red demons", new Vector (40,60)),
            new Location("The fellow pineapple pizza eaters outpost", new Vector(-10,10)),
            new Location("The gate that leads out of hell", new Vector(0,100)),
        };
    }
}
