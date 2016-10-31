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
            drawPreviousGameState = true;
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Color c = Color.White;
            c *= 0.5f; // transparent
            int panelHeight = 180;
            Rectangle r = new Rectangle(0, Main.GameHeight - panelHeight, Main.GameWidth, panelHeight);
            Main.spriteBatch.DrawRect(r, c);
            Main.spriteBatch.DrawBox(r, Color.Red);
        }
    }
}
