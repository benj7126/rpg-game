using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;

namespace rpg_game.Game_Classes
{
    public enum itemTypes
    {

    }
    class Item
    {
        public string name;
        public int id;
        public string description;
        public Player.itemPlace place;
        public int damage;
        public int defence;
        public int[] specialEffects; // currently not implimented at all, but could be used as a "if you have this item i will be weaker thingy..."

        public void equip(ref Player plr, int pos)
        {
            Item savedItem = null;
            if (plr.equipped[place] != null)
            {
                savedItem = plr.equipped[place];
            }

            plr.equipped[place] = plr.inventory[pos];
            plr.inventory[pos] = savedItem;
        }
        public void unequip(ref Player plr)
        {
            for (int i = 0; i < 12; i++)
            {
                if (plr.inventory[i] == null)
                {
                    plr.inventory[i] = plr.equipped[place];
                    plr.equipped[place] = null;
                    return;
                }
            }
        }

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

        public Item(string Name, int ID, string desc, int dam, int def, Player.itemPlace Place, int[] sEffx = null)
        {
            name = Name;
            id = ID;
            description = desc;
            damage = dam;
            defence = def;
            place = Place;
            specialEffects = sEffx;
        }

        public static Item[] items =
        {
            new Item("Plep's sword", 1, "You found this sword laying on the ground, it looks like it has a bad quality and for some reason there carved the word Plep into it", 1, 0, Player.itemPlace.MainHand),
        };
    }
}
