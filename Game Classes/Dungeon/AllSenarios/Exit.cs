using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_game.Game_Classes.Dungeon.AllSenarios
{
    class Exit : senario
    {
        public override int onEnter(ref Player plr, int layer)
        {
            Program.print("As you approach the green block, your mind goes blank");
            return 1;
        }

        public override int onLook(ref Player plr, int layer)
        {
            Program.print("You see a giant block that is green and a little translucent");
            return 0;
        }
    }
}
