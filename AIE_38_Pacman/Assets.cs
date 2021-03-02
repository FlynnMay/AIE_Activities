using Raylib_cs;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AIE_38_Pacman
{
    class Assets
    {
        public static Dictionary<int, Texture2D> walls = new Dictionary<int, Texture2D>();
        public static Texture2D pacDot;
        public static Texture2D pacOpen;
        public static Texture2D pacClosed;
        public static void LoadAssets()
        {
            pacDot = Raylib.LoadTexture("./assets/pellet.png");
            pacOpen = Raylib.LoadTexture("./assets/PacOpen.png");
            pacClosed = Raylib.LoadTexture("./assets/PacClosed.png");
            string wallsDir = "./assets/wall pieces";
            foreach (var wall in Directory.GetFiles(wallsDir))
            {
                string tmp = wall;
                Regex rgx = new Regex("[^0-9]");
                tmp = rgx.Replace(tmp, "");
                walls.Add(int.Parse(tmp), Raylib.LoadTexture(wall));
            }

        }
    }
}
