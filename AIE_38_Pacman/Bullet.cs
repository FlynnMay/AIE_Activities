using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace AIE_38_Pacman
{
    class Bullet
    {
        GameLevelScreen level;
        public float speed = 10;
        public Vector2 pos = new Vector2();
        public Vector2 dir = new Vector2();

        public bool isAlive = true;

        public Bullet(Vector2 pos, Vector2 dir, GameLevelScreen level)
        {
            this.pos = pos;
            this.dir = dir;
            this.level = level;
        }
        Vector2 GetCurrentTilePos()
        {
            int row = level.GetYPosToRow(pos.Y);
            int col = level.GetXPosToCol(pos.X);
            var rect = level.GetTileRect(row, col);
            return new Vector2(rect.x + rect.width / 2, rect.y + rect.height / 2);
        }
        Vector2 GetNextTilePos()
        {
            int row = level.GetYPosToRow(pos.Y) + (int)dir.Y;
            int col = level.GetXPosToCol(pos.X) + (int)dir.X;
            var rect = level.GetTileRect(row, col);
            return new Vector2(rect.x + rect.width / 2, rect.y + rect.height / 2);
        }
        public void Update()
        {
            if (level.GetTileValue(GetCurrentTilePos()) == TileType.Wall)
            {
                isAlive = false;
            }
            pos += dir * speed;
        }
        public void Draw()
        {
            //Raylib.DrawLine((int)pos.X, (int)pos.Y, (int)(pos.X - dir.X * speed), (int)(pos.Y - dir.Y * speed), Color.WHITE);
            float pacDotSize = 0.3f;
            Raylib.DrawTextureEx(Assets.pacDot, pos, 0, pacDotSize, Color.WHITE);
        }
    }
}
