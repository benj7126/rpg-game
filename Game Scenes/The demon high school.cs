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
        public override bool Start(ref Player plr)
        {        
            Program.print("You've arrived at a school. There's a big sign that says 'EVIL HIGH'");
            Program.print("Under that there's a motto that says", delay: 200);
            Program.print("    'Dream of a better future'", delay: 200);
            Program.print("'Because that's where it'll stay'", delay: 200);
            Program.print("        'In your dreams'\n", delay: 400);
            Program.print("You think to yourself, 'this is probably where PE teachers when they die'", delay: 200)

            Program.print("You walk inside the high school and you find yourself in the main hall");
            Program.print("There's an tired looking demon mopping the floors in a green jumpsuit");
            Program.print("He notices you and signals you over, so with nothing better to do you walk over to him", delay: 200);
            Program.print("Hey man, I'm sorry but you came too late for the devil schoolgirl cosplaying event, it ended like 5 minutes ago", name:"Devious Janitor", delay: 200);
            Program.print("That IS what you were here for right?", name:"Devious Janitor", delay: 200);
            Program.print("Man, what a sight to behold. All the devil schoolgirls of Evil High cosplaying as everyones favorite heroes",name:"Devious Janitor", delay: 200);
            Program.print("I saw Jason Vorhees cosplay, ", delay:200);
            Program.print("One of them even dressed up as that one infamous villain, you know the guy, the one with the green armor and the shotgun, I can't remember the name", delay:200);
            Console.Write("Was his name not ");
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
            Program.print("Perhaps you can still find some Devil schoolgirls who didn't go home yet if you're lucky")
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Program.print("OH! You're a fellow Linux user!!!", name: "LinuxOS User");
                Program.print("Wait! You don't pass just yet!", name: "LinuxOS User");
                Program.print("Which Distro?!?!", name: "LinuxOS User");
                bool rightanswer = false;
                ChoiceSelector distroanswer = new ChoiceSelector();
                int distrochoice = distroanswer.update(ref plr, new List<string>() { "Ubuntu", "Arch", "Gentoo","Mint","Kali Linux", "Ubuntu Satanic Edition","Ubuntu Christian Edition", "POP!" }, "What do you say?");
                switch (distrochoice)
            {
                case 0:
                    rightanswer = true;
                    return false;
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
                        Program.print("Really? cmon man with that you might aswell be using Windows, get on something better", name: "LinuxOS User");
                    break;
            }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Program.print("UGH DISGUSTING, You use Windows, I can't have this in my classroom, I ought to hack you for that, WITH MY SWORD THAT IS!", name: "LinuxOS User");

            }
            else
            {
                Program.print("What the hell are you running?", name: "LinuxOS User");
            }
            return false;
        }
    }
}
