using System;
using System.Threading;
using rpg_game;
using rpg_game.Game_Classes;

namespace rpg_game.Game_Scenes
{
    class Beginning : Scene
    {
        public override void Start()
        {        
            Program.print("Hello *playername You've died");
            Program.print("", delay: 1000);
            Program.print("You've died and gone to hell", delay: 500);
            Program.print("Reasons you've gone to hell are as follows:", delay: 200);
            Program.print("You put pineapple on pizza", delay: 200);
            Program.print("You uploaded fake png images to the internet", delay: 200);
            Program.print("You always walk annoyingly slow in busy places", delay: 200);
            Program.print("You always had you phone turned on in the movie theater and then you would get calls and just generally annoy everyone", delay: 200);
            Program.print("You always run late to class", delay: 1000);
            Program.print("Despite all these completely valid valid reasons you feel like this doom in hell is deeply unfair");

            Program.print("So you wanna escape hell do you?", delay: 200);
            Program.print("Easier done than said", delay: 200);
            Program.print("I heard you could walk right up to the gate and leave actually :/", delay: 200);
            Program.print("But there's a big ass demon guarding the gate so you might not want to do that", delay: 200);
            Program.print("I recommend going to a few places here in hell and preparing to kill that demon", delay: 200);
            Program.print("Actually a good start would be going to this one place where monsters just like you reside", delay: 200);
            Program.print("It's called the outpost for pineapple on pizza lovers", delay: 200);
            Program.print("It's up to you take a look on your map and decide where to go. Warning some places are more dangerous than others.", delay: 200);

        }
    }
}
