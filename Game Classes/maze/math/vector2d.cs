using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;
using System.Threading;
using System.Linq;
using System.Drawing;

namespace rpg_game.Game_Classes.maze.math
{
    class Vector2d {
        public double x, y;

        public Vector2d(double x, double y) {
            this.x = x;
            this.y = y;
        }

        public static bool operator ==(Vector2d vec1, Vector2d vec2) {
            return (vec1.x == vec2.x) && (vec1.y == vec2.y);
        }

        public static bool operator !=(Vector2d vec1, Vector2d vec2) {
            return !((vec1.x == vec2.x) && (vec1.y == vec2.y));
        }

        public static Vector2d operator +(Vector2d vec1, Vector2d vec2) {
            return new Vector2d(vec1.x + vec2.x, vec1.y + vec2.y);
        }
        public static Vector2d operator -(Vector2d vec1, Vector2d vec2) {
            return new Vector2d(vec1.x - vec2.x, vec1.y - vec2.y);
        }
        public static Vector2d operator *(Vector2d vec1, double scalar) {
            return new Vector2d(vec1.x * scalar, vec1.y * scalar);
        }
        public static Vector2d operator *(double scalar, Vector2d vec1) {
            return new Vector2d(vec1.x * scalar, vec1.y * scalar);
        }
        public static Vector2d operator /(Vector2d vec1, double scalar) {
            return new Vector2d(vec1.x / scalar, vec1.y / scalar);
        }

        public Vector2d Floor() {
            return new Vector2d(Math.Floor(x), Math.Floor(y));
        }

        public static void test() {
            Console.WriteLine($"Equals: {new Vector2d(5, 7) == new Vector2d(5, 7)}");
            Console.WriteLine($"EqualsInv: {!(new Vector2d(2, 7) == new Vector2d(5, 7))}");
            Console.WriteLine($"NotEquals: {new Vector2d(2, 7) != new Vector2d(5, 7)}");
            Console.WriteLine($"NotEqualsInv: {!(new Vector2d(5, 7) != new Vector2d(5, 7))}");
            Console.WriteLine("");

            Console.WriteLine($"Add: {(new Vector2d(9, 2) + new Vector2d(-3, 7)) == new Vector2d(6, 9)}");
            Console.WriteLine($"Sub: {(new Vector2d(9, 2) - new Vector2d(-3, 7)) == new Vector2d(12, -5)}");
            Console.WriteLine($"Mult: {(new Vector2d(9, 2) * 2.2) == new Vector2d(19.8, 4.4)}");
            Console.WriteLine($"Mult2: {(2.2 * new Vector2d(9, 2)) == new Vector2d(19.8, 4.4)}");
            Console.WriteLine($"Div: {(new Vector2d(9, 2) / 20) == new Vector2d(0.45, 0.1)}");


            Console.Read();
        }
    }
}
