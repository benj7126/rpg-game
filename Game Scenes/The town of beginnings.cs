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
            Program.print("");
            Thread.Sleep(1000);
            Program.print("You've died and gone to hell");
            Thread.Sleep(500);
            Program.print("Reasons you've gone to hell are as follows:");
            Thread.Sleep(200);
            Program.print("You put pineapple on pizza");
            Thread.Sleep(200);
            Program.print("You uploaded fake png images to the internet");
            Thread.Sleep(200);
            Program.print("You always walk annoyingly slow in busy places");
            Thread.Sleep(200);
            Program.print("You always had you phone turned on in the movie theater and then you would get calls and just generally annoy everyone");
            Thread.Sleep(200);
            Program.print("You always run late to class");
            Thread.Sleep(1000);
            Program.print("Despite all these completely valid valid reasons you feel like this doom in hell is deeply unfair");

            Program.print("So you wanna escape hell do you?");
            Thread.Sleep(200);
            Program.print("Easier done than said");
            Thread.Sleep(200);
            Program.print("I heard you could walk right up to the gate and leave actually :/");
            Thread.Sleep(200);
            Program.print("But there's a big ass demon guarding the gate so you might not want to do that");
            Thread.Sleep(200);
            Program.print("I recommend going to a few places here in hell and preparing to kill that demon");
            Thread.Sleep(200);
            Program.print("Actually a good start would be going to this one place where monsters just like you reside");
            Thread.Sleep(200);
            Program.print("It's called the outpost for pineapple on pizza lovers");
            Thread.Sleep(200);
            Program.print("It's up to you take a look on your map and decide where to go. Warning some places are more dangerous than others.");
            Thread.Sleep(200);

        }
    }
}
