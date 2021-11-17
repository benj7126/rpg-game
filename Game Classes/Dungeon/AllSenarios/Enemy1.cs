﻿using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_game.Game_Classes.Dungeon.AllSenarios
{
    class Enemy1 : senario
    {
        public override int onEnter(ref Player plr, int layer)
        {
            Program.print("You enter the room, and a little red guy that has the same size as your arm jumps at you.");
            Fight.StartFight(ref plr, new Enemy("Small red demon", "How are you so big?", 40, 30, 0, "TOOoo big", new drop[] { }));
            return 0;
        }

        public override int onLook(ref Player plr, int layer)
        {
            Program.print("You see a shadow of a figure, a very small figure, but a figure non the less.");
            return 0;
        }
    }
}
