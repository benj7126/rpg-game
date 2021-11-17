using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_game.Game_Classes.Dungeon.AllSenarios
{
    class Empty : senario
    {
        public override int onEnter(ref Player plr, int layer)
        {
            Program.print("You enter a room, its empty.");
            return 0;
        }

        public override int onLook(ref Player plr, int layer)
        {
            Program.print("You look into the room, there dosen't seem to be anything in ther, but, better check right?");
            return 0;
        }
    }
}
