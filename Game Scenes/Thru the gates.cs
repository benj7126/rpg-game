using System;
using System.Threading;
using System.Collections.Generic;
using rpg_game;
using rpg_game.Game_Classes;

namespace rpg_game.Game_Scenes
{
    class ThruTheGates : Scene
    {
        public override bool Start(ref Player plr)
        {
            Program.print("You walk through the gates of hell proud of yourself, so far you've come. Time to show those on earth");
            plr.win = true;
            return false;
        }
    }
}
