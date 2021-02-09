using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_28_AsteroidsRaylib
{
    class Assets
    {
        public static Texture2D shipTexture;

        public static void LoadAssets()
        {
            shipTexture = Raylib.LoadTexture("./assets/ship.png");
        }
    }
}
