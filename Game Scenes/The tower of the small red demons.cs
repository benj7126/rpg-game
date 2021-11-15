using System;
using System.Threading;
using System.Collections.Generic;
using rpg_game;
using rpg_game.Game_Classes;

namespace rpg_game.Game_Scenes
{
    class SmallRedDemonTower : Scene
    {
        public override bool Start (ref Player plr)
        {
            Program.print("There's a tower before you, ", delay: 200, withNLine: false); Program.print("the tower is about 4 times as tall as you, but only has like a 2 meter diameter. ", delay: 200, withNLine: false); Program.print("and the door is really small");
            Program.print("outside the tower there's a little sign that says");
            Program.print("'Welcome to the red demon tower", delay: 200);
            Program.print("MAXIMUM HEIGHT 3'0 ft'", delay: 200);
            Program.print("Looks like America isn't the only place that still doesn't use the metric system.", delay: 200, withNLine: false); Program.print("Or maybe just a lot of Americans go to hell hmm...", delay: 200, withNLine: false); Program.print("I'll let you interpret that one for yourself", delay: 200);
            Program.print("You bend down to knock on the small door and take a step back");
            Program.print("...", ms: 500);
            Program.print("The door slowly opens and a small pair of eyes look at you from the door frame", delay: 200);
            Program.print("Who are you and whaddya want,", delay:200, withNLine: false, name: "Little stranger"); Program.print("We're busy in here");
            ChoiceSelector answer1 = new ChoiceSelector();
            int choice = answer1.update(ref plr, new List<string>() { "Can I take a look inside?", "Come out and face me coward!", "Nevermind I'm gonna leave" }, "What do you say?");

            switch (choice)
            {
                case 0:
                    Program.print("Could I possibly have a look inside?", name: plr.name, delay: 100);
                    Program.print("...");
                    Program.print("");
                    return false;
                case 1:
                    Program.print("...", ms: 200, name: "Little red demon", delay: 100);
                    Fight.update();
                    break;
                case 2:
                    Program.print("Well, if you insist on dying, be my guest", name: "Little red demon", delay: 1000);
                    Fight.update();
                    break;
            }


            return false;
        }
    }
}
