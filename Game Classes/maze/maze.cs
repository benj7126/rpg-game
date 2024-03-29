using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;
using System.Threading;
using System.Linq;
using System.Drawing;
using rpg_game.Game_Classes.maze.math;

namespace rpg_game.Game_Classes.maze
{
    class Maze {

        // Numbers and their colors.
        static Dictionary<int, Color> colors = new Dictionary<int, Color>() {
            {1, Color.FromArgb(255, 255, 255)},
            {2, Color.FromArgb(0,   255, 0  )},
            {3, Color.FromArgb(255, 0,   0  )},
            {101, Color.FromArgb(0,   255, 0  )}, // Also used as collision box for winning.
            {102, Color.FromArgb(255, 0,   0  )}, // Also used for leaving the maze
        };

        // Returns true if maze is completed, false if exited.
        public static bool StartMaze(Map map) {
            return Start(map);
        }

        private static bool Start(Map map) {
            Console.Clear();
            MazeEngine game = new MazeEngine(80, 40, "maze");

            // Position vector
            Vector2d pos = new Vector2d(5.5, 7.5);
            // Directional unit vector
            Vector2d dir = new Vector2d(0, 1);
            // Camera view plane, held as 2d vector line.
            // Were this actually 3d, not raycasting, it would be a plane,
            // represtented by 2 vectors.
            Vector2d plane = new Vector2d(0.33, 0);

            // The location of the win and exit cells
            Vector2d winC = new Vector2d(-1, -1);
            Vector2d extC = new Vector2d(-1, -1);

            // The visibility distance. Controls the distance-based darkening.
            int visRange = 25;

            // Loops through all cells, checking for control cells.
            for(int x = 0; x < map.Width; x++) {
                for(int y = 0; y < map.Height-1; y++) {
                    int cell = map.GetCell(x, y);
                    // Control cells are above 100
                    if(cell >= 100) {
                        switch(cell) {
                            case 100: // SpawnPoint
                                // Removes spawnpoint cell
                                map.SetCellRel(x, y, 0);
                                pos.x = 0.5 + x;
                                pos.y = 0.5 + y;
                                break;
                            case 101: // WinPoint
                                winC.x = x;
                                winC.y = y;
                                break;
                            case 102: // ExitPoint
                                extC.x = x;
                                extC.y = y;
                                break;
                        }
                    }
                }
            }

            // Main game loop
            while(true) {
                // game.DrawBackground(Color.FromArgb(255, 255, 0), Color.Blue, visRange);

                // Loop through every x in the "window", casting a ray for each.
                // ---
                // Raycasting is done using the digital differential analyzer
                // algorithm. For a straight line, the x distance, between
                // intersections of a grid on the y axis, is the same. Same goes
                // inverse. By checking all the intersected cells for both,
                // swtiching between them and always using the current shortest,
                // the first gridcell intersection can be found.
                for(int x = 0; x < game.GetWinWidth(); x++) {
                    // The current x-coordinate on the camera viewport "plane"
                    // (line), corresponding to the current viewspace
                    // x-coordinate.
                    // The x-range of the rendering space then becomes [-1;1].
                    // This allows for easier further calculations.
                    double cameraX = 2 * x / (double)game.GetWinWidth() - 1;
                    // A unit vector, representing the direction of the
                    // currently cast ray. Calculated by the player direction
                    // plus part of the viewport "plane".
                    Vector2d rayDir = dir + (plane * cameraX);

                    // The player position in map-coordinates. Had we
                    // implemented integer vectors, this would be one of those.
                    Vector2d mapPos = pos.Floor();

                    // sideDist holds the initial length, needed to travel, for
                    // the ray to be on an x-intersection and a y-intersection.
                    Vector2d sideDist = new Vector2d(0, 0);
                    // The x-value holds the amount, y increases by, to go
                    // from one intersection of the grid in the y-axis, to
                    // another. In other words, the increase in Y, when X
                    // increases by one. The y-value is the opposite.
                    // The ternary operator is used to avoid division by zero,
                    // setting it to a really high number in that case.
                    Vector2d diffDist = new Vector2d(rayDir.x == 0 ? 100000000 : Math.Abs(1 / rayDir.x),
                                                     rayDir.y == 0 ? 100000000 : Math.Abs(1 / rayDir.y));
                    // The distance to the intersected cell, perpendicular to
                    // the camera plane.
                    double perpWallDist;

                    // Holds the direction to move in for x and y.
                    // X: -1 = left ; +1 = right
                    // Y: -1 = up   ; +1 = down
                    Vector2d step = new Vector2d(0, 0);

                    // Sets step variable and calculates sideDist for both x and y.
                    if(rayDir.x < 0) {
                        step.x = -1;
                        sideDist.x = (pos.x - mapPos.x) * diffDist.x;
                    } else {
                        step.x = 1;
                        sideDist.x = (mapPos.x + 1 - pos.x) * diffDist.x;
                    }

                    if(rayDir.y < 0) {
                        step.y = -1;
                        sideDist.y = (pos.y - mapPos.y) * diffDist.y;
                    } else {
                        step.y = 1;
                        sideDist.y = (mapPos.y + 1 - pos.y) * diffDist.y;
                    }

                    // Whether or not the ray hit a wall. Used to get out of a
                    // while loop.
                    bool hit = false;
                    // The cell-type / number of the hit wall.
                    int hitNum = 0;
                    // Whether it was hit in a y-intersection or an
                    // x-intersection.
                    int side = 0;
                    // This while loop runs, until a ray hits a cell.
                    while(!hit) {
                        // DDA essentially just casts two rays the same direction.
                        // On looking for x-intersections and one for
                        // y-intersections. We switch between the two, depending
                        // on which is currently shorter, then keep casting
                        // that, until the other is shorter.
                        // SideDist is now holding the full ray distance.
                        if(sideDist.x < sideDist.y) {
                            // Increment sideDist by the distance between
                            // intersections.
                            sideDist.x += diffDist.x;
                            // mapPos now holds the position of the intersected
                            // cell.
                            mapPos.x += step.x;
                            // Set side, since we know, if this ray hit, the
                            // side was 0.
                            side = 0;
                        } else {
                            // Increment sideDist by the distance between
                            // intersections.
                            sideDist.y += diffDist.y;
                            // mapPos now holds the position of the intersected
                            // cell.
                            mapPos.y += step.y;
                            // Set side, since we know, if this ray hit, the
                            // side was 0.
                            side = 1;
                        }

                        // Check if the currently intersected cell was not
                        // empty.
                        if(map.GetCell((int)mapPos.x, (int)mapPos.y) > 0) {
                            hit = true;
                            hitNum = map.GetCell((int)mapPos.x, (int)mapPos.y);
                        }

                    }

                    // Calculate the distance to the wall, depending on which
                    // intersection was made. This is because DDA essentially
                    // just casts two rays the same direction. On looking for
                    // x-intersections and one for y-intersections. We use the
                    // side variable to know which ray hit, calculating the
                    // distance it traveled.
                    if(side == 0)
                        perpWallDist = (sideDist.x - diffDist.x);
                    else
                        perpWallDist = (sideDist.y - diffDist.y);

                    // lineHeight stores the height needed to draw the ray in
                    // screen coordinates.
                    // It is calculated in a try-catch block, to catch a
                    // division by zero and in that case, make it a very large
                    // number.
                    int lineHeight;
                    try {
                        lineHeight = Convert.ToInt32(game.GetWinHeight() / perpWallDist);
                    } catch (Exception e) {
                        lineHeight = 1000;
                    }

                    // Get the ray color.
                    Color col = colors[hitNum];
                    // Actually draw the raycast line. Darken color depending on
                    // facing side, simulating lighting,
                    if(side == 0) {
                        // Construct darker color
                        col = Color.FromArgb(
                            (int)(col.R * 0.8),
                            (int)(col.G * 0.8),
                            (int)(col.B * 0.8));
                    }

                    // Darken color based on distance and visRange variable.
                    col = Color.FromArgb(
                        (int)(Math.Max(0, col.R - perpWallDist*visRange )),
                        (int)(Math.Max(0, col.G - perpWallDist*visRange )),
                        (int)(Math.Max(0, col.B - perpWallDist*visRange )));

                    // Draw the ray.
                    game.DrawVerLine(x, lineHeight, col);
                }

                // Handle movement
                double rotSpeed = 0.2;
                double movSpeed = 0.1;
                if (Console.KeyAvailable) {
                    // Reads and saves pressed key
                    ConsoleKeyInfo key = Console.ReadKey();
                    // Checks the pressed key. Sends press to menu.
                    if(key.Key == Player.up) {
                        // CellX and CellY holds the cell, the player would move
                        // into, in those directions. Using a vector doesn't
                        // make sense, since they could be different. They are
                        // split up, to allow sliding on walls, when not walking
                        // perpendicular into them.
                        int cellX = map.GetCell((int)(pos.x + dir.x * movSpeed), (int)(pos.y));
                        int cellY = map.GetCell((int)(pos.x), (int)(pos.y + dir.y * movSpeed));

                        // Check if cell is empty or a control cell, if so, move.
                        if(cellX == 0 || cellX >= 100) pos.x += dir.x * movSpeed;
                        if(cellY == 0 || cellY >= 100) pos.y += dir.y * 0.1;
                    } else if(key.Key == Player.down) {
                        // Same as before, just backwards, so with subtraction instead of addition.
                        int cellX = map.GetCell((int)(pos.x - dir.x * movSpeed), (int)(pos.y));
                        int cellY = map.GetCell((int)(pos.x), (int)(pos.y - dir.y * movSpeed));
                        if(cellX == 0 || cellX >= 100) pos.x -= dir.x * movSpeed;
                        if(cellY == 0 || cellY >= 100) pos.y -= dir.y * 0.1;
                    } else if(key.Key == Player.right) {
                        // Use too much math, to calculate the direction unit vector.
                        double oldDirX = dir.x;
                        dir.x = dir.x * Math.Cos(-rotSpeed) - dir.y * Math.Sin(-rotSpeed);
                        dir.y = oldDirX * Math.Sin(-rotSpeed) + dir.y * Math.Cos(-rotSpeed);
                        // Use too much math, to calculate the camera viewport plane.
                        double oldPlaneX = plane.x;
                        plane.x = plane.x * Math.Cos(-rotSpeed) - plane.y * Math.Sin(-rotSpeed);
                        plane.y = oldPlaneX * Math.Sin(-rotSpeed) + plane.y * Math.Cos(-rotSpeed);
                    } else if(key.Key == Player.left) {
                        // Use too much math, to calculate the direction unit vector.
                        double oldDirX = dir.x;
                        dir.x = dir.x * Math.Cos(rotSpeed) - dir.y * Math.Sin(rotSpeed);
                        dir.y = oldDirX * Math.Sin(rotSpeed) + dir.y * Math.Cos(rotSpeed);
                        // Use too much math, to calculate the camera viewport plane.
                        double oldPlaneX = plane.x;
                        plane.x = plane.x * Math.Cos(rotSpeed) - plane.y * Math.Sin(rotSpeed);
                        plane.y = oldPlaneX * Math.Sin(rotSpeed) + plane.y * Math.Cos(rotSpeed);
                    }
                }

                // Check for win/exit
                if(pos.Floor() == winC) {
                    // Winner!
                    return true;
                }
                if(pos.Floor() == extC) {
                    // Loser!
                    return false;
                }

                game.DrawBorder();
                game.SwapBuffers();
                game.DrawScreen();
            }
        }
    }
}
