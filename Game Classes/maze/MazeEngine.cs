using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;
using System.Threading;
using System.Linq;
using Pastel;
using System.Drawing;

namespace rpg_game.Game_Classes.maze
{
    class MazeEngine {
        GameParams parameters = new GameParams();

        // Double buffer system made for futureproofing. Allows for possible
        // multi-threading. One thread rendering, another running the game.
        // One buffer is show, while the game thread renders to the other.
        List<string> buffer1;
        List<string> buffer2;

        bool firstBuffer = true;

        public MazeEngine(int win_width, int win_height, string game_name) {
            // Used to initialize the buffers to and empty sized list.
            string[] tmp = new string[win_width * win_height];
            buffer1 = tmp.ToList();
            buffer2 = tmp.ToList();
            // Sets game parameters.
            parameters.winWidth = win_width;
            parameters.winHeight = win_height;
            parameters.name = game_name;

            // Sets the console window title to the game name.
            Console.Title = game_name;
        }

        public int GetWinWidth() { return parameters.winWidth; }
        public int GetWinHeight() { return parameters.winHeight; }

        // Used to draw char to current buffer.
        public void DrawChar(char ch, int x, int y) {
            // Return exception, if char is out of game window.
            if (x < 0 || x > GetWinWidth() || y < 0 || y > GetWinHeight()) {
                throw new ArgumentOutOfRangeException();
            }

            // Decides buffer to draw to. Does so using other function.
            if(!firstBuffer) {
                DrawToFramebuffer(ch.ToString(), x, y, ref buffer1);
            } else {
                DrawToFramebuffer(ch.ToString(), x, y, ref buffer2);
            }
        }

        // Same as other DrawChar, except accepts strings.
        public void DrawChar(string ch, int x, int y) {
            // Return exception, if char is out of game window.
            if (x < 0 || x > GetWinWidth() || y < 0 || y > GetWinHeight()) {
                throw new ArgumentOutOfRangeException();
            }

            // Decides buffer to draw to. Does so using other function.
            if(!firstBuffer) {
                DrawToFramebuffer(ch, x, y, ref buffer1);
            } else {
                DrawToFramebuffer(ch, x, y, ref buffer2);
            }
        }

        // Draws a centered vertical line, width xPos, Height and Color.
        public void DrawVerLine(int x, int height, Color color) {
            // If height is larger than game window size, set it to max height.
            height = height > GetWinHeight() ? GetWinHeight() : height;
            // Return exception, if char is out of game window.
            if (x < 0 || x > GetWinWidth()) {
                throw new ArgumentOutOfRangeException();
            }

            // Draw line, by choosing a starting Y and looping through height in
            // a for loop.
            int startY = GetWinHeight()/2 - height/2;
            for(int i = 0; i < height; i++) {
                // Draw the line, using NuGet package "Pastel" to color, using
                // ansi escape sequences.
                DrawChar("█".Pastel(color), x, startY+i);
            }
        }

        // Unused
        public void DrawBackground(Color groundCol, Color skyCol, int visRange) {
            //DrawGround(groundCol, visRange);
            DrawSky(skyCol, visRange);
        }

        // Unused
        private void DrawGround(Color col, int visRange) {
            for(int x = 0; x < GetWinWidth(); x++) {
                for(int y = GetWinHeight()-1; y > GetWinHeight()/2; y--) {
                    col = Color.FromArgb(
                        (int)(Math.Max(0, col.R - y*visRange/2 )),
                        (int)(Math.Max(0, col.G - y*visRange/2 )),
                        (int)(Math.Max(0, col.B - y*visRange/2 )));
                    DrawChar("█".Pastel(col), x, y);
                }
            }
        }

        // Unused
        private void DrawSky(Color col, int visRange) {
            for(int x = 0; x < GetWinWidth(); x++) {
                for(int y = 0; y < GetWinHeight()/2; y++) {
                    DrawChar("█".Pastel(col), x, y);
                }
            }
        }

        // Draws a border around game window
        public void DrawBorder() {
            int winWidth = GetWinWidth();
            int winHeight = GetWinHeight();
            for(int y = 0; y <  winHeight; y++) {
                DrawChar('█', 0, y);
                DrawChar('█', winWidth-1, y);
            }
            for(int x = 0; x < winWidth; x++) {
                DrawChar('█', x, 0);
                DrawChar('█', x, winHeight-1);
            }
        }

        // Draws char to specific framebuffer. Used internally by DrawChar
        // functions.
        private void DrawToFramebuffer(string ch, int x, int y, ref List<string> buffer) {
            buffer[x + y*GetWinWidth()] = ch;
        }

        // Swaps the buffers.
        public void SwapBuffers() {
            string[] tmp = new string[GetWinWidth() * GetWinHeight()];

            // Clears the buffer, to be rendered to now.
            if(firstBuffer) {
                buffer1 = tmp.ToList();
            } else {
                buffer2 = tmp.ToList();
            }

            firstBuffer = !firstBuffer;
        }

        // Draws the active buffer, using DrawBuffer.
        public void DrawScreen() {
            if(firstBuffer) {
                DrawBuffer(buffer1);
            } else {
                DrawBuffer(buffer2);
            }
        }

        // Draws specific buffer.
        private void DrawBuffer(List<string> buffer) {
            int winWidth = GetWinWidth();
            int winHeight = GetWinHeight();

            // Move the cursor to the top, rendering over the previous screen.
            // This used to be Console.Clear(), but that has insane flickering
            // problems on Windows.
            Console.CursorTop = 0;
            // Draw buffer, line by line. This improves performance.
            for(int y = 0; y <  winHeight; y++) {
                string line = "";
                for(int x = 0; x < winWidth; x++) {
                    line += buffer[x + y*winWidth];
                    if(buffer[x + y*winWidth] == null) {
                        line += " ".PastelBg(Color.Black);
                    }
                }
                Console.WriteLine(line);
            }
        }
    }
    class GameParams {
        public int winWidth, winHeight;
        public string name;
    }
}
