using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;

namespace rpg_game.Game_Classes
{
    class Item
    {
        public string name;
        public int id;
        public string description;
        public Player.itemPlace place;
        public int damage;
        public int defence;
        public int[] specialEffects; // currently not implimented at all, but could be used as a "if you have this item i will be weaker thingy..."

        public void equip(ref Player plr, int pos) // B - calls when player wants to equip an item, place is where this item needs to go to be equiped
        {
            Item savedItem = null;
            if (plr.equipped[place] != null)
            {
                savedItem = plr.equipped[place];
            }

            plr.equipped[place] = plr.inventory[pos];
            plr.inventory[pos] = savedItem;
        }
        public void remove(ref Player plr, int pos) // B - calls when player wants to equip an item, place is where this item needs to go to be equiped
        {
            plr.inventory[pos] = null;
        }
        public void unequip(ref Player plr) // B - finds the first free possition in you inventroy and moves item there, if there are no free space nothing happens
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

        public static Item getItemByName(string name) // B - look thru all items and return the first item with the given name
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
        public static Item getItemByID(int id) // B - look thru all items and return the first item with the given id
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

        // B - list of all items in game
        public static Item[] items =
        {
            new Item("Plep's sword", 1, "You found this sword laying on the ground, It's really bad quality and for some reason there's carved the word Plep into it", 1, 0, Player.itemPlace.MainHand),
            new Item("Demon's Trident", 2, "A normal sized trident used by a small sized demon, But now it's yours", 3, -1, Player.itemPlace.MainHand),
            new Item("Huge shield with 4 normal sized shields on top of the shield", 3, "The name says it all really.", 0, 20, Player.itemPlace.OffHand),
            new Item("Super Shotgun", 4, "For some reason Everyone here who sees you walk around with this turns around and runs away in fear", 5, 0, Player.itemPlace.OffHand),
            new Item("Male School uniform", 5,"Pair of pants and a nice shirt with a tie and a little label that says Evil High on it", 1,5, Player.itemPlace.Armor),
            new Item("Female School uniform", 6,"A nice shirt with a plaid skirt tucked in, the shirt has a little label that says Evil High on it", 2,4, Player.itemPlace.Armor),
        };
    }
}
