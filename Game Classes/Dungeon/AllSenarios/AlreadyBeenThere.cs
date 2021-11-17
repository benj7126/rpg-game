using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_game.Game_Classes.Dungeon.AllSenarios
{
    class AlreadyBeenThere : senario
    {
        public override int onEnter(ref Player plr, int layer)
        {
            Program.print("Nothing new...");
            return 0;
        }

        public override int onLook(ref Player plr, int layer)
        {
            Program.print("This room seems familliar, you've been here beffore, you doubt anythings changed.");
            return 0;
        }
    }
}
