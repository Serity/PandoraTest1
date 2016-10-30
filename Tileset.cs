using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraTest1
{
    public class Tileset
    {
        //private bool _initialized = false;

        public string name;
        public Texture2D texture;
        public string texturePath;
        public int tileSize;
        public int tilesWide { get { return texture.Width / tileSize; } }
        public int tilesHigh {  get { return texture.Height / tileSize; } }

        public List<TilesetTile> tiles = new List<TilesetTile>();
        public void Initialize(Texture2D _texture)
        {
            texture = _texture;

            for (int ih = 0; ih < tilesHigh; ih++)
            {
                for (int iw = 0; iw < tilesWide; iw++)
                {
                    int tilePos = iw + (ih * tilesWide);
                    TilesetTile t = new TilesetTile(tilePos);
                    tiles.Add(t);
                }
            }
        }
        public TilesetTile GetTilesetTile(int tileId)
        {
            return tiles.FirstOrDefault(t => t.tileId == tileId);
        }
        public Rectangle GetTileRect(int tileId)
        {
            int x = (tileId % tilesWide);
            int y = (tileId / tilesWide);
            // tileID 15 - 6 tiles wide / 012345 678901 234567 - row 3 tile 4 / row 2 tile 3
            // 15 % 6 is 3, 15 / 6 is 2... truncated to 2
            return new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize);
        }
    }
}
