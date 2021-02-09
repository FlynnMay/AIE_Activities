using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace AIE_28_AsteroidsRaylib
{
    class Bullet
    {
        Program program;
        public Vector2 pos = new Vector2();
        public Vector2 dir = new Vector2();
        public float speed = 10;

        public bool isAlive = true;

        public Bullet(Program program, Vector2 pos, Vector2 dir)
        {
            this.program = program;
            this.pos = pos;
            this.dir = dir;
        }
        public void Update()
        {
            // wrap player around screen
            if (pos.X > program.windowWidth) pos.X = 0;
            if (pos.X < 0) pos.X = program.windowWidth;
            if (pos.Y > program.windowHeight) pos.Y = 0;
            if (pos.Y < 0) pos.Y = program.windowHeight;

            pos += dir * speed;
        }
        public void Draw()
        {
            Raylib.DrawLine((int)pos.X, (int)pos.Y, (int)(pos.X - dir.X * speed), (int)(pos.Y - dir.Y * speed), Color.WHITE);
        }
    }
}
