using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraTest1.Tilesets
{
    public class Town16Test : Tileset
    {
        public enum Tiles
        {
            Roof_Top_Left, Roof_Top_Middle_Left, Roof_Left_Edge,
            Roof_Front_Left, Roof_Front_Middle_Left, Roof_Front_Middle_Right,
            Roof_Front_Right, Roof_Right_Edge, Roof_Top_Middle_Right, Roof_Top_Right,
            Grass1, Dirt, Dirt_Vert, Wood_Top, Battlements_Left, Battlements_Mid, Battlements_Right,
            Tower_Top_Back_Left, Tower_Top_Back_Middle, Tower_Top_Back_Right,
            Grass2,
            Dirt_Horiz = 22, Wood_Middle, Barrel, Stone_Doorway_Top, Chest, 
            Tower_Top_Front_Left, Tower_Top_Front_Middle, Tower_Top_Front_Right,
            Wood_Bottom = 33, Bubbles, Tree_Top, Well_Top, Tower_Upper_Left,
            Tower_Window_Top, Tower_Upper_Right,
            Hanging_Gate = 43, Puddle, Tree_Bottom, Well_Bottom, Tower_Bottom_Left,
            Tower_Window_Bottom, Tower_Bottom_Right
        }
        public Town16Test()
        {
            name = "Town16";
            texturePath = "Tilesets/16x16Town";
            tileSize = 16;
        }
        /*public List<Tiles> GetSolidTiles()
        {
            //Tiles[] list = new Tiles[] { Tiles.Barrel, Tiles.Well_Bottom, Tiles.Tow}
        }*/
    }
}
