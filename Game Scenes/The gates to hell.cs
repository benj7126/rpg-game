using System;
using System.Threading;
using System.Collections.Generic;
using rpg_game;
using rpg_game.Game_Classes;

namespace rpg_game.Game_Scenes
{
    class HellGates : Scene
    {
        public override bool Start(ref Player plr)
        {
            Program.print("As you approact the spot marked on your map", delay: 1000);
            Program.print("You look into the horizon and see a grand door\n", delay: 500);

            Program.print("And infront of it, and even grander figure\n", delay: 500);

            Program.print("An earth shaking sound echoes thru the barren plains surrounding you\n\n", delay: 1000);


            Program.print("How dare a mere mortal try to breach my gate?", name: "Demon Of The Gate", delay: 100);
            Program.print("I would rather not waste my time on a lost ant.", name: "Demon Of The Gate", delay: 100);
            Program.print("Heed my words, if you take another step forward, you will lose your head.", name: "Demon Of The Gate", delay: 100);
            Program.print("Now.", name: "Demon Of The Gate", ms: 300, delay: 100);
            Program.print("BEGONE!", name: "Demon Of The Gate", ms: 10, delay: 100);

            ChoiceSelector cs = new ChoiceSelector();
            int choice = cs.update(ref plr, new List<string>() { "Walk away", "Take a taunting step", "Draw you weapon and ready yourself" }, "What do you do?");

            switch (choice)
            {
                case 0:
                    Program.print("As you begin walking away, you take a look over your shoulder to see a satisfied demon with a slight smirk", delay: 100);
                    return false;
                case 1:
                    Program.print("...", ms: 200, name: "Demon Of The Gate", delay: 100);
                    Program.print("It seems that my title has begin to lose its meaning here in the underworld", name: "Demon Of The Gate", delay: 100);
                    Program.print("I will have to make an example", name: "Demon Of The Gate", delay: 1000);
                    Fight.update();
                    break;
                case 2:
                    Program.print("Well, if you insist on dying, be my guest", name: "Demon Of The Gate", delay: 1000);
                    Fight.update();
                    break;
            }

            return false;
        }
    }
}
