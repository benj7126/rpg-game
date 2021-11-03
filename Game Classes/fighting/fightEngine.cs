using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Fight_Engine
{
    class Engine
    {
        GameParams parameters = new GameParams();

        List<char> buffer1;
        List<char> buffer2;

        Dictionary<int, ConsoleColor> colors = new Dictionary<int, ConsoleColor>();

        bool firstBuffer = true;

        public Engine(int win_width, int win_height, string game_name) {
            char[] tmp = new char[win_width * win_height];
            buffer1 = tmp.ToList();
            buffer2 = tmp.ToList();
            parameters.winWidth = win_width;
            parameters.winHeight = win_height;
            parameters.name = game_name;
        }

        public int GetWinWidth() { return parameters.winWidth; }
        public int GetWinHeight() { return parameters.winHeight; }

        public void SetLineColor(int line, ConsoleColor col) {
            colors.Add(line, col);
        }

        public void DrawChar(char ch, int x, int y) {
            if (x < 0 || x > GetWinWidth() || y < 0 || y > GetWinHeight()) {
                throw new ArgumentOutOfRangeException();
            }

            if(!firstBuffer) {
                DrawToFramebuffer(ch, x, y, ref buffer1);
            } else {
                DrawToFramebuffer(ch, x, y, ref buffer2);
            }
        }

        public void DrawText(string text, int x, int y, int wrapWidth = 0) {
            if(wrapWidth == 0) {
                for(int i = 0; i < text.Length; i++) {
                    DrawChar(text[i], x + i, y);
                }
            } else {
                // Remove spaces at start of lines
                for(int i = 0; i < text.Length; i+=wrapWidth) {
                    if(text[i] == ' ')
                        text = text.Remove(i, 1);
                }
                for(int j = 0; j < 1 + text.Length / wrapWidth; j++) {
                    for(int i = 0; i < wrapWidth; i++) {
                        try {
                            DrawChar(text[i + j * wrapWidth], x + i, y);
                        } catch (Exception e) {
                            break;
                        }
                    }
                y++;
                }
            }

        }

        public void DrawBox(int x1, int y1, int x2, int y2) {
            DrawChar('┌', x1, y1);
            DrawChar('┐', x2, y1);
            DrawChar('┘', x2, y2);
            DrawChar('└', x1, y2);
        }

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

        private void DrawToFramebuffer(char ch, int x, int y, ref List<char> buffer) {
            buffer[x + y*GetWinWidth()] = ch;
        }

        public void SwapBuffers() {
            char[] tmp = new char[GetWinWidth() * GetWinHeight()];
            if(firstBuffer) {
                buffer1 = tmp.ToList();
            } else {
                buffer2 = tmp.ToList();
            }
            firstBuffer = !firstBuffer;
        }

        public void DrawScreen() {
            if(firstBuffer) {
                DrawBuffer(buffer1);
            } else {
                DrawBuffer(buffer2);
            }

            colors = new Dictionary<int, ConsoleColor>();
        }

        private void DrawBuffer(List<char> buffer) {
            int winWidth = GetWinWidth();
            int winHeight = GetWinHeight();

            for(int y = 0; y <  winHeight; y++) {
                string line = "";
                for(int x = 0; x < winWidth; x++) {
                    line += buffer[x + y*winWidth];
                    if(buffer[x + y*winWidth] == '\0') {
                        line += ' ';
                    }
                }
                Console.ForegroundColor = colors.ContainsKey(y) ? colors[y] : ConsoleColor.White;
                Console.WriteLine(line);
            }
        }
    }
    class GameParams {
        public int winWidth, winHeight;
        public string name;
    }

    class FightHelpers {
        public static void DrawHealthBar(int CurHP, int MaxHP, int x, int y, ref Engine game) {
            float hp_perc = (CurHP / (float)MaxHP) * 80;
            int cur_x = x;
            while (hp_perc - 8 >= 0) {
                hp_perc -= 8;
                game.DrawChar('█', cur_x, y);
                cur_x++;
            }

            if(hp_perc > 1 && hp_perc < 8) {
                int ch = Convert.ToInt32(9609 + (7 - hp_perc));
                game.DrawChar((char)ch, cur_x, y);
            }
        }
    }
}
