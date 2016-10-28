using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraTest1
{
    public class TileSolidInfo
    {
        public bool All
        {
            set
            {
                Left = value; Right = value; Top = value; Bottom = value;
            }
        }
        public bool Left;
        public bool Right;
        public bool Top;
        public bool Bottom;
    }
    public class TilesetTile
    {
        public int tileId; // matches a tile enum in the tileset
        public TileSolidInfo solid = new TileSolidInfo();
        public TilesetTile(int _tileId, bool _solid = false)
        {
            tileId = _tileId;
            if (_solid) { solid.All = true; }
        }
    }
}
