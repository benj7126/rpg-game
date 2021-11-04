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

        public void DrawText(string text, int x, int y, int wrapWidth = 0, bool box = false) {
            if(wrapWidth == 0) {
                for(int i = 0; i < text.Length; i++) {
                    DrawChar(text[i], x + i, y);
                }
                if(box)
                    DrawBox(x-1, y-1, x+text.Length+1, y+1);
            } else {
                int init_y = y;
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

                if(box)
                    DrawBox(x-1, init_y-1, x+wrapWidth+1, y);
            }

        }

        public void DrawBox(int x1, int y1, int x2, int y2, bool edges = true) {
            if(x1 > x2) {
                int tmp = x1;
                x1 = x2;
                x2 = tmp;
            }
            if(y1 > y2) {
                int tmp = y1;
                y1 = y2;
                y2 = tmp;
            }
            DrawChar('┌', x1, y1);
            DrawChar('┐', x2, y1);
            DrawChar('┘', x2, y2);
            DrawChar('└', x1, y2);

            if(!edges)
                return;

            for(int y = y1 + 1; y <  y2; y++) {
                DrawChar('│', x1, y);
                DrawChar('│', x2, y);
            }
            for(int x = x1 + 1; x < x2; x++) {
                DrawChar('─', x, y1);
                DrawChar('─', x, y2);
            }
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
        public static void DrawHealthBar(int CurHP, int MaxHP, int x, int y, ref Engine game, HBColor[] colors = null, bool box = false) {
            // Maps HP to a scale, between 0 and 80.
            float hp_perc = (CurHP / (float)MaxHP) * 80;
            int cur_x = x;
            while (hp_perc - 8 >= 0) {
                hp_perc -= 8;
                game.DrawChar('█', cur_x, y);
                cur_x++;
            }

            // choose and draw the last char in healthbar.
            // uses uncode codepoints, casting numbers to chars.
            // 9608 = full block █ (not used here)
            // 9609 = 7/8  block ▉
            // 9610 = 6/8  block ▊
            // and so on.
            if(hp_perc > 1 && hp_perc < 8) {
                int ch = Convert.ToInt32(9609 + (7 - hp_perc));
                game.DrawChar((char)ch, cur_x, y);
            }

            // color handling
            if(colors != null) {
                hp_perc = (CurHP / (float)MaxHP) * 80;
                for(int i = 0; i < colors.Length; i++) {
                    if(colors[i].UnderPerc > hp_perc) {
                        game.SetLineColor(y, colors[i].color);
                        break;
                    }
                }
            }

            // draw box
            if(box) {
                game.DrawBox(x-1, y-1, x+10, y+1, false);
            }

        }
    }

    // HBColor = Health Bar Color
    class HBColor {
        public float UnderPerc;
        public ConsoleColor color;

        public HBColor(float UnderPerc, ConsoleColor color) {
            this.UnderPerc = UnderPerc;
            this.color = color;
        }
    }

    class MenuList {
        List<ListItem> items = new List<ListItem>();
        int SelectedItemIdx;

        public enum InputType {
            Up,
            Down,
            Ok,
            Cancel,
        };

        public MenuList(ListItem[] items) {
            this.items = items.ToList();
        }

        public void HandleInput(InputType ipt) {
            switch(ipt) {
                case InputType.Up:
                    SelectedItemIdx--;
                    break;
                case InputType.Down:
                    SelectedItemIdx++;
                    break;
                case InputType.Ok:
                    break;
                case InputType.Cancel:
                    break;
                default:
                    break;
            }

            WrapIdx();
        }

        private void WrapIdx() {
            if(SelectedItemIdx < 0) {
                SelectedItemIdx = items.Count-1;
            } else if (SelectedItemIdx >= items.Count) {
                SelectedItemIdx = 0;
            }
        }

        public void DrawList(ref Engine game, int x, int y) {
            for(int i = 0; i < items.Count; i++) {
                game.DrawText(items[i].name, x, y+i);
            }

            game.SetLineColor(y+SelectedItemIdx, ConsoleColor.Green);
        }
    }

    class ListItem {
        public string name;

        public ListItem(string name) {
            this.name = name;
        }
    }
}
