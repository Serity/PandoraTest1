using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PandoraTest1.States;
using Microsoft.Xna.Framework;
using PandoraTest1.Managers;
namespace PandoraTest1.Input
{
    public abstract class InputHandler
    {
        public virtual void Update(GameTime gameTime) {
            if (KeybindHandler.Debug1.Down) { Main.aPandora.health -= 25; }
            else if (KeybindHandler.Debug2.Down) { StateManager.currentState = StateManager.GetState(StateID.BattleScreen); }
            else if (KeybindHandler.Debug3.Down) { StateManager.stateStack.Pop(); }
            else if (KeybindHandler.Debug4.Down) { StateManager.currentState = StateManager.GetState(StateID.MainMenu); }
        }
    }
}
