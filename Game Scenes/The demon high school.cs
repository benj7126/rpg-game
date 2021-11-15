using System;
using System.Threading;
using System.Collections.Generic;
using rpg_game;
using rpg_game.Game_Classes;
using System.Runtime.InteropServices;

namespace rpg_game.Game_Scenes
{
    class DemonHighSchool : Scene
    {
        public Dictionary<string, bool> flags = new Dictionary<string, bool>();

        public override bool Start(ref Player plr)
        {
            flags.Clear();
            flags.Add("Defeated Linux user", false);
            flags.Add("Talked to Girl", false);
            flags.Add("Been to lockers", false);
            flags.Add("pickup", false); 
            flags.Add("Been to cafe", false);


            Program.print("You've arrived at a school. There's a big sign that says 'EVIL HIGH'");
            Program.print("Under that there's a motto that says", delay: 200);
            Program.print("    'Dream of a better future'", delay: 200);
            Program.print("'Because that's where it'll stay'", delay: 200);
            Program.print("        'In your dreams'\n", delay: 400);
            Program.print("You think to yourself, 'this is probably where PE teachers go when they die'", delay: 200);

            Program.print("You walk inside the high school and you find yourself in the main hall");
            Program.print("There's a tired looking demon mopping the floors in a green jumpsuit");
            Program.print("He notices you and signals you over, so with nothing better to do you walk over to him", delay: 200);
            Program.print("Hey man, I'm sorry but you came too late for the devil schoolgirl cosplaying event, it ended like 5 minutes ago", name:"Devious Janitor", delay: 200);
            Program.print("That IS what you were here for right?", name:"Devious Janitor", delay: 200);
            Program.print("Man, what a sight to behold. All the devil schoolgirls of Evil High cosplaying as everyones favorite characters",name:"Devious Janitor", delay: 200);
            Program.print("One of them even dressed up as that one infamous villain, you know the guy, the one with the green armor and the shotgun, I can't remember the name", name: "Devious Janitor", delay:200);
            Program.print("You think to yourself. And answer");
            Console.Write("Was his name not:");
            string doomGuy = Console.ReadLine();

            if(doomGuy.ToLower() == "doom guy" || doomGuy.ToLower() == "doomguy" || doomGuy.ToLower() == "the guy from doom" || doomGuy.ToLower() == "doom" ||doomGuy.ToLower() == "doom marine" || doomGuy.ToLower() == "doom slayer" || doomGuy.ToLower() == "slayer")
            {
                Program.print("Right! that's the one", name: "Devious Janitor", delay:200);
                Program.print("Thanks for reminding me, here have this, the cosplayer didn't need it and just gave it to me. Turns out it's fully functional",name: "Devious Janitor", delay:200);
                Program.print("You've recieved a 'Super Shotgun'", delay:200);
                plr.pickupItem(Item.getItemByID(4));

            }

            else
            {
                Program.print("I don't think that's quite right", name: "Devious Janitor", delay:200);
            }


            Program.print("Well it's all over now, you shoulda come earlier");
            Program.print("I think the only people still here are the nerds who didn't go to the event, sitting over in the computer science room");
            Program.print("Perhaps you can still find some Devil schoolgirls who didn't go home yet if you're lucky");

            bool atSchool = true;
            while (atSchool)
            {
                ChoiceSelector destination = new ChoiceSelector();
                int dest = destination.update(ref plr, new List<string>() { "To the computer science room","To the lockers","To the cafeteria","Manage inventory", "Leave school" }, "Where will you go?");

                switch (dest)
                {
                    case 0:
                        ComputerScienceRoom(ref plr);
                        break;
                    case 1:
                        Lockerhall(ref plr);
                        break;
                    case 2:
                        Cafeteria(ref plr);
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
                            Program.print("We're done here, Leaving Demon High School...");
                            return true; // delete the place form list of places to go
                        }
                        break;

                }
            }
            return false;
        }

