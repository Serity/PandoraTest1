﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PandoraTest1.Managers;
using PandoraTest1.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraTest1.Input
{
    public class IHMainMenu : InputHandler
    {
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (KeybindHandler.CancelButton.Down) { Main.v += 64; }
            if (KeybindHandler.ConfirmButton.Pressed) { Main.playerMapEntity.TryInteract(); return; }

            if (KeybindHandler.DownButton.Pressed) { Main.playerMapEntity.MoveDown(); }
            else if (KeybindHandler.UpButton.Pressed) { Main.playerMapEntity.MoveUp(); }
            else if (KeybindHandler.LeftButton.Pressed) { Main.playerMapEntity.MoveLeft(); }
            else if (KeybindHandler.RightButton.Pressed) { Main.playerMapEntity.MoveRight(); }

            MainMenu mm = StateManager.GetState(StateID.MainMenu) as MainMenu;
            if (InputManager.Mouse.MouseDown()) { mm.drawCrosshair = true; }
            else if (InputManager.Mouse.MouseUp()) { mm.drawCrosshair = false; }
        }
    }
}
