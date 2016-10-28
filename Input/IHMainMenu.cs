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
    public class IHMainMenu : InputHandler
    {
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (InputManager.Keyboard.KeyDown(Keys.X)) { Main.v += 64; }
            if (InputManager.Keyboard.IsKeyPressed(Keys.Z)) { Main.playerMapEntity.TryInteract(); }
            if (InputManager.Keyboard.IsKeyPressed(Keys.Down)) { Main.playerMapEntity.MoveDown(); }
            else if(InputManager.Keyboard.IsKeyPressed(Keys.Up)) { Main.playerMapEntity.MoveUp(); }
            else if (InputManager.Keyboard.IsKeyPressed(Keys.Left)) { Main.playerMapEntity.MoveLeft(); }
            else if(InputManager.Keyboard.IsKeyPressed(Keys.Right)) { Main.playerMapEntity.MoveRight(); }
            if (Main.currentInterface is MainMenu)
            {
                ((MainMenu)Main.currentInterface).drawCrosshair = InputManager.Mouse.MouseDown();
            }

            if (InputManager.Keyboard.KeyDown(Keys.Left)) { Main.angle -= 0.01f; }
            if (InputManager.Keyboard.KeyDown(Keys.Right)) { Main.angle += 0.01f; }
        }
    }
}
