using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PandoraTest1.Input;
using PandoraTest1.Managers;
using Microsoft.Xna.Framework;

namespace PandoraTest1.States
{
    public abstract class GameState
    {
        public InputHandler input;

        public bool drawPreviousGameState = false; // continue to draw previous game state[s] (GUI)
        public bool updatePreviousGameState = false; // continue to update previous game state[s]/no-pause
        public bool allowInputPassthrough = false; // permit input from passing through to underneath game state

        public bool _tmp_doInput = false;
        public GameState()
        {
            Console.WriteLine(this.ToString());
        }
        public virtual void Update(GameTime gameTime)
        {
            if (input != null) {
                if (StateManager.currentState == this || _tmp_doInput) { input.Update(gameTime); }
            }
            if (updatePreviousGameState && StateManager.stateStack.Count > 1)
            {
                GameState st = StateManager.PreviousState(this);
                if (st != this) {
                    st._tmp_doInput = allowInputPassthrough;
                    st.Update(gameTime);
                    st._tmp_doInput = false;
                }
            }
        }
        public virtual void Draw(GameTime gameTime)
        {
            if (drawPreviousGameState && StateManager.stateStack.Count > 1) {
                GameState st = StateManager.PreviousState(this);
                if (st != this) { st.Draw(gameTime); }
            }
            if (drawPreviousGameState && !allowInputPassthrough)
            {
                // darken previous layer to indicate can't input on previous layer
                Main.spriteBatch.DrawRect(new Rectangle(0, 0, Main.graphics.GraphicsDevice.Viewport.Width, Main.graphics.GraphicsDevice.Viewport.Height), new Color(0, 0, 0, 0.66f));
            }
        }
    }
}
