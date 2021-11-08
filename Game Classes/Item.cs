using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;

namespace rpg_game.Game_Classes
{
    public enum itemPlace
    {
        MainHand,
        OffHand,
        Armor,
        Ring,
        Amulet
    }
    public enum itemTypes
    {

    }
    class Item
    {
        public string name;
        public int id;
        public string description;
        public int damage;
        public int def;
        public int[] specialEffects; // currently not implimented at all, but could be used as a "if you have this item i will be weaker thingy..."

        public static Item getItemByName(string name)
        {
            foreach (Item i in items)
            {
                if (i.name == name)
                {
                    return i;
                }
            }
            return null;
        }
        public static Item getItemByID(int id)
        {
            foreach (Item i in items)
            {
                if (i.id == id)
                {
                    return i;
                }
            }
            return null;
        }

        public static Item[] items =
        {

    }
    }
}
