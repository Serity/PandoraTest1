using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraTest1.Graphics
{
    public class Sprite
    {
        public Spritesheet parentSheet;
        public string name;
        public Rectangle rectInSheet;

        public Sprite(Spritesheet _parent, string _name, Rectangle _rect)
        {
            parentSheet = _parent;
            name = _name;
            rectInSheet = _rect;
        }
        public void Draw(GameTime gameTime, Vector2 coords) { Draw(gameTime, (int)coords.X, (int)coords.Y); }
        public void Draw(GameTime gameTime, float x, float y) { Draw(gameTime, (int)x, (int)y); }
        public void Draw(GameTime gameTime, int x, int y)
        {
            Main.spriteBatch.Draw(parentSheet.sheetTexture, new Rectangle(x, y, rectInSheet.Width, rectInSheet.Height), rectInSheet, Color.White);
        }
        public void Draw(GameTime gameTime, int x, int y, int width, int height)
        {
            Main.spriteBatch.Draw(parentSheet.sheetTexture, new Rectangle(x, y, width, height), rectInSheet, Color.White);
        }
    }
}
