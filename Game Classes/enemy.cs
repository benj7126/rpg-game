using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;

namespace rpg_game.Game_Classes
{
    class Enemy
    {
        public string Name;
        public string Introduction;
        public int Health;
        public int Damage;
        public int ID;
        public string Last_words;
        public drop[] Drops;

        public void Drop(ref Player plr)
        {
            foreach (drop d in Drops)
            {
                d.dropItem(ref plr);
            }
        }

        public static Enemy getByName(string name)
        {
            foreach (Enemy e in enemies)
            {
                if (e.Name == name)
                    return e;
            }
            return enemies[0];
        }
        public static Enemy getById(int id)
        {
            foreach (Enemy e in enemies)
            {
                if (e.ID == id)
                    return e;
            }
            return enemies[0];
        }

        public Enemy(string name, string introduction, int health, int damage, int id, string last_words, drop[] drops) // id 0 is defaut for non usable or something
        {
            Name = name;
            Introduction = introduction;
            Health = health;
            Damage = damage;
            ID = id;
            Last_words = last_words;
            Drops = drops;
        }

        public static Enemy[] enemies =
        {
            new Enemy("ERROR","You did something you should not",
                999999, 999999, 0,
                "how..?",
                new drop[] { }),

            new Enemy("name","intro",
                1, 1, -1,
                "last words",
                new drop[] { }),

            new Enemy("Pineapple on pizza hater","I can see it in you. You enjoy pineapple on pizza!!! You uncultured beast I will cut you down",
                5, 3, 1,
                "Nooo this can't happen! I can't die! I had just figured out the secret password to the outpost IT WAS JUST PINEAPPLE BACKWARDS, Who will protect pizzas from pineapples now.",
                new drop[] { }),

            new Enemy("Socks and sandals wearer","What is this?!?! I see you're wearing socks but NO SANDALS. YOU FIEND. That is a crime against the church of SOCKS AND SANDALS.",
                9, 4, 2,
                "HOW!? how could this happen, Please god send me to a better place in the after after life. A place where sock and sandal may live together in harmony...",
                new drop[] { }),

            new Enemy("Demon (except he has no arms, or legs for that matter)","BEWARE HUMAN. I may have no arms or legs. BUT I'M DEFINTELY DANGEROUS AND I WILL TORMENT YOU.",
                12, 0, 3,
                "It turns out you need arms and legs to deal any damage to your opponent, Curse that green guy with the helmet he sliced them off",
                new drop[] { }),

            new Enemy("Small red demon","They don't make any small size tridents but they had a spare normal size one. It may be too big for me but I'll use it if I must",
                6, 7, 4,
                "You've defeated me human, I wonder where I'll go now that I'm dead, Hells Hell? I guess I'll see",
                new drop[] { }),

            new Enemy("Demon Of The Gate", "You seem quite confident, and, i must congratulate you. This will be your last fight here in hell. But, it wont end the way you think",
                1000, 30, 5,
                "HOW! It can't be. A puny human like you defeating me, I was the unstoppable demon protecting the gate. I guess I'll have to allow you through the gate. Have fun going back to that hellhole called earth. You will come to see, it is even worse up there than down here",
                new drop[] { }),

            new Enemy("LinuxOS user","What you're referring to as Linux, is in fact, GNU/Linux, or as I've recently taken to calling it, GNU plus Linux. Linux is not an operating system unto itself, but rather another free component of a fully functioning GNU system made useful by the GNU corelibs, shell utilities and vital system components comprising a full OS as defined by POSIX. But what do you know about that?",
                15, 6, 6,
                "If this game was running on Linux I would've beaten you",
                new drop[] { }),

            new Enemy("Demon","I'm just a vanilla demon guy. Nothing special about me at all really. My views on life are just generally evil and I just don't like humans. You know, pretty much what you would expect",
                9, 5, 7,
                "GAAH! THAT HURTS. TIME OUT! TIME OUT! This isn't funny I'm seriously hurt. Someone call the ambulance please.",
                new drop[] {new drop(Item.getItemByID(9), 0.1f), new drop(Item.getItemByID(10), 0.02f)}),

            new Enemy ("Cyclops","Eye see you! Get it because I only have one eye. I was born this way don't laugh. Anyways prepare to die...", 13, 7, 8, "Eye didn't see that coming...",
                new drop[] {new drop(Item.getItemByID(9), 0.1f), new drop(Item.getItemByID(10), 0.02f)}),

            new Enemy("PP Gladiator","IT STANDS FOR PINEAPPLE PIZZA, PINEAPPLE PIZZA I TELL YOU!!!",
                20, 10, 9,
                "*cough* Nice figt m8, the future of pineapples on pizzas are looking bright",
                new drop[] { }),

            new Enemy("PP Boss man","How dare you make a mess here at the pineapple on pizza outpost? Face my wrath",
                50, 14, 10,
                "It... was a good fight... seems like pizzas will... never see pineapples again. I give you my last pizza take care of it",
                new drop[] {new drop(Item.getItemByID(12), 1f)}),
        };

    }
    class drop
    {
        Item i;
        float c;
        public drop(Item item, float chance)
        {
            i = item;
            c = chance;
        }

        public void dropItem(ref Player plr)
        {
            Random r = new Random();
            float rNr = r.Next(0, 10000) / 10000;
            Console.WriteLine(rNr + " | " + c);
            if (rNr < c)
            {
                Program.print($"You found [{i.name}] after defeating the enemy");
                plr.pickupItem(i);
            }
        }
    }
}
