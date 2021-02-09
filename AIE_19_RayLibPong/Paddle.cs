using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AIE_19_RayLibPong
{
    class Paddle
    {
        public Vector2 pos = new Vector2();
        public Vector2 size = new Vector2(10, 100);
        public float speed = 5.0f;
        public int score = 0;
        public string name = "";
        public KeyboardKey upKey;
        public KeyboardKey downKey;

        public static int scoreMax = 3;
        public Vector2 scorePos = new Vector2();
        public float scoreSize = 10f;

        //public Paddle()
        //{

        //}
    }
}
