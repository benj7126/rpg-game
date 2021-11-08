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
        public Game_Scenes.Scene onEnter = null;

        public Location(string locationName, Vector locationPos, Game_Scenes.Scene scene)
        {
            name = locationName;
            pos = locationPos;
            onEnter = scene;
        }

        public static Location getLocationByName(string name)
        {
            foreach (Location l in locations)
            {
                if (l.name == name)
                {
                    return l;
                }
            }
            return null;
        }

        public static Location[] locations =
        {
            new Location("The town of beginnings", new Vector(0, 0), new Game_Scenes.Beginning()),
            new Location("The outpost of pineapple on pizza lovers ", new Vector(60, 20), new Game_Scenes.PizzaPineappleOutpost()),
            new Location("The church of Socks and Sandals ", new Vector(-40, 30), new Game_Scenes.SockandSandalchurch()),
            new Location("The tower of the small red demons ", new Vector(-70, 30), new Game_Scenes.SmallRedDemonTower()),
            new Location("The Demon high school", new Vector(30, 50), new Game_Scenes.DemonHighSchool()),
            new Location("The gates to hell", new Vector(0,100), new Game_Scenes.HellGates()),
        };
    }
}
