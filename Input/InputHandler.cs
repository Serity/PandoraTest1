using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PandoraTest1.States;
using Microsoft.Xna.Framework;

namespace PandoraTest1.Input
{
    public abstract class InputHandler
    {
        public virtual void Update(GameTime gameTime) { }
    }
}
