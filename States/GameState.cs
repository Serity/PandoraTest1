using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PandoraTest1.Input;
using Microsoft.Xna.Framework;

namespace PandoraTest1.States
{
    public abstract class GameState
    {
        public InputHandler input;

        public GameState()
        {
        }
        public virtual void Update(GameTime gameTime)
        {
            input.Update(gameTime);
        }
        public virtual void Draw(GameTime gameTime)
        {

        }
    }
}
