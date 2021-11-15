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
            Amulet,
            unEquippable,
            Consumable
        }
        // B - some stat stuff
        public int health = 16;
        public int maxHealth = 16;

        public string name = "<playername>";

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

        public bool win = false;

        // B - the name says it all
        public string[] dontAdd =
        {
            "Go thru the gates",
            "Multi dimensional maze - layer 2",
            "Multi dimensional maze - layer 3",
        };

        // B - the inventory of the player and the item slots
        public Item[] inventory = new Item[12];
        public Dictionary<itemPlace, Item> equipped = new Dictionary<itemPlace, Item>();

        public void dead()
        {
            Console.Clear();

            Program.print("HA YOU DEAD!!!!");
            Program.print("START OF GAME GO", delay: 200);
            Program.print("BRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR", ms: 5);

            Program.gameStart();
        }

        public bool pickupItem(Item item)
        {
            for (int i = 0; i < 12; i++)
            {
                if (inventory[i] == null)
                {
                    Program.print($"[{item.name}] was added to your inventory");
                    inventory[i] = item;
                    return true;
                }
            }
            Program.print($"But you had a full inventory so you left {item.name} behind");
            return false;
        }

        public int getAttack()
        {
            int attack = 0;

            foreach(KeyValuePair<itemPlace, Item> vals in equipped)
            {
                if (vals.Value != null)
                {
                    attack = Math.Max(attack + vals.Value.damage, 0);
                }
            }

            return attack;
        }

        public int getDefence()
        {
            int defence = 0;

            foreach (KeyValuePair<itemPlace, Item> vals in equipped)
            {
                if (vals.Value != null)
                {
                    defence = Math.Max(defence + vals.Value.defence, 0);
                }
            }

            return defence;
        }

        public Player()
        {
            // B - make item slot item slots...
            equipped.Add(itemPlace.MainHand, Item.getItemByID(1));
            equipped.Add(itemPlace.OffHand, null);
            equipped.Add(itemPlace.Armor, Item.getItemByID(25));
            equipped.Add(itemPlace.Ring, null);
            equipped.Add(itemPlace.Amulet, null);

            // B - add default locations
            foreach (Location l in Location.locations)
            {
                bool add = true;
                foreach(string s in dontAdd)
                {
                    if (l.name == s)
                        add = false;
                }
                if (add)
                    possibleLocations.Add(l);
            }
        }
    }
}
