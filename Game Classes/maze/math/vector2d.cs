using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;
using System.Threading;
using System.Linq;
using System.Drawing;

namespace rpg_game.Game_Classes.maze.math
{
    // Vector 2 double.
    class Vector2d {
        // Holds x and y of vector.
        public double x, y;

        public Vector2d(double x, double y) {
            this.x = x;
            this.y = y;
        }

        // Bunch of operator overloading, making vector math easier.
        // Equality operator: Checks if two vectors are equal.
        public static bool operator ==(Vector2d vec1, Vector2d vec2) {
            return (vec1.x == vec2.x) && (vec1.y == vec2.y);
        }

        // Inequality operator: Checks if two vectors are /not/ equal
        public static bool operator !=(Vector2d vec1, Vector2d vec2) {
            return !((vec1.x == vec2.x) && (vec1.y == vec2.y));
        }

        // Addition operator: Adds X to X and Y to Y
        public static Vector2d operator +(Vector2d vec1, Vector2d vec2) {
            return new Vector2d(vec1.x + vec2.x, vec1.y + vec2.y);
        }
        // Subtraction operator: Subtracts X from X and Y from Y
        public static Vector2d operator -(Vector2d vec1, Vector2d vec2) {
            return new Vector2d(vec1.x - vec2.x, vec1.y - vec2.y);
        }
        // Multiplication operator: Multiplies vector by scalar.
        public static Vector2d operator *(Vector2d vec1, double scalar) {
            return new Vector2d(vec1.x * scalar, vec1.y * scalar);
        }
        // Multiplication operator #2: Allows for scalar to be first.
        public static Vector2d operator *(double scalar, Vector2d vec1) {
            return new Vector2d(vec1.x * scalar, vec1.y * scalar);
        }
        // Division operator: Divides vector by scalar.
        public static Vector2d operator /(Vector2d vec1, double scalar) {
            return new Vector2d(vec1.x / scalar, vec1.y / scalar);
        }

        // Non-static function. Floors vector, basically turning it into an
        // integer vector.
        public Vector2d Floor() {
            return new Vector2d(Math.Floor(x), Math.Floor(y));
        }

        // Following function tests the functionality of the operator overloading.
        // Should say true at the end of all the lines.
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
