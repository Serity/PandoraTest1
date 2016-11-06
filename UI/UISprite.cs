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

        public override void Draw(GameTime gameTime)
        {
            sprite.Draw(gameTime, dimensions.X, dimensions.Y, dimensions.Width, dimensions.Height);
            base.Draw(gameTime);
        }
        public void SetSprite(Sprite s)
        {
            sprite = s;
            Width = s.rectInSheet.Width;
            Height = s.rectInSheet.Height;
        }
    }
}
