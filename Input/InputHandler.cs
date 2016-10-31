using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PandoraTest1.States;
using Microsoft.Xna.Framework;
using PandoraTest1.Managers;
using Microsoft.Xna.Framework.Input;

namespace PandoraTest1.Input
{
    public abstract class InputHandler
    {
        float delayRemaining = 5;
        bool timerOn = false;
        public virtual void Update(GameTime gameTime) {
            /* temp test for input blocking */
            if (timerOn)
            {
                delayRemaining -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (delayRemaining <= 0)
                {
                    InputManager.UnblockInput();
                    Console.WriteLine("input unblocked");
                    timerOn = false;
                }
            }
            if (KeybindHandler.Debug1.Down) { Main.aPandora.health -= 25; }
            else if (KeybindHandler.Debug2.Down) { StateManager.currentState = StateManager.GetState(StateID.BattleScreen); }
            else if (KeybindHandler.Debug3.Down) {
                timerOn = true;
                Console.WriteLine("input blocked");
                InputManager.BlockInput();
                delayRemaining = 5;
            }
            else if (KeybindHandler.Debug4.Down) { StateManager.currentState = StateManager.GetState(StateID.MainMenu); }

            else if (KeybindHandler.Debug5.Down)
            {
                GameState s = StateManager.GetState(StateID.DebugSpritesheetScreen);
                if (StateManager.currentState == s) { StateManager.stateStack.Pop(); }
                else { StateManager.currentState = s; }
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || KeybindHandler.EscButton.Down)
            {
                if (StateManager.currentState == StateManager.GetState(StateID.EscMenuScreen)) { StateManager.stateStack.Pop(); }
                else { StateManager.currentState = StateManager.GetState(StateID.EscMenuScreen); }
            }

        }
    }
}
