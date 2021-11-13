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
            flags.Add("tipped to boss guy", false);
            flags.Add("Barracks", false);
            flags.Add("Shop", false);

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
            if (flags["Barracks"])
            {
                Program.print("You have already been there, and you dont think theres anything left to do");
                return;
            }

            string[] namelist = { "Jacob", "Michael", "Matthew", "Joshua", "Christopher", "Nicholas", "Andrew", "Joseph", "Daniel", "Tyler", "William", "Brandon", "Ryan", "John", "Zachary", "David", "Anthony", "James", "Justin", "Alexander", "Jonathan", "Christian", "Austin", "Dylan", "Ethan", "Benjamin", "Noah", "Samuel", "Robert", "Nathan", "Cameron" };
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
            Program.print("A little after he shouts, an army of people looking a LOT like John run out of the building", delay: 100);
            Program.print("They line up in front of you two and continuing to your right", delay: 100);
            Program.print($"Ok everyone this is {Name}, say hi!", name: "John", delay: 200);
            foreach (string nameI in namelist)
            {
                Program.print($"Hi {Name}!", ms: 1, name: nameI);
            }
            Program.print($"These are my boys!", name: "John", delay: 200);
            Program.print($"I have a lot to do, and I will take you on that guide later so for now. {Name} I'll let them take care of you", name: "John", delay: 200);
            Program.print($"They only bite a little", name: "John", delay: 200);
            Program.print("He chuckles, hopefully indicating a joke", delay: 100);
            Program.print($"You keep an eye on him Jacob", name: "John", delay: 200);
            Program.print("One of the guys nod", delay: 100);
            Program.print("John begins walking away leaving you in Jacob's hands", delay: 100);
            Program.print("All the other people who gathered also walk away", delay: 100);
            Program.print($"Well, follow me then {Name}", name: "Jacob", delay: 200);
            Program.print("Jacob begins walking into the building that you now assume are their barracks, you follow him\n", delay: 100);

            Program.print($"Well, as you know the names Jacob, I dont really do anything around here... Nobody dose, honsetly. It's not like we have anything to do either, well except going and fighting in that arena, speaking off...", name: "Jacob", delay: 200);
            Program.print($"You seem pretty new down here, new to hell that is", name: "Jacob", delay: 200);
            Program.print($"If you don't want to see what happens when you double die, I recomend getting some gear, since that is practically all that matters down here", name: "Jacob", delay: 200);
            Program.print($"If you are confident, you could go to the arena... Thou you might die, so better not be too recless they are merciless over there", name: "Jacob", delay: 200);
            Program.print($"Anyway, for every fight you win over there you get a PPT, pinapple pizza token, if you were wondering. They can be used to trade in for some alright gear", name: "Jacob", delay: 200);

            Program.print("\nWhile walking, you pass a lot of rooms, Jacob stops at one of them", delay: 100);

            if (likeMeter > 0)
            {
                Program.print("Then he mumbles to himself", delay: 100);
                Program.print($"Semms like he's nice enough", name: "Jacob", delay: 200);
                Program.print("He then signals for you to follow him inside", delay: 100);
                Program.print("The room is filled to the brim with random objects", delay: 100);
                Program.print("Jacob begins looking thru them", delay: 100);
                Program.print($"Ah!", name: "Jacob", delay: 200);
                Program.print($"Here you go {Name}", name: "Jacob", delay: 200);
                Program.print("Jacob hands you a handfull of random stuff", delay: 100);
                plr.pickupItem(Item.getItemByID(13));
                plr.pickupItem(Item.getItemByID(14));
                plr.pickupItem(Item.getItemByID(15));
                plr.pickupItem(Item.getItemByID(16));
                plr.pickupItem(Item.getItemByID(17));
                plr.pickupItem(Item.getItemByID(18));
                Program.print("That should help you if you decide to go for the arena, yeah", delay: 100);
            }
            else
            {
                Program.print("Then he mumbles to himself", delay: 100);
                Program.print($"Not nice enough", name: "Jacob", delay: 200);
                Program.print("And continues walking", delay: 100);
            }
            Program.print("The two of you continue walking", delay: 100);
            Program.print("Jacob has more or less shown you around, but there really wasen't anything of much interest to you", delay: 100);
            Program.print("Well that about dose it, ima leave you on your own now, good luck out there man.", delay: 100);
            Program.print("You walk away from the barracks", delay: 100);

            flags["Barracks"] = true;
        }

        private void PinappleArena(ref Player plr)
        {
            Program.print("You walk over to the arena theres a at the entrance", delay: 100);
            Program.print("Fight in the arena", name: "Man at entrance", delay: 100);
            Program.print("If you win you get a token", name: "Man at entrance", delay: 100);
            Program.print("If you lose you will face a horrible death and be released from this place", name: "Man at entrance", delay: 100);
            Program.print("You gain something either way!", name: "Man at entrance", delay: 100);

            ChoiceSelector cs = new ChoiceSelector();
            int choice = cs.update(ref plr, new List<string>() {"yes", "helll naw"}, $"Take on the challenge?");
            if (choice == 0)
            {
                Fight.StartFight(ref plr, Enemy.getById(9));
                Program.print("Nice fight, here ya go", name: "Man at entrance", delay: 100);
                plr.pickupItem(Item.getItemByID(26));
            }
            Program.print("You walk away from the arena", delay: 100);
        }

        private void PinapplePizzaHut(ref Player plr) // this is where the pizza weapons are made (all have ananas on of course)
        {
            if (!flags["Shop"])
            {
                Program.print("While walking around the outpost you stumple into a place called the PP Hut, you are hessitant to go in there, but you do it non the less", delay: 100);
                Program.print("You open up the door and a person comes to great you", delay: 100);

                Program.print("Hey there fella!", name: "Shop owner", delay: 100);
                Program.print("Haven't seen you here beffore...", name: "Shop owner", delay: 100);
                Program.print("Folks around here call me the Shop owner, since i run this damn place", name: "Shop owner", delay: 100);
                Program.print("Oh, yeah, this is a shop if you haden't already noticed", name: "Shop owner", delay: 100);
                Program.print("We make weapons and stuff round ere", name: "Shop owner", delay: 300);
                Program.print("If ya want anythin you will need some a dose PPT's from that one arena over thee, they supply us with food and ingredients so we have our own little currency going on here ya see...", name: "Shop owner", delay: 300);
                Program.print("Wellll, anyways", name: "Shop owner", delay: 100);

                flags["Shop"] = true;
            }

            Program.print("Come look at my wares", name: "Shop owner", delay: 100);

            while (true)
            {
                int cashOnHand = cashOnHandCalc(ref plr);

                List<string> choices = new List<string>();

                for (int i = 0; i < 6; i++)
                {
                    choices.Add($"Look at [{Item.getItemByID(i + 19).name}] - 2 PPT");
                }
                choices.Add("Back");

                ChoiceSelector cs = new ChoiceSelector();
                int choice = cs.update(ref plr, choices, $"Do you want to take a look at anything?");

                if (choice == choices.Count-1)
                {
                    Program.print("You leave the shop", delay: 100);
                    return;
                }

                Item toLookAt = Item.getItemByID(choice+19);
                Program.print($"You walk up to [{toLookAt.name}]", delay: 100);
                Console.WriteLine(Program.convertToLen(toLookAt.description, 60) + "\n");

                Console.WriteLine("Damage: " + toLookAt.damage);
                Console.WriteLine("Defense: " + toLookAt.defence);
                Console.WriteLine("Price: 2 PPT");

                if (cashOnHand > 1)
                {
                    choice = cs.update(ref plr, new List<string>() { "Yes", "No" }, $"You have {cashOnHand} PPT's on you, do you want to buy it");
                    if (choice == 0)
                    {
                        pay(ref plr, 2);
                        plr.pickupItem(toLookAt);
                    }
                }
                else
                {
                    Program.print("You take a step back again since you dont have enough to buy it", delay: 200);
                }
            }

        }

        private int cashOnHandCalc(ref Player plr)
        {
            int cashOnHand = 0;

            for (int i = 0; i < plr.inventory.Length; i++)
            {
                if (!(plr.inventory[i] == null))
                    if (plr.inventory[i].id == 26)
                        cashOnHand++;
            }

            return cashOnHand;
        }
        private void pay(ref Player plr, int amount)
        {
            int amountLeft = amount;

            for (int i = 0; i < plr.inventory.Length; i++)
            {
                if (!(plr.inventory[i] == null))
                    if (plr.inventory[i].id == 26)
                    {
                        amount--;
                        plr.inventory[i] = null;
                        if (amount == 0)
                            return;
                    }
            }
        }

        private void boss(ref Player plr) // this is where the pizza weapons are made (all have ananas on of course)
        {
            Program.print("You cause an uproar", delay: 100);
            Program.print("Throwing stones at people while hiding", delay: 100);
            Program.print("Going around screaming that pinapple on pizza is awfull, still while hiding", delay: 100);
            Program.print("Hitting random people in the head when you pass them", delay: 100);
            Program.print("And you continue doing this, until suddenly, you hear a loud noise", delay: 100);
            Program.print("STOMP STOMP STOMP, the sound comes from behind you, you turn around and see a MASSIVE figurer", delay: 100);

            Program.print($"Hah, hah......", name: "BIG MAN", delay: 200);
            Program.print($"Of all the awfull things you have done here, why did you have to call pinapple on pizza awfull?", name: "BIG MAN", delay: 200);
            Program.print("How do you answer?");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("> Just cuz");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  It's true");
            Console.WriteLine("  Please don't hurt me");
            Console.WriteLine("  Had to get you out here somehow");
            Program.sleep(1000);
            Program.print($"Dont even bother answering", name: "BIG MAN", delay: 200);
            Console.CursorTop -= 5;
            Program.print("  Just cuz", ms:200);
            Console.CursorTop += 4;
            Program.print($"I'ma beat yo ass kid", name: "BIG MAN", delay: 200);
            Fight.StartFight(ref plr, Enemy.getById(10));
        }
    }
}
