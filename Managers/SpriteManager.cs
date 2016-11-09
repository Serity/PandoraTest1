using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PandoraTest1.Graphics;
using Microsoft.Xna.Framework;

namespace PandoraTest1.Managers
{
    public class SpriteManager
    {
        public static List<Spritesheet> sheets = new List<Spritesheet>();
        public static List<Sprite> sprites = new List<Sprite>();
        // sprite name, 
        static SpriteManager()
        {
            AddNewSheet(Sheets.UI_Blue);
            AddNewSheet(Sheets.UI_Green);
            AddNewSheet(Sheets.UI_Grey);
            AddNewSheet(Sheets.UI_Red);
            AddNewSheet(Sheets.UI_Yellow);


            AddNewSheet(Sheets.Lorc);
            AddNewSheet(Sheets.GIN_BT);
            AddNewSheet(Sheets.GIN_WT);
            AddNewSheet(Sheets.GIN3_WT);
            AddNewSheet(Sheets.GIN6_WT);
        }
        private static void AddNewSheet(string sheet)
        {
            Spritesheet ss = new Spritesheet(sheet);
            sheets.Add(ss);
            foreach (Sprite s in ss.sprites) { sprites.Add(s); }
        }
        private static void AddNewSheet(Sheets s) { AddNewSheet(s.Value); }

        public static Spritesheet GetSheet(Sheets sheet) { return sheets.FirstOrDefault(s => s.name.Equals(sheet.Value)); }


        public static Sprite GetSprite(Sheets sheet, string spriteName)
        {
            Spritesheet q = GetSheet(sheet);
            return GetSprite(q, spriteName);
        }
        public static Sprite GetSprite(string spriteName)
        {
            return GetSpriteFromList(sprites, spriteName);
        }
        public static Sprite GetSprite(Spritesheet sheet, string spriteName)
        {
            return GetSpriteFromList(sheet.sprites, spriteName);
        }
        private static Sprite GetSpriteFromList(List<Sprite> sprites, string spriteName)
        {
            return sprites.Find(s => s.name.Equals(spriteName) || s.name.Equals(spriteName + ".png"));
        }
    }
}