using System;
using System.Threading;
using System.Collections.Generic;
using rpg_game;
using rpg_game.Game_Classes;

namespace rpg_game.Game_Scenes
{
    class DemonHighSchool : Scene
    {
        public override bool Start(ref Player plr)
        {        
            Program.print($"{plr.name} You've died");
            Program.print("", delay: 1000);
            Program.print("It's up to you", delay: 100, withNLine: false);


            return false;
        }
    }
}
