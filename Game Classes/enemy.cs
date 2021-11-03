using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;

namespace rpg_game.Game_Classes
{
    class enemy
    {
        public string Name;
        public string Introduction;
        public int Health;
        public int Damage;
        public string Last_words;

        public enemy(string name, string introduction, int health, int damage, string last_words)
        {
            Name = name;
            Introduction = introduction;
            Health = health;
            Damage = damage;
            Last_words = last_words;
        }

        public static enemy[] enemys =
        {
            new enemy("name","intro"
                ,1,1,
                "last words"),

            new enemy("Pineapple on pizza hater","I can see it in you. You enjoy pineapple on pizza!!!.You uncultured beast I will cut you down"
                ,1,2,
                "Nooo this can't happen! I can't die! Who will protect pizzas from pineapples."),

            new enemy("Socks and sandals wearer","What is this?!?! I see you're wearing socks but NO SANDALS. YOU FIEND. That is a crime against the church of SOCKS AND SANDALS."
                ,3,2,
                "HOW!? how could this happen, Please god send me to a better place in the after after life. A place where sock and sandal may live together in harmony..."),

            new enemy("DEMON (except he has no arms, or legs for that matter)","BEWARE HUMAN. I may have no arms or legs. BUT I'M DEFINTELY A DANGEROUS DEMON AND I WILL TORMENT YOU."
                ,9,0,
                "Not fair alright "),

            new enemy("name","intro"
                ,1,1,
                "last words"),
        };

    }
}
