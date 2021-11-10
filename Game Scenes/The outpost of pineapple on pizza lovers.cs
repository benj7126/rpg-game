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
            Program.print("You arrive at a fort of sorts, it looks right out of the middle ages or maby somehting you've seen in a fantasy game at some point, you can't really tell.", delay: 200);
            Program.print("What you do see thou is a giant wall made purely of wooden poles with spikes on top, while it's a mystery how it hasen't burned, it's also a mystery where they got the wood from.", delay: 200);
            Program.print("You start pondering over those questions ms500 suddenly a loud noise comes from above the wooden spikes", delay: 200);
            Program.print("WHAT ARE YOU DOING DOWN THERE!?!", name: "Pizza Guard");
            
            ChoiceSelector cs = new ChoiceSelector();
            int answer = cs.update(ref plr, new List<string>() { "Killing traitors!", "Just looking around", "Nothing..." }, "How do you answer?");

            switch (answer)
            {
                case 0:
                    Program.print("Traitors...", name: "Pizza Guard", delay: 400);
                    Program.print("I have heard some rumors, but i must check you're alignment before you can enter.", name: "Pizza Guard", delay: 100);
                    break;
                case 1:
                    Program.print("Well, ms300 a curious thing to do at others peoples property", name: "Pizza Guard", delay: 400);
                    break;
                case 2:
                    Program.print("You sound VERY suspicious", name: "Pizza Guard", delay: 100);
                    Program.print("If i where you i would be on my best behaviour around here. ms200 Or you will have to deal with our boss, and nobody can deal with our boss", name: "Pizza Guard", delay: 100); // hinting to a potential boss fight if you piss them off
                    break;
            }
            Program.print("Either way.", name: "Pizza Guard", delay: 200);
            Program.print("If you want to enter you will have to give me the password", name: "Pizza Guard", delay: 200);

            Console.Write("The password is ");
            string answer2 = Console.ReadLine();

            if (answer2.ToLower() != "elppaenip")
            {
                Program.print("Wrong.", ms: 200, name: "Pizza Guard", delay: 200);
                Program.print("I know you weren't one of us", name: "Pizza Guard", delay: 200);
                Program.print("Now get out of here and never come back", name: "Pizza Guard", delay: 400);
                return true;
            }

            Program.print("That is ms400 right, ms100 welcome to the outpost", name: "Pizza Guard", delay: 200);


            return true;
        }
    }
}
