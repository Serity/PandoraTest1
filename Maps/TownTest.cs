using PandoraTest1.Tilesets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraTest1.Maps
{
    public class TownTest : Map
    {
        public TownTest() : base(Main.tilesets.FirstOrDefault(t => t.name.Equals("Town16")), 4, 4)
        {
            for (int i = 0; i < bottomLayer.Length; i++)
            {
                int x = i % width;
                int y = i / width;
                bottomLayer[x, y] = (int)Town16Test.Tiles.Dirt;
            }
            bottomLayer[3, 3] = -1;
            middleLayer[1, 1] = (int)Town16Test.Tiles.Barrel;
            tileset.GetTilesetTile((int)Town16Test.Tiles.Barrel).solid.All = true;
            tileset.GetTilesetTile((int)Town16Test.Tiles.Barrel).solid.Left = false;

            topLayer[1, 1] = (int)Town16Test.Tiles.Tree_Top;
            topLayer[1, 2] = (int)Town16Test.Tiles.Tree_Bottom;
            tileset.GetTilesetTile((int)Town16Test.Tiles.Tree_Bottom).solid.Bottom = true;
        }
    }
}
