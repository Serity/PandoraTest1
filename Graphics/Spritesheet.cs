using Microsoft.Xna.Framework.Graphics;
using System.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PandoraTest1.Graphics
{
    public class Spritesheet
    {
        public string name;
        public Texture2D sheetTexture;
        public List<Sprite> sprites = new List<Sprite>();
        public bool loaded = false;

        public Spritesheet(String sheetFilename)
        {
            name = sheetFilename;
            string xmlPath = "Content/UI/" + sheetFilename + ".xml";
            
            XmlReader xmlFile = XmlReader.Create(xmlPath);

            while (xmlFile.Read())
            {
                // Kenney Format
                if (xmlFile.NodeType == XmlNodeType.Element && xmlFile.Name.Equals("SubTexture")) { KenneyProcessor(xmlFile); }
                else if (xmlFile.NodeType == XmlNodeType.Element && xmlFile.Name.Equals("sprite")) { TexturePackerProcessor(xmlFile); }
            }
            Load();
        }
        public void Load()
        {
            string path = "UI/" + name;
            sheetTexture = Main.LoadTexture(path);
        }
        public void Unload()
        {
            sheetTexture = null;
        }
        public Sprite GetSprite(string spriteName) {
            return sprites.Find(r => r.name.Equals(spriteName));
        }
        private void KenneyProcessor(XmlReader xmlFile)
        {
            string name = xmlFile.GetAttribute("name");
            Rectangle r = new Rectangle(RetrieveInt(xmlFile, "x"), RetrieveInt(xmlFile, "y"), RetrieveInt(xmlFile, "width"), RetrieveInt(xmlFile, "height"));
            Sprite s = new Sprite(this, name, r);
            sprites.Add(s);
        }
        private void TexturePackerProcessor(XmlReader xmlFile)
        {
            string name = xmlFile.GetAttribute("n");
            Rectangle r = new Rectangle(RetrieveInt(xmlFile,"x"), RetrieveInt(xmlFile, "y"), RetrieveInt(xmlFile, "w"), RetrieveInt(xmlFile, "h"));
            Sprite s = new Sprite(this, name, r);
            sprites.Add(s);
        }
        private int RetrieveInt(XmlReader xmlFile, string attribute)
        {
            string s = xmlFile.GetAttribute(attribute);
            int i;
            Int32.TryParse(s, out i);
            return i;
        }
    }
}
