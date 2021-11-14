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
        public int[] specialEffects; // currently not implemented at all, but could be used as a "if you have this item i will be weaker thingy..."
        // specialEffects:
        /*
        1: Healing



        */

        public void equip(ref Player plr, int pos) // B - calls when player wants to equip an item, place is where this item needs to go to be equiped
        {
            if (place == Player.itemPlace.unEquippable)
                return;

            if (place == Player.itemPlace.Consumable)
            {
                foreach(int sfx in specialEffects)
                {
                    switch (sfx)
                    {
                        case 1:
                            plr.health = Math.Min(plr.health + damage, plr.maxHealth);
                            break;
                        case 2:
                            plr.maxHealth += damage;
                            plr.health = Math.Min(plr.health + damage, plr.maxHealth);
                            break;
                    }
                }
                plr.inventory[pos] = null;
                return;
            }

            Item savedItem = null;
            if (plr.equipped[place] != null)
            {
                savedItem = plr.equipped[place];
            }

            plr.equipped[place] = plr.inventory[pos];
            plr.inventory[pos] = savedItem;
        }
        public void remove(ref Player plr, int pos) // B - calls when player wants to equip an item, place is where this item needs to go to be equipped
        {
            plr.inventory[pos] = null;
        }
        public void unequip(ref Player plr) // B - finds the first free position in your inventory and moves item there, if there are no free spaces nothing happens
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

        public static Item getItemByName(string name) // B - look through all items and return the first item with the given name
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
        public static Item getItemByID(int id) // B - look through all items and return the first item with the given id
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
            new Item("Super Shotgun", 4, "For some reason everyone here who sees you walk around with this turns around and runs away in fear", 5, 0, Player.itemPlace.OffHand),
            new Item("Male School uniform", 5,"Pair o" +
                "f pants and a nice shirt with a tie and a little label that says Evil High on it", 1,5, Player.itemPlace.Armor),
            new Item("Female School uniform", 6,"A nice shirt tucked into a plaid skirt, the shirt has a little label that says Evil High on it", 2,4, Player.itemPlace.Armor),
            new Item("Penguin sword", 7,"If this weapon doesn't defeat your enemies. It can only be attributed to human error.", 8,2, Player.itemPlace.MainHand),
            new Item("Devilish ring of defense", 8, "Given to you by an devilishly cute schoolgirl. It's magic protect you from attacks",0,7, Player.itemPlace.Ring),
            new Item("Minor potion of healing", 9, "Drinking this heals you 4 hp",4,0, Player.itemPlace.Consumable, sEffx: new int[] {1}),
            new Item("Potion of healing", 10, "Drinking this heals you 16 hp",16,0, Player.itemPlace.Consumable, sEffx: new int[] {1}),
            new Item("Strong potion of healing", 11, "Drinking this heals you 32 hp",32,0, Player.itemPlace.Consumable, sEffx: new int[] {1}),
            new Item("Hawai", 12, "It's a pizza with pinapple on it, how it landed in hell, nobody knows. But eating it will fill you with new life",8,0, Player.itemPlace.Consumable, sEffx: new int[] {1, 2}),
            
            //pizza set
            new Item("Pizza shield", 13, "Looks like a pizza, except it's overcooked and has a handle on the back",0,3, Player.itemPlace.OffHand, sEffx: new int[] {}),
            new Item("Ball of dough", 14, "It's a ball of dough. you think to yourself 'could I make armor of this?' but then you realize it was a stupid idea, or was it?",0,3, Player.itemPlace.Armor, sEffx: new int[] {}),
            new Item("Solid cheese sword", 15, "A sword made of cheese",2,0, Player.itemPlace.MainHand, sEffx: new int[] {}),
            new Item("Bag of unlimited melted cheese", 16, "You grab a little and throw it at them, hit the eyes THE EYES!",2,0, Player.itemPlace.OffHand, sEffx: new int[] {}),
            new Item("Ring of cheese", 17, "It's gross and you dont want to wear it.",-1,1, Player.itemPlace.Ring, sEffx: new int[] {}),
            new Item("Pizza with a hole", 18, "A pizza with a hole in it, you can wear it around your neck and look like some ufo or something",1,2, Player.itemPlace.Amulet, sEffx: new int[] {}),
            
            //pinapple pizza set
            new Item("Pizza shield with pineapples on", 19, "Looks like a pizza, except it's baked WAY too much and has a handle on the back, it's also covered in pineapple pieces, kinda makes it shine a little.",0,5, Player.itemPlace.OffHand, sEffx: new int[] {}),
            new Item("Ball of dough with pineapples in", 20, "You've probably already seen one of these before, now there's pieces of pineapple in it... DONT",0,4, Player.itemPlace.Armor, sEffx: new int[] {}),
            new Item("Pineapple bat", 21, "Just a pineapple",4,2, Player.itemPlace.MainHand, sEffx: new int[] {}),
            new Item("Bag of unlimited pineapple shaped caltrops", 22, "A great combination of taste and blood, take it from one that has tried it.",3,0, Player.itemPlace.OffHand, sEffx: new int[] {}),
            new Item("Pineapple ring ", 23, "Just a cylinder with a hole in it, fits your finger perfectly, sliiiides right on,",2,-4, Player.itemPlace.Ring, sEffx: new int[] {}),
            new Item("Pineapple amulet", 24, "A lot of rings made of pinapple. Hooked together to make a choker or something.",4,-12, Player.itemPlace.Amulet, sEffx: new int[] {}),

            new Item("Shabby T-Shirt", 25, "You bought this T-shirt back on earth from a thrift shop, one man's trash is another man's treasure",0,1, Player.itemPlace.Armor),

            new Item("PPT", 26, "A token you got from a fight in the arena, where could you redeem this again..?",4,-12, Player.itemPlace.unEquippable, sEffx: new int[] {}),

        };
    }
}
