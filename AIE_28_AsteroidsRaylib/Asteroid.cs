using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Raylib_cs;

namespace AIE_28_AsteroidsRaylib
{
    class Asteroid
    {
        Program program;
        public Vector2 pos = new Vector2();
        public Vector2 dir = new Vector2();
        public float radius = 40.0f;

        public Asteroid(Program program, Vector2 pos, Vector2 dir)
        {
            this.program = program;
            this.pos = pos;
            this.dir = dir;
        }
        public void Update()
        {
            // wrap asteroid around screen
            if (pos.X > program.windowWidth) pos.X = 0;
            if (pos.X < 0) pos.X = program.windowWidth;
            if (pos.Y > program.windowHeight) pos.Y = 0;
            if (pos.Y < 0) pos.Y = program.windowHeight;

            pos += dir;
        }
        public void Draw()
        {
            Raylib.DrawCircleLines((int)pos.X, (int)pos.Y, radius, Color.WHITE);
        }
    }
}
