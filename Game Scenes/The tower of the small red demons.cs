using System;
using System.Threading;
using System.Collections.Generic;
using rpg_game;
using rpg_game.Game_Classes;

namespace rpg_game.Game_Scenes
{
    class SmallRedDemonTower : Scene
    {
        public override void Start(ref Player plr)
        {
            Program.print("There's a tower before you.", delay: 200, withNLine: false); Program.print("the tower is about 4 times as tall as you, but only has like a 2 meter diameter.", delay: 200, withNLine: false); Program.print("and the door is really small");
            Program.print("outside the tower there's a little sign that says");
            Program.print("'Welcome to the red demon tower", delay: 200);
            Program.print("MAXIMUM HEIGHT 3'0 ft'", delay: 200);
            Program.print("Looks like America isn't the only place that still doesn't use the metric system.", delay: 200, withNLine: false); Program.print("Or maybe just a lot of Americans go to hell hmm...", delay: 200, withNLine: false); Program.print("I'll let you interpret that one for yourself");
        }
    }
}
