using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;

namespace rpg_game.Game_Classes
{
    class Player
    {
        public enum itemPlace // B - all slots for the player
        {
            MainHand,
            OffHand,
            Armor,
            Ring,
            Amulet
        }
        // B - some statn stuff
        public int health = 16;
        public int maxHealth = 16;

        public string name = "";

        // B - the keys to interact so that they can be changed
        public static ConsoleKey up = ConsoleKey.UpArrow;
        public static ConsoleKey down = ConsoleKey.DownArrow;
        public static ConsoleKey left = ConsoleKey.LeftArrow;
        public static ConsoleKey right = ConsoleKey.RightArrow;
        public static ConsoleKey select = ConsoleKey.Enter;
        public static ConsoleKey del = ConsoleKey.Backspace;

        public static float textSpeedMulti = 1;

        // B - where the player is and where they can go
        public Vector pos = new Vector(0, 0);
        public List<Location> possibleLocations = new List<Location>();

        // B - the inventory of the player and the item slots
        public Item[] inventory = new Item[12];
        public Dictionary<itemPlace, Item> equipped = new Dictionary<itemPlace, Item>();

        public Player()
        {
            // B - make item slot item slots...
            equipped.Add(itemPlace.MainHand, Item.getItemByID(1));
            equipped.Add(itemPlace.OffHand, null);
            equipped.Add(itemPlace.Armor, null);
            equipped.Add(itemPlace.Ring, null);
            equipped.Add(itemPlace.Amulet, null);

            // B - add default locations
            foreach (Location l in Location.locations)
            {
                possibleLocations.Add(l);
            }
        }
    }
}
