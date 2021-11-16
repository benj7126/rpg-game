using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_game.Game_Classes.Dungeon.AllSenarios
{
    class Enemy1 : senario
    {
        public override void onEnter(ref Player plr)
        {
            Program.print("You enter the room, and a little red guy that has the same size as your arm jumps at you.");
            Fight.StartFight(ref plr, Enemy.getById(0));
        }

        public override void onLook(ref Player plr)
        {
            Program.print("You see a shadow of a figure, a very small figure, but a figure non the less.");
        }
    }
}
