using Raylib_cs;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AIE_38_Pacman
{
    class Assets
    {
        public static Dictionary<int, Texture2D> walls = new Dictionary<int, Texture2D>();
        public static void LoadAssets()
        {
            string dirFile = "./assets/";
            foreach (var wall in Directory.GetFiles(dirFile))
            {
                string tmp = wall;
                Regex rgx = new Regex("[^0-9]");
                tmp = rgx.Replace(tmp, "");
                walls.Add(int.Parse(tmp), Raylib.LoadTexture(wall));
            }

        }
    }
}
