using System;
using System.Threading;
using System.Collections.Generic;
using rpg_game;
using rpg_game.Game_Classes;

namespace rpg_game.Game_Scenes
{
    class Fountain : Scene
    {
        public override bool Start(ref Player plr)
        {
            Program.print("You look into the fountain");
            if (plr.health == plr.maxHealth)
            {
                Program.print(@"You see a shape, you can't really make out what it is:
          /´¯/)
         /  //
        /  //
  /´¯/¯/  /´¯\
 /  / /  / /  \
(  ( (  ( / )  )
 \        \/  /
  \          /
   \________/", raw: true);
            }
            else
            {
                Program.print("You see your reflection, but somehow your reflection looks less hurt");
                ChoiceSelector cs = new ChoiceSelector();
                if (cs.update(ref plr, new List<string>() { "Get away from that instakil bs", "Touch it!" }) == 1)
                {
                    while (plr.health != plr.maxHealth)
                    {
                        Console.WriteLine("Player Health: " + plr.health);
                        plr.health++;
                        Program.sleep(100);
                    }
                }
            }

            return false;
        }
    }
}
