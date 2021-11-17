using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_game.Game_Classes.Dungeon.AllSenarios
{
    class Enemy1 : senario
    {
        public override int onEnter(ref Player plr, int layer)
        {
            Program.print("You enter the room, and a little red guy that has the same size as your arm jumps at you.");
            Fight.StartFight(ref plr, new Enemy("Small red demon", "How are you so big?", 40 + layer * 2, 24+layer*2, 0, "TOOoo big", new drop[] { new drop(Item.getItemByID(10), 0.5f), new drop(Item.getItemByID(11), 0.3f), new drop(Item.getItemByID(35), 0.1f), new drop(Item.getItemByID(36), 0.1f) , new drop(Item.getItemByID(37), 0.1f) }));
            return 0;
        }

        public override int onLook(ref Player plr, int layer)
        {
            Program.print("You see a shadow of a figure, a very small figure, but a figure non the less.");
            return 0;
        }
    }
}
