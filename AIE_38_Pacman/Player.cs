﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace AIE_38_Pacman
{
    class Player
    {
        GameLevelScreen level;
        Vector2 spawnPos = new Vector2();
        Vector2 pos = new Vector2();
        Vector2 dir = new Vector2(1, 0);

        float maxSpeed = 4;
        float speed = 4;
        float lerpTime = 0;
        Vector2 starTilePos;
        Vector2 endTilePos;
        public Player(Vector2 pos, GameLevelScreen level)
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
            int currentTile = level.GetTileId(pos);

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT)) dir = new Vector2(-1, 0);
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT)) dir = new Vector2(1, 0);
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP)) dir = new Vector2(0, -1);
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN)) dir = new Vector2(0, 1);

            lerpTime += Raylib.GetFrameTime() * speed;
            if (lerpTime > 1 || speed <= 0.0f)
            {
                lerpTime = 0;
                starTilePos = GetCurrentTilePos();
                endTilePos = GetNextTilePos();

                var endTileVal = level.GetTileValue(endTilePos);

                speed = maxSpeed;
                if (endTileVal == TileType.Wall)
                {
                    speed = 0.0f;
                }
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
            Raylib.DrawCircle((int)pos.X, (int)pos.Y, 12, Color.YELLOW);
            DebugDraw();
        }
        public void DebugDraw()
        {
            int row = level.GetYPosToRow(pos.Y);
            int col = level.GetXPosToCol(pos.X);
            var rect = level.GetTileRect(row, col);
            Raylib.DrawRectangleLinesEx(rect, 1, Color.YELLOW);

            Raylib.DrawCircle((int)starTilePos.X, (int)starTilePos.Y, 3, Color.RED);
            Raylib.DrawCircle((int)endTilePos.X, (int)endTilePos.Y, 3, Color.RED);
            Raylib.DrawLineEx(starTilePos, endTilePos, 1, Color.RED);
            Raylib.DrawCircle((int)pos.X, (int)pos.Y, 2, Color.BLACK);
        }
        void OnTileEnter(int tileId)
        {
            var tileVal = level.GetTileValue(pos);
            if (tileVal == TileType.Dot)
            {
                level.EatPacDot(pos);
            }
        }
        public void OnCollision(Ghost ghost)
        {
            pos = spawnPos;
            dir = new Vector2(1, 0);
            starTilePos = GetCurrentTilePos();
            endTilePos = GetNextTilePos();
            lerpTime = 0;
        }
    }
}
