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
            Program.print($"{plr.name} test :D");
            plr.pickupItem(Item.getItemByID(2));
            plr.pickupItem(Item.getItemByID(3));
            return false;
        }
    }
}
