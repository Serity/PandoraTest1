using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PandoraTest1.Tilesets;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PandoraTest1.Entities;

namespace PandoraTest1
{
    public class Map
    {
        public Color _defaultBGColor = Color.Magenta;
        public Tileset tileset;
        public int width;
        public int height;
        public int[,] bottomLayer;
        public int[,] middleLayer;
        public int[,] topLayer;
        public List<MapEntity> entities = new List<MapEntity>();
        public float mapScale = 3f;

        public Map(Tileset _tileset, int _width, int _height)
        {
            tileset = _tileset;
            width = _width;
            height = _height;
            bottomLayer = new int[width,height];
            middleLayer = new int[width,height];
            topLayer = new int[width,height];
            for (int ih = 0; ih < height; ih++)
            {
                for (int iw = 0; iw < width; iw++)
                {
                    bottomLayer[iw,ih] = -1; middleLayer[iw,ih] = -1; topLayer[iw,ih] = -1;
                }
            }
        }
        public void Update(GameTime gameTime)
        {
            foreach (MapEntity entity in entities)
            {
                entity.Update(gameTime);
            }
        }
        
        public void Draw(GameTime gameTime)
        {
            Main.spriteBatch.DrawRect(new Rectangle(0, 0, (int)(width * tileset.tileSize * mapScale), (int)(height * tileset.tileSize * mapScale)), _defaultBGColor);
            for (int ih = 0; ih < height; ih++)
            {
                for (int iw = 0; iw < width; iw++)
                {
                    int tilePos = iw + (ih * width);
                    DrawLayerTile(bottomLayer[iw, ih], iw, ih);
                    DrawLayerTile(middleLayer[iw, ih], iw, ih);
                }
            }
            foreach (MapEntity entity in entities) { entity.Draw(gameTime); }

            for (int ih = 0; ih < height; ih++)
            {
                for (int iw = 0; iw < width; iw++)
                {
                    DrawLayerTile(topLayer[iw, ih], iw, ih);
                }
            }
        }
        public void DrawEntityTile(GameTime gameTime)
        {
            //List<MapEntity> entitylist = entities.Where(v => (v.oldX == x || v.X == x) && (v.oldY == y || v.Y == y)).ToList();
            //if (entitylist.Count() == 0) { return; }
            foreach (MapEntity entity in entities) { entity.Draw(gameTime); }
        }
        public void DrawLayerTile(int tile, int x, int y)
        {
            if (tile == -1) { return; }
            Rectangle r = tileset.GetTileRect(tile);
            Main.spriteBatch.Draw(tileset.texture,
                new Vector2(x * tileset.tileSize * mapScale, y * tileset.tileSize * mapScale),
                r, Color.White, 0f, Vector2.Zero, mapScale, SpriteEffects.None, 0);
        }
        public bool IsTileSolid(int x, int y, int side)
        {
            foreach (int i in new int[] { bottomLayer[x,y], middleLayer[x,y], topLayer[x,y] })
            {
                if (i == -1) { continue; }
                TilesetTile t = tileset.GetTilesetTile(i);
                if (t == null) { continue; }
                TileSolidInfo tsi = t.solid;
                if (tsi == null) { continue; }
                if (tsi.Left && side == Directions.LEFT) { return true; }
                else if (tsi.Top && side == Directions.UP) { return true; }
                else if (tsi.Right && side == Directions.RIGHT) { return true; }
                else if (tsi.Bottom && side == Directions.DOWN) { return true; }
            }
            return false;
            

        }
    }
}
