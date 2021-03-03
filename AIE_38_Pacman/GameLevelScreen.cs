using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace AIE_38_Pacman
{
    enum TileType
    {
        Out_Of_Bounds = -1,
        Empty, // 0
        Wall, // 1
        Dot, // 2
        Player_Start, // 3
        Ghost_Spawn // 4
    }
    class GameLevelScreen : IGameState
    {
        TileType[,] map;

        int numPacDots = 0;

        float tileWidth = 32;
        float tileHeight = 32;
        float mapXPos = 10;
        float mapYPos = 40;

        int score = 0;
        int lives = 3;

        Player player;
        List<Ghost> ghosts = new List<Ghost>();
        List<Bullet> bullets = new List<Bullet>();
        public GameLevelScreen(Program program) : base(program)
        {
            LoadLevel();
        }
        int[,] tilemap = new int[,]
        {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,1},
            {1,0,1,1,1,0,1,1,0,0,0,0,0,0,0,0,1,1,0,1,1,1,0,1},
            {1,0,1,0,0,0,0,1,1,1,1,0,0,1,1,1,1,0,0,0,0,1,0,1},
            {1,0,1,0,1,1,0,1,0,0,0,0,0,0,0,0,1,0,1,1,0,1,0,1},
            {1,0,1,0,1,1,0,1,0,1,1,0,0,1,1,0,1,0,1,1,0,1,0,1},
            {1,0,1,0,1,1,0,1,0,1,1,0,0,1,1,0,1,0,1,1,0,1,0,1},
            {1,0,1,0,1,1,0,1,0,0,0,0,0,0,0,0,1,0,1,1,0,1,0,1},
            {1,0,1,0,0,0,0,1,1,1,1,0,0,1,1,1,1,0,0,0,0,1,0,1},
            {1,0,1,1,0,1,1,1,0,0,0,0,0,0,0,0,1,1,1,0,1,1,0,1},
            {1,0,4,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,4,0,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        };
        void LoadLevel()
        {
            map = new TileType[tilemap.GetLength(0), tilemap.GetLength(1)];
            for (int row = 0; row < tilemap.GetLength(0); row++)
                for (int col = 0; col < tilemap.GetLength(1); col++)
                    map[row, col] = (TileType)tilemap[row, col];

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    var tileVal = GetTileValue(row, col);
                    if (tileVal == TileType.Empty) SetTileValue(row, col, TileType.Dot);
                    if (tileVal == TileType.Player_Start) CreatePlayer(row, col);
                    if (tileVal == TileType.Ghost_Spawn) CreateGhost(row, col);
                }
            }
        }
        Texture2D DecideWallShape(int row, int col)
        {
            int wallId = 0;
            if (GetTileValue(row - 1, col) == TileType.Wall) wallId += 1;
            if (GetTileValue(row, col + 1) == TileType.Wall) wallId += 2;
            if (GetTileValue(row + 1, col) == TileType.Wall) wallId += 4;
            if (GetTileValue(row, col - 1) == TileType.Wall) wallId += 8;
            return Assets.walls[wallId];
        }
        public void CreateGhost(int row, int col)
        {
            var rect = GetTileRect(row, col);
            var pos = new Vector2(rect.x + rect.width / 2, rect.y + rect.height / 2);
            Ghost ghost = new Ghost(pos, this);
            ghosts.Add(ghost);
            SetTileValue(row, col, TileType.Empty);
        }
        public void CreatePlayer(int row, int col)
        {
            var rect = GetTileRect(row, col);
            var pos = new Vector2(rect.x + rect.width / 2, rect.y + rect.height / 2);
            player = new Player(pos, this);
            SetTileValue(row, col, TileType.Empty);
        }

        public void CreateBullet(Vector2 dir, Vector2 pos)
        {
            Vector2 bulletPos = new Vector2(pos.X - tileWidth / 2, pos.Y - tileHeight / 2);
            Bullet bullet = new Bullet(bulletPos, dir, this);
            bullets.Add(bullet);
        }

        public Player GetPlayer()
        {
            return player;
        }
        public int GetTileId(int row, int col)
        {
            return row * map.GetLength(1) + col;
        }
        public int GetTileId(Vector2 pos)
        {
            int row = GetYPosToRow(pos.Y);
            int col = GetXPosToCol(pos.X);
            return GetTileId(row, col);
        }
        public TileType GetTileValue(int row, int col)
        {
            if (row < 0 || col < 0 || row >= map.GetLength(0) || col >= map.GetLength(1))
                return TileType.Out_Of_Bounds;
            return map[row, col];
        }
        public TileType GetTileValue(Vector2 pos)
        {
            int row = GetYPosToRow(pos.Y);
            int col = GetXPosToCol(pos.X);
            return GetTileValue(row, col);
        }
        public void SetTileValue(int row, int col, TileType value)
        {
            if (value == TileType.Dot && map[row, col] != TileType.Dot)
            {
                numPacDots += 1;
            }
            else if (map[row, col] == TileType.Dot && value != TileType.Dot)
            {
                numPacDots -= 1;
            }
            map[row, col] = value;
        }
        public void SetTileValue(Vector2 pos, TileType value)
        {
            int row = GetYPosToRow(pos.Y);
            int col = GetXPosToCol(pos.X);
            SetTileValue(row, col, value);
        }
        public Color GetTileColor(int row, int col)
        {
            TileType tileValue = GetTileValue(row, col);
            if (tileValue == TileType.Empty) return Color.BLACK;
            if (tileValue == TileType.Wall) return Color.BLUE;
            if (tileValue == TileType.Dot) return Color.BLACK;
            return Color.PINK;
        }
        public Rectangle GetTileRect(int row, int col)
        {
            float xPos = mapXPos + (col * tileWidth);
            float yPos = mapYPos + (row * tileHeight);
            return new Rectangle(xPos, yPos, tileWidth, tileHeight);
        }
        public Rectangle GetTileRect(Vector2 pos)
        {
            int row = GetYPosToRow(pos.Y);
            int col = GetXPosToCol(pos.X);

            return GetTileRect(row, col);
        }
        public int GetYPosToRow(float yPos)
        {
            return (int)((yPos - mapYPos) / tileHeight);
        }
        public int GetXPosToCol(float xPos)
        {
            return (int)((xPos - mapXPos) / tileWidth);
        }

        public override void Update()
        {
            if (player != null)
                player.Update();
            foreach (var ghost in ghosts)
            {
                ghost.Update();
            }
            foreach (var bullet in bullets)
            {
                bullet.Update();
            }
            HandlePlayerGhostCollisions();
            HandleBulletGhostCollisions();

            List<Bullet> bulletsToRemove = new List<Bullet>();
            List<Ghost> ghostsToRemove = new List<Ghost>();

            // update all bullets
            foreach (var bullet in bullets)
            {
                if (bullet.isAlive)
                {
                    bullet.Update();
                }
                else
                {
                    bulletsToRemove.Add(bullet);
                }
            }

            // remove all dead bullets
            foreach (var b in bulletsToRemove)
                bullets.Remove(b);
            
            // update all bullets
            foreach (var ghost in ghosts)
            {
                if (ghost.isAlive)
                {
                    ghost.Update();
                }
                else
                {
                    ghostsToRemove.Add(ghost);
                }
            }

            // remove all dead bullets
            foreach (var g in ghostsToRemove)
            {
                ghosts.Remove(g);
                score += 100;
            }

            if (ghosts.Count <= 0) LoadLevel();
        }
        public override void Draw()
        {
            //Raylib.DrawText("PacMan", 10, 10, 20, Color.WHITE);
            DrawMap();
            player.Draw();
            DrawUI();

            foreach (var ghost in ghosts)
            {
                ghost.Draw();
            }

            foreach (var bullet in bullets)
            {
                bullet.Draw();
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_CONTROL))
            {
                DebugDraw();
            }
        }

        void DrawMap()
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    var tileVal = GetTileValue(row, col);
                    Rectangle rect = GetTileRect(row, col);
                    Color color = GetTileColor(row, col);
                    if (tileVal == TileType.Wall)
                    {
                        Vector2 pos = new Vector2(rect.x, rect.y);
                        Texture2D wallShape = DecideWallShape(row, col);
                        Raylib.DrawTextureEx(wallShape, pos, 0.0f, 0.3f, Color.BLUE); ;
                    }
                    else
                    {
                        Raylib.DrawRectangleRec(rect, color);
                    }
                    if (tileVal == TileType.Dot)
                    {
                        Vector2 pos = new Vector2(rect.x, rect.y);
                        float pacDotSize = 0.3f;
                        Raylib.DrawTextureEx(Assets.pacDot, pos, 0, pacDotSize, Color.WHITE);
                    }
                }
            }
        }
        void DrawUI()
        {
            Raylib.DrawText($"Score: {score}", 30, 10, 20, Color.WHITE);
            Raylib.DrawText($"Lives: {lives}", 210, 10, 20, Color.WHITE);
        }

        void DebugDraw()
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    var rect = GetTileRect(row, col);
                    var color = new Color(255, 255, 255, 128);

                    Raylib.DrawRectangleRec(rect, color);
                    Raylib.DrawRectangleLinesEx(rect, 1, Color.WHITE);

                    var tileId = GetTileId(row, col);
                    int tileVal = (int)GetTileValue(row, col);

                    Raylib.DrawText(tileId.ToString(), (int)(rect.x + 2), (int)(rect.y + 2), 10, Color.BLACK);
                    Raylib.DrawText(tileVal.ToString(), (int)(rect.x + 2), (int)(rect.y + rect.height - 14), 10, Color.BLACK);

                }
            }
        }
        public void EatPacDot(int row, int col)
        {
            SetTileValue(row, col, TileType.Empty);
            //score += 10;
            if (numPacDots <= 0) LoadLevel();
        }
        public void EatPacDot(Vector2 pos)
        {
            int row = GetYPosToRow(pos.Y);
            int col = GetXPosToCol(pos.X);
            EatPacDot(row, col);
        }

        void HandlePlayerGhostCollisions()
        {
            foreach (var ghost in ghosts)
            {
                var ghostTileId = GetTileId(ghost.GetPosition());
                var playerTileId = GetTileId(player.GetPosition());

                if (ghostTileId == playerTileId)
                {
                    player.OnCollision(ghost);
                    ghost.OnCollision(player);
                    lives -= 1;
                }
            }
        }

        void HandleBulletGhostCollisions()
        {
            foreach (var ghost in ghosts)
            {
                foreach (var bullet in bullets)
                {
                    int bulletCol = GetXPosToCol(bullet.pos.X);
                    int bulletRow = GetYPosToRow(bullet.pos.Y);
                    int ghostCol = GetXPosToCol(ghost.GetPosition().X);
                    int ghostRow = GetYPosToRow(ghost.GetPosition().Y);

                    if (bulletCol == ghostCol && bulletRow == ghostRow )
                    {
                        bullet.isAlive = false;
                        ghost.isAlive = false;
                    }
                }
                var ghostTileId = GetTileId(ghost.GetPosition());
                var playerTileId = GetTileId(player.GetPosition());

                if (ghostTileId == playerTileId)
                {
                    player.OnCollision(ghost);
                    ghost.OnCollision(player);
                    lives -= 1;
                }
            }
        }
    }
}
