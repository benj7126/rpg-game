using System;
using System.Threading;
using System.Collections.Generic;
using rpg_game;
using rpg_game.Game_Classes;

namespace rpg_game.Game_Scenes
{
    class SockandSandalchurch : Scene
    {
        public override bool Start(ref Player plr)
        {
            Program.print("You arrive at a traditionally christian looking cathedral.");
            Program.print("except it has a big picture of a sock inside of a sandal");
            Program.print("Outside cathedral there's big statue of a human wearing nothing but some socks and sandals, It says 'Grand Wizard'");
            Program.print("You realize that this place is doing some cult shit");
            Program.print("It would be great to kill them all and take their loot, but unfortunately you have no more time, since you have to write a synopsis.");
            return false;
        }
    }
}
