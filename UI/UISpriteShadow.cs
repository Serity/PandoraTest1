﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PandoraTest1.Graphics;
using Microsoft.Xna.Framework;

namespace PandoraTest1.UI
{
    public class UISpriteShadow : UISprite
    {
        Color shadowColor = Color.Black;
        public override void Draw(GameTime gameTime)
        {
            if (sprite != null) {
                sprite.Draw(gameTime, dimensions.X+1, dimensions.Y+1, dimensions.Width, dimensions.Height, shadowColor);
            }
            base.Draw(gameTime);
        }
    }
}
