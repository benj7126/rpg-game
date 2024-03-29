﻿using System;
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

        public void enterLocation(ref Player plr, ref Location self) // call when you enter a location after traveling
        {
            bool del = false;
            if (onEnter != null)
                del = onEnter.Start(ref plr); // return true if you want to delete location availability
            if (del)
            {
                plr.possibleLocations.Remove(self);
            }
        }

        public static Location getLocationByName(string name) // used to get a location from the list based on the name
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

        public static Location[] locations = // all locations
        {
            new Location("Random fountain", new Vector(0, 0), new Game_Scenes.Fountain()),
            new Location("The outpost of pineapple on pizza lovers ", new Vector(-60, 20), new Game_Scenes.PizzaPineappleOutpost()),
            new Location("The church of Socks and Sandals ", new Vector(-40, 30), new Game_Scenes.SockandSandalchurch()),
            new Location("The tower of the small red demons ", new Vector(-70, 30), new Game_Scenes.SmallRedDemonTower()),
            new Location("The Demon high school", new Vector(30, 50), new Game_Scenes.DemonHighSchool()),
            new Location("The gates to hell", new Vector(0,100), new Game_Scenes.HellGates()),
            new Location("Go thru the gates", new Vector(0,100), new Game_Scenes.ThruTheGates()),
            new Location("Multi dimensional maze - layer 1", new Vector(0, -60), new Game_Scenes.maze1()),
            new Location("Multi dimensional maze - layer 2", new Vector(0, -60), new Game_Scenes.maze2()),
            new Location("Multi dimensional maze - layer 3", new Vector(0, -60), new Game_Scenes.maze3()),
        };
    }
}
