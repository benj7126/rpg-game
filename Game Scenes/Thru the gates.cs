﻿using System;
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
            Program.print("You win, yuhuu...");
            plr.win = true;
            return false;
        }
    }
}
