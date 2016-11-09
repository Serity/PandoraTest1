using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PandoraTest1.Graphics;
using Microsoft.Xna.Framework;

namespace PandoraTest1.UI
{
    public class UISprite : UIObject
    {
        public Sprite sprite;
        public Color modColor = Color.White;

        public override void Draw(GameTime gameTime)
        {
            if (sprite != null) { sprite.Draw(gameTime, dimensions.X, dimensions.Y, dimensions.Width, dimensions.Height, modColor); }
            base.Draw(gameTime);
        }
        public void SetSprite(Sprite s)
        {
            sprite = s;
            if (sprite != null)
            {
                Width = s.rectInSheet.Width;
                Height = s.rectInSheet.Height;
            }
        }
    }
}
