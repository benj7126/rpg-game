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
    }
}
