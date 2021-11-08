using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;

namespace rpg_game.Game_Classes
{
    class Player
    {
        public enum itemPlace
        {
            MainHand,
            OffHand,
            Armor,
            Ring,
            Amulet
        }
        public int health = 16;
        public int maxHealth = 16;

        public string name = "";

        public ConsoleKey up = ConsoleKey.UpArrow;
        public ConsoleKey down = ConsoleKey.DownArrow;
        public ConsoleKey select = ConsoleKey.Enter;

        public Location playerLocation = Location.getLocationByName("Midt ude i ingenting");

        public Vector pos = new Vector(100, 0);
        public List<Location> possibleLocations = new List<Location>();

        public Item[] inventory = new Item[12];
        public Dictionary<itemPlace, Item> equipped = new Dictionary<itemPlace, Item>();

        public Player()
        {
            equipped.Add(itemPlace.MainHand, null);
            equipped.Add(itemPlace.OffHand, null);
            equipped.Add(itemPlace.Armor, null);
            equipped.Add(itemPlace.Ring, null);
            equipped.Add(itemPlace.Amulet, null);

            foreach (Location l in Location.locations)
            {
                possibleLocations.Add(l);
            }

            /*
            possibleLocations.Add(Location.getLocationByName("The town of beginnings"));
            possibleLocations.Add(Location.getLocationByName("Midt ude i ingenting"));
            */
        }
    }
}