        private void ComputerScienceRoom(ref Player plr)
        {
            if (flags["Defeated Linux user"])
            {
                Program.print("Coming to flaunt now?", name: "LinuxOS User");
                Program.print("Get out of my sight", name: "LinuxOS User", delay: 300);
                return;
            }

            Program.print("You walk down the hall to arrive to a room with a sign that says computer science", delay: 200);
            Program.print("The door is closed but you hear a bunch of comotion going on inside ", delay: 200);
            Program.print("You slowly open the door and you're greeted by a few devils sitting at computers behind their desks.");
            Program.print("One of them looks at you and says");
            Program.print("Who are you?", name: "LinuxOS User",delay: 200);
            Program.print("Ahh whatever it doesn't matter. If you want to be in here you have to show me what OS you run", name: "LinuxOS User",delay: 200);
            Program.print("I'll check it real quick", name: "LinuxOS User",delay: 200);
            Program.print(". ms100 . ms100 . ms100");
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Program.print("OH! You're a fellow Linux user!!!", name: "LinuxOS User");
                Program.print("Wait! You don't pass just yet!", name: "LinuxOS User");
                Program.print("Which Distro?!?!", name: "LinuxOS User");
                bool rightanswer = false;
                ChoiceSelector distroanswer = new ChoiceSelector();
                int distrochoice = distroanswer.update(ref plr, new List<string>() { "Ubuntu", "Arch", "Gentoo", "Mint", "Kali Linux", "Ubuntu Satanic Edition", "Ubuntu Christian Edition", "POP!_OS", "Hannah Montana Linux" }, "What do you say?");
                switch (distrochoice)
                {
                    case 0:
                        rightanswer = true;
                        break;
                    case 1:
                        rightanswer = true;
                        break;
                    case 2:
                        Program.print("Gentoo!?! Just... WHY?", name: "LinuxOS User");
                        break;
                    case 3:
                        break;
                    case 4:
                        Program.print("Kali Linux?! What the hell are you tryna do?", name: "LinuxOS User");
                        break;
                    case 5:
                        Program.print("I personally use this one myself actually", name: "LinuxOS User");
                        rightanswer = true;
                        break;
                    case 6:
                        Program.print("UBUNTU CHRISTIAN EDITION!?! YOU HOLY FIEND, I CAN'T HAVE THIS. FACE ME IN BATTLE!", name: "LinuxOS User");
                        break;
                    case 7:
                        Program.print("Really? come on man with that you might aswell be using Windows smh, get on something better", name: "LinuxOS User");
                        break;
                    case 8:
                        Program.print("You might get along well with my daughter.", name: "LinuxOS User");
                        rightanswer = true;
                        break;
                }
                if (rightanswer == false)
                {
                    Fight.StartFight(ref plr, Enemy.getById(6));
                    Program.print("I can't believe your weird distro was better than mine. I guess you win. Have this and get outta here", name: "LinuxOS User");
                plr.pickupItem(Item.getItemByID(7));
                }
                if (rightanswer == true)
                {
                    Program.print("Alright you pass. Here Linux users must stick together, ms100 have this", name: "LinuxOS User",delay: 200);
                    plr.pickupItem(Item.getItemByID(7));
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Program.print("WINDOWS?!?! UGH DISGUSTING, I can't have this in my classroom, I ought to hack you for that, WITH MY SWORD THAT IS!", name: "LinuxOS User");
                Fight.StartFight(ref plr, Enemy.getById(6));
                Program.print("I can't believe your inferior OS defeated me. I guess you win. Have this and get outta here", name: "LinuxOS User");
                plr.pickupItem(Item.getItemByID(7));
            }
            else
            {
                Program.print("What the hell are you running?", name: "LinuxOS User");
                Fight.StartFight(ref plr, Enemy.getById(6));
                Program.print("I can't believe your inferior OS defeated me. I guess you win. Have this and get outta here", name: "LinuxOS User");
                plr.pickupItem(Item.getItemByID(7));
            }

            flags["Defeated Linux user"] = true;
        }

        private void Lockerhall(ref Player plr) 
        {
            if (flags["Been to lockers"])
            {
                Program.print("You've already been here", delay: 100);

                if (flags["pickup"] == false)
                {
                    Program.print("But it seems theres still more to do", delay: 100);
                    Program.print("Have you come back to steal a school uniform?", delay: 100);
                    uniform(ref plr);
                    return;
                }
                else
                {
                    Program.print("You should go somewhere else", delay: 100);
                    return;
                }
            }
            Program.print("You walk down the hallway to the lockers", delay: 100);
            Program.print("You see a long line of closed lockers", delay: 100);
            Program.print("The building is almost empty it must be late on the day", delay: 100);
            Program.print("You walk down the hall and notice there's two lockers that are open", delay: 100);
            Program.print("You look inside the lockers and see they both contain a bundle of school uniforms in them", delay: 100);
            Program.print("One of the lockers contains a male School Uniform, and the other one, a female school uniform", delay: 100);
            Program.print("You have been feeling quite weird about walking around school without wearing a uniform", delay: 100);
            Program.print("I think it'd be okay if you took one of them", delay: 100);
            uniform(ref plr);
            Program.print("Nobody is around the locker halls so you decide to try to find something else", delay: 100);
            flags["Been to lockers"] = true;
        }

