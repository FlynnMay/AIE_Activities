using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace AIE_38_Pacman
{
    class Ghost
    {
        GameLevelScreen level;
        Vector2 spawnPos = new Vector2();
        Vector2 pos = new Vector2();
        Vector2 dir = new Vector2(1, 0);

        float maxSpeed = 1;
        float speed = 10;
        float lerpTime = 0;
        Vector2 starTilePos;
        Vector2 endTilePos;
        Random random = new Random();

        public Ghost(Vector2 pos, GameLevelScreen level)
        {
            this.level = level;
            this.pos = pos;
            this.spawnPos = pos;

            starTilePos = GetCurrentTilePos();
            endTilePos = GetNextTilePos();
        }

        public Vector2 GetPosition()
        {
            return pos;
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
            //speed = Raylib.GetFPS();
            int currentTile = level.GetTileId(pos);

            lerpTime += Raylib.GetFrameTime() * speed;
            if (lerpTime > 1 || speed <= 0.0f)
            {
                int row = level.GetYPosToRow(pos.Y);
                int col = level.GetXPosToCol(pos.X);
                List<Vector2> availableDirections = new List<Vector2>();
                if (level.GetTileValue(row, col - 1) != TileType.Wall) availableDirections.Add(new Vector2(-1, 0));
                if (level.GetTileValue(row, col + 1) != TileType.Wall) availableDirections.Add(new Vector2(1, 0));
                if (level.GetTileValue(row - 1, col) != TileType.Wall) availableDirections.Add(new Vector2(0, -1));
                if (level.GetTileValue(row + 1, col) != TileType.Wall) availableDirections.Add(new Vector2(0, 1));

                int index = random.Next(0, availableDirections.Count);

                dir = availableDirections[index];
                lerpTime = 0;
                starTilePos = GetCurrentTilePos();
                endTilePos = GetNextTilePos();

                var endTileVal = level.GetTileValue(endTilePos);

                //speed = maxSpeed;
                //if (endTileVal == TileType.Wall)
                //{
                //    speed = 0.0f;
                //}
            }
            pos = Vector2.Lerp(starTilePos, endTilePos, lerpTime);

            int newCurrentTile = level.GetTileId(pos);
            if (currentTile != newCurrentTile)
            {
                OnTileEnter(newCurrentTile);
            }
        }

        public void Draw()
        {
            var newPos = new Vector2(pos.X - 25, pos.Y - 25);
            Raylib.DrawTextureEx(Assets.ghost, newPos, 0.0f, 0.5f, Color.RED);
            //Raylib.DrawRectangleRec(new Rectangle(pos.X - 8, pos.Y - 8, 16, 16), Color.ORANGE);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_ALT)) DebugDraw();
        }
        public void DebugDraw()
        {
            int row = level.GetYPosToRow(pos.Y);
            int col = level.GetXPosToCol(pos.X);
            var rect = level.GetTileRect(row, col);
            Raylib.DrawRectangleLinesEx(rect, 1, Color.YELLOW);

            if (level.GetPlayer() != null) Raylib.DrawLineEx(pos, level.GetPlayer().GetPosition(), 1, Color.BLUE);

            Raylib.DrawCircle((int)starTilePos.X, (int)starTilePos.Y, 3, Color.RED);
            Raylib.DrawCircle((int)endTilePos.X, (int)endTilePos.Y, 3, Color.RED);
            Raylib.DrawLineEx(starTilePos, endTilePos, 1, Color.RED);
            Raylib.DrawCircle((int)pos.X, (int)pos.Y, 2, Color.BLACK);
        }
        void OnTileEnter(int tileId)
        {

        }
        public void OnCollision(Player player)
        {
            pos = spawnPos;
            dir = new Vector2(1, 0);
            starTilePos = GetCurrentTilePos();
            endTilePos = GetNextTilePos();
            lerpTime = 0;
        }
    }
}
