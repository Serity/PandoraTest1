using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PandoraTest1.Managers;
using PandoraTest1.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraTest1.Input
{
    public class IHDebugSprite : InputHandler
    {
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
                if (KeybindHandler.DownButton.DownOrHeld) { ((DebugSpritesheetScreen)StateManager.GetState(StateID.DebugSpritesheetScreen)).ChangeIndex(1); }
                else if (KeybindHandler.UpButton.DownOrHeld) { ((DebugSpritesheetScreen)StateManager.GetState(StateID.DebugSpritesheetScreen)).ChangeIndex(-1); }
            
            else if (KeybindHandler.LeftButton.DownOrHeld) { ((DebugSpritesheetScreen)StateManager.GetState(StateID.DebugSpritesheetScreen)).ChangeSheetIndex(-1); }
            else if (KeybindHandler.RightButton.DownOrHeld) { ((DebugSpritesheetScreen)StateManager.GetState(StateID.DebugSpritesheetScreen)).ChangeSheetIndex(1); }
            else if (KeybindHandler.ConfirmButton.DownOrHeld) { ((DebugSpritesheetScreen)StateManager.GetState(StateID.DebugSpritesheetScreen)).ChangeAlign(-0.01f); }
            else if (KeybindHandler.CancelButton.DownOrHeld) { ((DebugSpritesheetScreen)StateManager.GetState(StateID.DebugSpritesheetScreen)).ChangeAlign(0.01f); }
        }
    }
}
