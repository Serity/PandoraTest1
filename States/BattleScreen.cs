using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PandoraTest1.States
{
    public class BattleScreen : GameState
    {
        public BattleScreen()
        {
            input = new Input.IHBattle();
            //drawPreviousGameState = true;
            //updatePreviousGameState = true;
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Main.spriteBatch.DrawRect(new Rectangle(0, 0, Main.graphics.GraphicsDevice.Viewport.Width, Main.graphics.GraphicsDevice.Viewport.Height), new Color(0, 0, 0, 0.66f));
        }
    }
}
