using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PandoraTest1.UI;
using PandoraTest1.Managers;

namespace PandoraTest1.States
{
    public class BattleScreen : GameState
    {
        public UI.Battle.LowerHUD LowerHUD = new UI.Battle.LowerHUD();
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
            LowerHUD.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            LowerHUD.Update(gameTime);
        }
    }
}
