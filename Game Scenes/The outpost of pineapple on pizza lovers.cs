using System;
using System.Threading;
using System.Collections.Generic;
using rpg_game;
using rpg_game.Game_Classes;

namespace rpg_game.Game_Scenes
{
    class PizzaPineappleOutpost : Scene
    {
        public override bool Start (ref Player plr)
        {
            Program.print("Walking around pits of lava and endlessly deep holes.", delay: 200);
            Program.print("A man approaches you, he has a gleem in his eye of someone who just got what he strived for his whole life, or after life if you will.", delay: 200);
            Program.print("HUH!", ms: 30, name: "Stranger", delay: 600);
            Program.print("Who are you?", ms: 20, name: "Stranger", delay: 200);
            Program.print("What are you doing here?", ms: 20, name: "Stranger", delay: 200);
            Program.print("Are you with them?", ms: 20, name: "Stranger", delay: 200);
            Program.print("You are, arent you", withNLine: false, ms: 20, name: "Stranger", delay: 200);
            Program.print("...", ms: 200, delay: 200);
            Program.print("You're never gonna get me alive!", ms: 40, name: "Stranger", delay: 300);
            Program.print("The strange man comes charging at you with his sword in hand");
            Fight.StartFight(ref plr, Enemy.getById(1));
            Program.print("After you defeated the Pinapple on pizza hater, you continue to walk towards your destination", delay: 200);
            Program.print("...", ms: 300, delay: 200);
            Program.print("You arrive at a fort of sorts, it looks right out of the middle ages", delay: 200);



            return false;
        }
    }
}
