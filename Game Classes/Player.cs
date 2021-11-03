using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;

namespace rpg_game.Game_Classes
{
    class Player
    {
        public int health = 16;

        public Item[] inventory = new Item[12];
        public Dictionary<itemPlace, Item> equipped = new Dictionary<itemPlace, Item>();

        public Player()
        {
            equipped.Add(itemPlace.MainHand, null);
            equipped.Add(itemPlace.OffHand, null);
            equipped.Add(itemPlace.Armor, null);
            equipped.Add(itemPlace.Ring, null);
            equipped.Add(itemPlace.Amulet, null);
        }
    }
}
