using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace AIE_27_Classes
{
    class Sprite
    {
        public Vector2 position = new Vector2();
        public float size;
        public float rotation;
        public Texture2D texture = Raylib.LoadTexture("./assets/sprite.png");

        public Sprite(Vector2 position, float size, float rotation)
        {
            this.position = position;
            this.size = size;
            this.rotation = rotation;
        }
        public void Draw()
        {

        }

        public void Move()
        {

        }
    }
}
