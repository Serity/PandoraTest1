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
    public class IHBattle : InputHandler
    {
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            BattleScreen screen = ((BattleScreen)StateManager.GetState(StateID.BattleScreen));


            if (KeybindHandler.CancelButton.Down)
            {
                screen?.LowerHUD.LeftPanel.hoveredPanel?.Select();
            }
            else if (KeybindHandler.ConfirmButton.Down)
            {
                screen?.LowerHUD.LeftPanel.hoveredPanel?.Unselect();
            }

            /*if (KeybindHandler.DownButton.Pressed) { Main.playerMapEntity.MoveDown(); }
            else if (KeybindHandler.UpButton.Pressed) { Main.playerMapEntity.MoveUp(); }
            else if (KeybindHandler.LeftButton.Pressed) { Main.playerMapEntity.MoveLeft(); }
            else if (KeybindHandler.RightButton.Pressed) { Main.playerMapEntity.MoveRight(); }
            */
            if (StateManager.currentState is BattleScreen)
            {
                
            }

        }
    }
}
