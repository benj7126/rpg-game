using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_game.Game_Classes.Dungeon.AllSenarios
{
    class AlreadyBeenThere : senario
    {
        public override void onEnter(ref Player plr)
        {
            Program.print("Nothing new...");
        }

        public override void onLook(ref Player plr)
        {
            Program.print("This room seems familliar, you've been here beffore, you doubt anythings changed.r");
        }
    }
}
