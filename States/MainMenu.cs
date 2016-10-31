using PandoraTest1.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PandoraTest1.Managers;
using Microsoft.Xna.Framework.Input;
using PandoraTest1.Tilesets;

namespace PandoraTest1.States
{
    public class MainMenu : GameState
    {
        public bool drawCrosshair = false;

        public MainMenu()
        {
            input = new IHMainMenu();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MapManager.currentMap.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            MapManager.currentMap.Draw(gameTime);
            if (drawCrosshair) {
                Vector2 hor1 = new Vector2(0, InputManager.Mouse.Coords.Y);
                Vector2 hor2 = new Vector2(Main.graphics.GraphicsDevice.Viewport.Width, InputManager.Mouse.Coords.Y);
                Vector2 ver1 = new Vector2(InputManager.Mouse.Coords.X, 0);
                Vector2 ver2 = new Vector2(InputManager.Mouse.Coords.X, Main.graphics.GraphicsDevice.Viewport.Height);

                Main.spriteBatch.DrawLine(hor1, hor2, Color.Red,13);
                Main.spriteBatch.DrawLine(ver1, ver2, Color.Blue,13);
                Main.spriteBatch.DrawBox(new Rectangle((int)InputManager.Mouse.Coords.X - 8, (int)InputManager.Mouse.Coords.Y - 8, 16, 16), Color.White);
                Main.spriteBatch.DrawRect(new Rectangle((int)InputManager.Mouse.Coords.X - 1, (int)InputManager.Mouse.Coords.Y - 1, 3, 3), Color.Green);
            }
        }
        public override void ExitState()
        {
            base.ExitState();
            drawCrosshair = false;
        }
    }
}