        private void uniform(ref Player plr)
        {
            ChoiceSelector uniform2 = new ChoiceSelector();
            int uniformchoice2 = uniform2.update(ref plr, new List<string>() { "Male School Uniform", "Female School Uniform", "Don't take one" }, "Which one do you take?");
            if (uniformchoice2 == 0)
            {
                Program.print("You grab the male uniform, ms100 I'm sure they won't miss it", delay: 100);
                flags["pickup"] = plr.pickupItem(Item.getItemByID(5));

            }
            else if (uniformchoice2 == 1)
            {
                Program.print("You grab the female uniform, ms100 I'm sure they won't miss it", delay: 100);
                flags["pickup"] = plr.pickupItem(Item.getItemByID(6));

            }
            else
            {
                Program.print("It's not nice to steal. I'll just wear my own clothes for now", name: $"{plr.name}", delay: 100);
            }
        }

        private void Cafeteria(ref Player plr)
        {
            if (flags["Been to cafe"])
            {
                Program.print("You've already been here,", delay: 100);
                if (!flags["Talked to Girl"])
                {
                    Program.print("That girl is still here though", delay: 100);
                    girl(ref plr);
                    return;
                }
                else
                {
                    Program.print("You leave the cafeteria");
                    return;
                }
            }
            Program.print("You walk into the cafeteria, see there's still a few students left hanging out here", delay: 100);
            Program.print("You look around and notice this Cute devil schoolgirl standing around", delay: 100);
            Program.print("She's got red skin, sharp horns and she's wearing the Evil High school uniform", delay: 100);
            Program.print("Exactly your type", delay: 100);
            Program.print("You're feeling good about yourself, you bet you could impress this girl", delay: 100);
            Program.print("I'm sure nothing bad could come of just tryna talk to her", delay: 100);
            Program.print("I mean this is the after life after all, ms100 what do you have to lose?", delay: 100);
            girl(ref plr);
            flags["Been to cafe"] = true;
            return;
        }

        private void girl(ref Player plr)
        {

            ChoiceSelector GirlTalk2 = new ChoiceSelector();
            int GirlTalkChoice2 = GirlTalk2.update(ref plr, new List<string>() { "Say hello to the girl", "Nah screw that" }, "Do you muster up the courage to talk to her?");
            if (GirlTalkChoice2 == 0)
            {
                Program.print("Hey. ms50 How you doing lady");
                if (plr.equipped[Player.itemPlace.Armor] != null)
                {
                    if (plr.equipped[Player.itemPlace.Armor].name == "Male School uniform" || plr.equipped[Player.itemPlace.Armor].name == "Female School uniform")
                    {
                        Program.print("Hey, I haven't seen you around here before are you new?", name: "Devil School girl", delay: 100);
                        Program.print("You don't look like a demon", name: "Devil School girl", delay: 100);
                        Program.print("Yea I'm actually from earth I just got here recently, I'm just trying to figure out a way back, quite an evil school you guys have", name: $"{plr.name}", delay: 100);
                        Program.print("Oh wow, ms100 you want to escape hell? I heard that's a daunting task.", name: "Devil School girl", delay: 100);
                        Program.print("You're lucky you talked to me, I take a real liking to humans, here have this, it'll help you get through hell's dangers", name: "Devil School girl", delay: 100);
                        Program.print("You've received a Devilish ring of defense", delay: 100);

                        plr.pickupItem(Item.getItemByID(8));
                        flags["Talked to Girl"] = true;
                    }
                    else
                    {
                        Program.print($"OMG are you seriously trying to talk with me while wearing that {plr.equipped[Player.itemPlace.Armor].name}, That's sooo last year. Come back when you've found something more stylish.", name: "Devil School girl", delay: 200);
                        Program.print("OOF, maybe you should try to find something else to wear. Perhaps you can find some clothes around the school.", name: "Devil School girl");
                    }
                    Program.print("You leave the cafeteria");
                    return;
                }
                else
                {
                    Program.print("How dare you apprach me with only boxers.", name: "Devil School girl");
                    Program.print("DUSGUSTING", name: "Devil School girl", ms: 20);
                    Program.print("You shamefully leave the cafeteria");
                    return;
                }
            }
        }
    }
}
