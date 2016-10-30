using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PandoraTest1.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraTest1.Entities
{
    public class MapEntity
    {
        public string id;
        public float _movementDistance;
        public bool _moving;
        public bool _movingOnX;
        public int _facingDirection;
        public Texture2D texture = Main.texturePlayer;
        public int oldX;
        public int oldY;
        public int X;
        public int Y;
        public bool ephemeral = false; // walk through walls

        public Action<MapEntity> InteractAction;

        public void Draw(GameTime gameTime)
        {
            float scale = MainMenu.town.mapScale;// * (16.0f/64.0f);
            int tileSize = MainMenu.town.tileset.tileSize;
            float x;
            float y;
            if (_moving)
            {
                // todo: mult by current map tileset tilesize not hardcode 16
                x = oldX;
                y = oldY;
                if (_movingOnX) { x += _movementDistance; }
                else { y += _movementDistance; }
            }
            else
            {
                x = X;
                y = Y;
            }
            x *= tileSize * scale;
            y *= tileSize * scale;
            Main.spriteBatch.DrawBox(new Rectangle((int)x, (int)y, (int)(64.0f * scale * (16.0f / 64.0f)), (int)(64.0f * scale * (16.0f / 64.0f))), Color.White);
            Main.spriteBatch.Draw(texture, new Vector2(x, y), new Rectangle(256, Main.v, 64, 64), Color.White, 0, Vector2.Zero, scale * (16.0f / 64.0f), SpriteEffects.None, 0);
        }
        public void Update(GameTime gameTime)
        {
            if (_moving)
            {
                float velocity = 0;
                if (oldX != X)
                {
                    velocity = X - oldX;
                    _movingOnX = true;
                }
                else if (oldY != Y)
                {
                    velocity = Y - oldY;
                    _movingOnX = false;
                }
                _movementDistance += 5 * (float)(velocity * gameTime.ElapsedGameTime.TotalSeconds);
                if (Math.Abs(_movementDistance) >= Math.Abs(velocity))
                {
                    _moving = false;
                }
            }
        }
        public void MoveUp() { MoveTo(X, Y - 1); }
        public void MoveDown() { MoveTo(X, Y + 1); }
        public void MoveLeft() { MoveTo(X - 1, Y); }
        public void MoveRight() { MoveTo(X + 1, Y); }
        public void MoveTo(int x, int y)
        {
            if (_moving) { return; }

            if (x < X) { _facingDirection = Directions.LEFT; }
            else if (x > X) { _facingDirection = Directions.RIGHT; }
            else if (y < Y) { _facingDirection = Directions.UP; }
            else if (y > Y) { _facingDirection = Directions.DOWN; }

            if (!ephemeral)
            {
                // can't go out of bounds
                if (x < 0 || y < 0) { return; }
                if (x >= MainMenu.town.width || y >= MainMenu.town.height) { return; }
                
                // can't walk through walls
                if (MainMenu.town.IsTileSolid(x, y, Directions.DirectionToTileSide(_facingDirection))) { return; }
                if (MainMenu.town.IsTileSolid(X, Y, _facingDirection)) { return; }

                // can't walk into other entities that aren't ephemeral
                MapEntity t = GetFacingEntity();
                if (t != null && !t.ephemeral) { return; }
            }
            oldX = X;
            oldY = Y;
            _movementDistance = 0;
            _moving = true;
            X = x;
            Y = y;
        }
        public Vector2 GetFacingCoords()
        {
            if (_facingDirection == Directions.LEFT) { return new Vector2(X - 1, Y); }
            else if (_facingDirection == Directions.RIGHT) { return new Vector2(X + 1, Y); }
            else if (_facingDirection == Directions.UP) { return new Vector2(X, Y-1); }
            else if (_facingDirection == Directions.DOWN) { return new Vector2(X,Y+1); }
            return new Vector2(X, Y);
        }
        public MapEntity GetFacingEntity()
        {
            Vector2 coords = GetFacingCoords();
            MapEntity target = MainMenu.town.entities.FirstOrDefault(v => v.X == coords.X && v.Y == coords.Y);
            return target;
        }
        public bool Interact(MapEntity user)
        {
            if (InteractAction != null) { InteractAction(user); }
            return true;
        }
        public void TryInteract()
        {
            MapEntity target = GetFacingEntity();
            if (target == null) { return; }
            target.Interact(this);
        }
    }
}
