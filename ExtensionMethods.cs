using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PandoraTest1.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraTest1
{
    public static class ExtensionMethods
    {
        // thanks to Cyral at StackOverflow http://stackoverflow.com/questions/17275315/
        public static void DrawLine(this SpriteBatch spriteBatch, Vector2 begin, Vector2 end, Color color, int width = 1)
        {
            Rectangle r = new Rectangle((int)begin.X, (int)begin.Y, (int)(end - begin).Length() + width, width);
            Vector2 v = Vector2.Normalize(begin - end);
            float angle = (float)Math.Acos(Vector2.Dot(v, -Vector2.UnitX));
            if (begin.Y > end.Y) angle = MathHelper.TwoPi - angle;
            Vector2 origin = Vector2.Zero;
            // dumb hack for vertical lines only so left-side is aligned with X instead of right-side
            // won't fix diagonals at all :/
            if (angle == 1.57079637f) { origin = new Vector2(0f, 1f); } 
            spriteBatch.Draw(Main.texturePixel, r, null, color, angle, origin, SpriteEffects.None, 0);
        }
        public static void DrawBox(this SpriteBatch spriteBatch, Rectangle rectangle, Color color, int width = 1)
        {
            // bleh off-by-one issue when using Top+Height=Bottom or Left+Width=Right
            spriteBatch.Draw(Main.texturePixel, new Rectangle(rectangle.Left, rectangle.Top, width, rectangle.Height), color); // Left
            spriteBatch.Draw(Main.texturePixel, new Rectangle(rectangle.Right - width, rectangle.Top, width, rectangle.Height), color); // Right
            spriteBatch.Draw(Main.texturePixel, new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, width), color); // Top
            spriteBatch.Draw(Main.texturePixel, new Rectangle(rectangle.Left, rectangle.Bottom - width, rectangle.Width, width), color); // Bottom
        }
        public static void DrawRect(this SpriteBatch spriteBatch, Rectangle rectangle, Color color)
        {
            spriteBatch.Draw(Main.texturePixel, rectangle, color);
        }
    }
}
