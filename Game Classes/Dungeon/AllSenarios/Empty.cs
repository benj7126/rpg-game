﻿using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_game.Game_Classes.Dungeon.AllSenarios
{
    class Empty : senario
    {
        public override void onEnter(ref Player plr)
        {
            Program.print("You enter a room, its empty.");
        }

        public override void onLook(ref Player plr)
        {
            Program.print("You look into the room, there dosen't seem to be anything in ther, but, better check right?");
        }
    }
}
