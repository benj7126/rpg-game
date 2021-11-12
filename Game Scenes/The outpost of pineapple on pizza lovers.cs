using System;
using System.Threading;
using System.Collections.Generic;
using rpg_game;
using rpg_game.Game_Classes;

namespace rpg_game.Game_Scenes
{
    class PizzaPineappleOutpost : Scene
    {
        public Dictionary<string, bool> flags = new Dictionary<string, bool>();
        public override bool Start (ref Player plr)
        {
            string[] namelist = { "Jacob", "Michael", "Matthew", "Joshua", "Christopher", "Nicholas", "Andrew", "Joseph", "Daniel", "Tyler", "William", "Brandon", "Ryan", "John", "Zachary", "David", "Anthony", "James", "Justin", "Alexander", "Jonathan", "Christian", "Austin", "Dylan", "Ethan", "Benjamin", "Noah", "Samuel", "Robert", "Nathan", "Cameron" };

            foreach (string nameI in namelist)
            {
                Program.print($"Hi {Name}!", ms: 2, name: nameI);
            }


            flags.Add("tipped to boss guy", false);

            Program.print("Walking around pits of lava and endlessly deep holes.", delay: 200);
            Program.print("A man approaches you, he has a gleem in his eye of someone who just got what he strived for his whole life, or after life if you will.", delay: 200);
            Program.print("HUH!", ms: 30, name: "Stranger", delay: 600);
            Program.print("Who are you?", ms: 20, name: "Stranger", delay: 200);
            Program.print("What are you doing here?", ms: 20, name: "Stranger", delay: 200);
            Program.print("Are you with them?", ms: 20, name: "Stranger", delay: 200);
            Program.print("You are, aren't you", withNLine: false, ms: 20, name: "Stranger", delay: 200);
            Program.print("...", ms: 200, delay: 200);
            Program.print("You're never gonna get me alive!", ms: 40, name: "Stranger", delay: 300);
            Program.print("The strange man comes charging at you with his sword in hand");
            Fight.StartFight(ref plr, Enemy.getById(1));
            Program.print("After you defeated the Pineapple on pizza hater, you continue to walk towards your destination", delay: 200);
            Program.print("...", ms: 300, delay: 200);
            Program.print("You arrive at a fort of sorts, it looks right out of the middle ages or maybe something you've seen in a fantasy game at some point, you can't really tell.", delay: 200);
            Program.print("What you do see though is a giant wall made purely of wooden poles with spikes on top, while it's a mystery how it hasn't burned, it's also a mystery where they got the wood from.", delay: 200);
            Program.print("You start pondering over those questions ms500 suddenly a loud noise comes from above the wooden spikes", delay: 200);
            Program.print("WHAT ARE YOU DOING DOWN THERE!?!", name: "Pizza Guard");
            
            ChoiceSelector cs = new ChoiceSelector();
            int answer = cs.update(ref plr, new List<string>() { "Killing traitors!", "Just looking around", "Nothing..." }, "How do you answer?");

            switch (answer)
            {
                case 0:
                    Program.print("Traitors...", name: "Pizza Guard", delay: 400);
                    Program.print("I have heard some rumors, but i must check your alignment before you can enter.", name: "Pizza Guard", delay: 100);
                    break;
                case 1:
                    Program.print("Well, ms300 a curious thing to do at other people's property", name: "Pizza Guard", delay: 400);
                    break;
                case 2:
                    Program.print("You sound VERY suspicious", name: "Pizza Guard", delay: 100);
                    Program.print("If I where you I would be on my best behaviour around here. ms200 Or you will have to deal with our boss, and nobody can deal with our boss", name: "Pizza Guard", delay: 100); // hinting to a potential boss fight if you piss them off
                    flags["tipped to boss guy"] = true;
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
            Program.print("Open the gates!", name: "Pizza Guard", delay: 200);
            Program.print("As the pizza guard shouts, the big wooden gates slowly begin moving, ms200 after they've open a certain amount you begin making your way into the outpost.", delay: 200);

            bool atOutpost = true;
            while (atOutpost)
            {
                ChoiceSelector destination = new ChoiceSelector();
                int dest = 0;
                if (flags["tipped to boss guy"])
                {
                    dest = destination.update(ref plr, new List<string>() { "To the barracks", "To the pinapple arena", "To the PP Hut", "Manage inventory", "Leave the outpost", "Make a messs of things and get the 'boss' out here" }, "Where will you go?");
                }
                else
                {
                    dest = destination.update(ref plr, new List<string>() { "To the barracks", "To the pinapple arena", "To the PP Hut", "Manage inventory", "Leave the outpost" }, "Where will you go?");
                }

                switch (dest)
                {
                    case 0:
                        Barracks(ref plr);
                        break;
                    case 1:
                        PinappleArena(ref plr);
                        break;
                    case 2:
                        PinapplePizzaHut(ref plr);
                        break;
                    case 3:
                        InvScreen invS = new InvScreen();
                        invS.inv(ref plr);
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine("If you leave you will never be able to come back");
                        ChoiceSelector confirm = new ChoiceSelector();
                        int choice = confirm.update(ref plr, new List<string>() { "Yes", "No" }, "Are you sure?");
                        if (choice == 0)
                        {
                            Program.print("We're done here, Leaving The Outpost...");
                            return true; // delete the place from list of places to go
                        }
                        break;
                    case 5:
                        boss(ref plr);
                        break;
                }
            }
            return true;
        }

        private void Barracks(ref Player plr)
        {
            string Name = "";
            int likeMeter = 0;
            Program.print("While walking around you stumble across a building that looks a little like a house.");
            Program.print("You decide to walk in there, on the way, you get tackled from the right");
            Program.print("You lose your breath as you look up", delay: 500);
            Program.print("HELLO THERE!", name: "Random pineapple dude", delay: 100);
            Program.print("The names John nice to meet you", name: "Random pineapple dude");
            Program.print("While trying to get up from the ground John stretches his hand out the help you");

            ChoiceSelector hand = new ChoiceSelector();
            int choice = hand.update(ref plr, new List<string>() { "Grab it", "I can handle myself" }, "Do you grab it and get up?");
            if (choice == 0)
            {
                likeMeter++;
                Program.print("That's more like it", name: "John");
                Program.print("He pulls you off the ground", delay: 200);
            }
            else
            {
                likeMeter--;
                Program.print("Huh... ms400 not much for friendship I see", name: "John", delay: 100);
                Program.print("Well dosen't really matter, I'm not gonna hold back", name: "John");
                Program.print("A grin forms on his face while you get up from the ground", delay: 200);
            }
            Program.print("You are new around here aren't you?", name: "John", delay: 200);
            Program.print("I know that because I know almost everyone here", name: "John");
            Program.print("'Ah, he's that irritatingly sociable type of person' you think to yourself");
            Program.print("Well what's your name?", name: "John");
            ChoiceSelector name = new ChoiceSelector();
            choice = name.update(ref plr, new List<string>() { "Truth", "Lie", "..." }, "How do you respond?");
            switch (choice)
            {
                case 0:
                    Name = plr.name;
                    Program.print($"{Name}... what a nice name", name: "John");
                    break;
                case 1:
                    Console.Write("My name is ");
                    Name = Console.ReadLine();
                    if (Name == plr.name)
                    {
                        likeMeter++;
                        Program.print($"{Name}... what a nice name", name: "Jhon");
                    }
                    else
                    {
                        likeMeter--;
                        Program.print("He looks at you suspiciously");
                        Program.print($"Hm... {Name} it is", name: "John");
                    }
                    break;
                case 2:
                    likeMeter--;
                    likeMeter--;
                    Name = "Jef";
                    Program.print("The silent type I see, well whatever, I'll just call you", name: "John");
                    Program.print("Ehhhh, Jef, yeah Jef", name: "John");
                    break;
            }
            Program.print($"Well then {Name}, what are you doing around here?", name: "John", delay: 300);
            Program.print($"Doesn't really matther, never mind.", name: "Jhon", delay: 200);
            Program.print($"I'll give you a quick tour around the place", name: "John", delay: 200);
            Program.print("John walks behind you and pushes forward, in a friendly way", delay: 100);
            Program.print("You walk towards the barrack looking building, and right before you would get pushed in there, John stops.", delay: 100);
            Program.print("He takes a deep breath and- ", delay: 100);
            Program.print($"EVERYONE, GET OUT HERE!", ms: 150, name: "John", delay: 200);
            Program.print("A little after he shouts, an army of people looking ALOT like John run out of the building", delay: 100);
            Program.print("They line up in front of you two and continuing to your right", delay: 100);
            Program.print("You begin feeling afraid that you know what's gonna happen now", delay: 100);
            Program.print($"Ok everyone this is {Name}, say hi!", name: "John", delay: 200);
            Program.print($"These are my boys!", name: "John", delay: 200);
            Program.print($"I have a lot to do, and I will take you on that guide later so for now. {Name} I'll let them take care of you", name: "John", delay: 200);
            Program.print($"They only bite a little", name: "John", delay: 200);
            Program.print("He chuckles, hopefully indicating a joke", delay: 100);
            Program.print($"You keep an eye on him Jacob", name: "John", delay: 200);
            Program.print("One of the guys nod", delay: 100);
            Program.print("John begins walking away leaving you in Jacob's hands", delay: 100);
            Program.print("All the other people who gathered also walk away", delay: 100);
        }

        private void PinappleArena(ref Player plr)
        {

        }

        private void PinapplePizzaHut(ref Player plr) // this is where the pizza weapons are made (all have ananas on of course)
        {

        }

        private void boss(ref Player plr) // this is where the pizza weapons are made (all have ananas on of course)
        {

        }
    }
}
