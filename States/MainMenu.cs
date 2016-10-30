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
            town = new Map(Main.tilesets.FirstOrDefault(t => t.name.Equals("Town16")), 4, 4);
            for (int i = 0; i < town.bottomLayer.Length; i++)
            {
                int x = i % town.width;
                int y = i / town.width;
                town.bottomLayer[x,y] = (int)Town16Test.Tiles.Dirt;
            }
            town.bottomLayer[3, 3] = -1;
            town.middleLayer[1, 1] = (int)Town16Test.Tiles.Barrel;
            town.tileset.GetTilesetTile((int)Town16Test.Tiles.Barrel).solid.All = true;
            town.tileset.GetTilesetTile((int)Town16Test.Tiles.Barrel).solid.Left = false;

            town.topLayer[1,1] = (int)Town16Test.Tiles.Tree_Top;
            town.topLayer[1,2] = (int)Town16Test.Tiles.Tree_Bottom;
            town.tileset.GetTilesetTile((int)Town16Test.Tiles.Tree_Bottom).solid.Bottom = true;
        }
        public static Map town;
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            town.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            town.Draw(gameTime);
            Main.spriteBatch.DrawString(Main.arialFont, Main.aPandora.name + "  " + Main.aPandora.health.ToString(), new Vector2(400), Color.Red);
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
    }
}
