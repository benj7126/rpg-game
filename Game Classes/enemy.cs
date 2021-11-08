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
        public string Last_words;
        //public Item[] Drops;

        public Enemy(string name, string introduction, int health, int damage, string last_words) /*, Item[] drops)*/
        {
            Name = name;
            Introduction = introduction;
            Health = health;
            Damage = damage;
            Last_words = last_words;
            //Drops = drops;
        }

        public static Enemy[] enemies =
        {
            new Enemy("name","intro"
                ,1,1,
                "last words"),

            new Enemy("Pineapple on pizza hater","I can see it in you. You enjoy pineapple on pizza!!! You uncultured beast I will cut you down"
                ,1,2,
                "Nooo this can't happen! I can't die! I had just figured out the secret password to the outpost IT WAS JUST PINEAPPLE BACKWARDS, Who will protect pizzas from pineapples now."),

            new Enemy("Socks and sandals wearer","What is this?!?! I see you're wearing socks but NO SANDALS. YOU FIEND. That is a crime against the church of SOCKS AND SANDALS."
                ,3,2,
                "HOW!? how could this happen, Please god send me to a better place in the after after life. A place where sock and sandal may live together in harmony..."),

            new Enemy("Demon (except he has no arms, or legs for that matter)","BEWARE HUMAN. I may have no arms or legs. BUT I'M DEFINTELY DANGEROUS AND I WILL TORMENT YOU."
                ,9,0,
                "It turns out you need arms and legs to deal any damage to your opponent, Curse that green guy with the helmet he sliced them off"),

            new Enemy("Small red demon","They don't make any small size tridents but they had a spare normal size one. It may be too big for me but I'll use it if I must"
                ,3,4,
                "You've defeated me human, I wonder where I'll go now that I'm dead, Hells Hell? I guess I'll see"),

            new Enemy("BIG ASS Demon", "I'm terribly sorry but you're not on the list to get out of hell. Did you send in your appeal on our website? Ahhh screw it. I'll just beat the shit out of you"
                ,20, 5,"HOW! It can't be. A puny human like you defeating me, I was the unstoppable guy protecting the door. I guess I'll have to allow you through the door. Have fun going back to that hellhole called earth.")
        };

    }
}
