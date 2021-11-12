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
        public Item[] Drops;

        public void Drop()
        {
            
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

        public Enemy(string name, string introduction, int health, int damage, int id, string last_words) //, Item[] drops) id 0 is defaut for non usable or something
        {
            Name = name;
            Introduction = introduction;
            Health = health;
            Damage = damage;
            ID = id;
            Last_words = last_words;
            //Drops = drops;
        }

        public static Enemy[] enemies =
        {
            new Enemy("ERROR","You did something you should not",
                999999, 999999, 0,
                "how..?"),

            new Enemy("name","intro",
                1, 1, -1,
                "last words"),

            new Enemy("Pineapple on pizza hater","I can see it in you. You enjoy pineapple on pizza!!! You uncultured beast I will cut you down",
                1, 2, 1,
                "Nooo this can't happen! I can't die! I had just figured out the secret password to the outpost IT WAS JUST PINEAPPLE BACKWARDS, Who will protect pizzas from pineapples now."),

            new Enemy("Socks and sandals wearer","What is this?!?! I see you're wearing socks but NO SANDALS. YOU FIEND. That is a crime against the church of SOCKS AND SANDALS.",
                3, 2, 2,
                "HOW!? how could this happen, Please god send me to a better place in the after after life. A place where sock and sandal may live together in harmony..."),

            new Enemy("Demon (except he has no arms, or legs for that matter)","BEWARE HUMAN. I may have no arms or legs. BUT I'M DEFINTELY DANGEROUS AND I WILL TORMENT YOU.",
                9, 0, 3,
                "It turns out you need arms and legs to deal any damage to your opponent, Curse that green guy with the helmet he sliced them off"),

            new Enemy("Small red demon","They don't make any small size tridents but they had a spare normal size one. It may be too big for me but I'll use it if I must",
                3, 4, 4,
                "You've defeated me human, I wonder where I'll go now that I'm dead, Hells Hell? I guess I'll see"),

            new Enemy("Demon Of The Gate", "You seem quit confident, and, i must congratulate you. This will be your last fight here in hell. But, it wont end the way you think",
                1000, 30, 5,
                "HOW! It can't be. A puny human like you defeating me, I was the unstoppable demon protecting the gate. I guess I'll have to allow you through the gate. Have fun going back to that hellhole called earth. You will come to see, it is even worse up there than down here"),

            new Enemy("LinuxOS user","What you're referring to as Linux, is in fact, GNU/Linux, or as I've recently taken to calling it, GNU plus Linux. Linux is not an operating system unto itself, but rather another free component of a fully functioning GNU system made useful by the GNU corelibs, shell utilities and vital system components comprising a full OS as defined by POSIX. But what do you know about that?",
                15, 4, 6,
                "If this game was running on Linux I would've beaten you"),
            new Enemy("Demon","I'm just a vanilla demon guy. Nothing special about me at all really. My views on life are just generally evil and I just don't like humans. You know pretty much what you would expect",
                9, 5, 7,
                "GAAH! THAT HURTS. TIME OUT! TIME OUT! This isn't funny I'm seriously hurt. Someone call the ambulance please."),
            new Enemy ("Cyclops","Eye see you! Get it because I only have one eye. I was born this way don't laugh. Anyways prepare to die...", 13, 6, 8, "Eye didn't see that coming..."),
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
            if (r.Next(0, 10000)/10000 < c)
            {
                plr.pickupItem(i);
            }
        }
    }
}
