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
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

        }
    }
}
