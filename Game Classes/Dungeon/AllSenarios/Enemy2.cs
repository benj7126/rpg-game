using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_game.Game_Classes.Dungeon.AllSenarios
{
    class Enemy2 : senario
    {
        public override int onEnter(ref Player plr, int layer)
        {
            Program.print("You look upwards, theres a demon there, thin as a stick but tall as a building.");
            Fight.StartFight(ref plr, new Enemy("Stick man", "I need some fat, become my fooood?!", 50 + layer * 2, 20 + layer * 2, 0, "broken, like a twig", new drop[] { new drop(Item.getItemByID(10), 0.5f), new drop(Item.getItemByID(11), 0.3f), new drop(Item.getItemByID(38), 0.1f), new drop(Item.getItemByID(39), 0.1f)}));
            return 0;
        }

        public override int onLook(ref Player plr, int layer)
        {
            Program.print("There is a shadow of a tall figure, a very tall figure");
            return 0;
        }
    }
}
