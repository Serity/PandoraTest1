using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PandoraTest1.Managers;

namespace PandoraTest1.States
{
    public class EscMenuScreen : GameState
    {
        public Rectangle ExitGamePanel;
        public EscMenuScreen()
        {
            input = new Input.IHBattle();
            Point VPCenter = new Point(Main.graphics.GraphicsDevice.Viewport.Width / 2, Main.graphics.GraphicsDevice.Viewport.Height / 2);
            Point TextSize = Main.arialFont.MeasureString("Exit Game").ToPoint();
            ExitGamePanel = new Rectangle(VPCenter.X - ((TextSize.X + 18) / 2), VPCenter.Y - ((TextSize.Y + 18)/2), TextSize.X + 18, TextSize.Y + 18);
            drawPreviousGameState = true;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (InputManager.Mouse.MouseClick(ExitGamePanel)) { Main.instance.Exit(); }
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Color c = Color.White;
            c *= 0.5f; // transparent
            int panelHeight = 180;
            // todo: create UI Objects (UI Panel, UI Button, etc..)
            Rectangle r = new Rectangle(0, 0, Main.GameWidth, panelHeight);
            Main.spriteBatch.DrawRect(r, c);
            Main.spriteBatch.DrawRect(ExitGamePanel, Color.Red * 0.5f);
            Main.spriteBatch.DrawBox(ExitGamePanel, Color.Red);
            Vector2 textPos = ExitGamePanel.Center.ToVector2();
            Vector2 q = Main.arialFont.MeasureString("Exit Game");
            textPos -= q / 2;
            textPos.X = (float)Math.Ceiling(textPos.X); textPos.Y = (float)Math.Ceiling(textPos.Y);
            Main.spriteBatch.DrawString(Main.arialFont, "Exit Game", textPos, Color.White);
            if (InputManager.Mouse.MouseHover(ExitGamePanel))
            {
                if (InputManager.Mouse.coordsMouseClickDown.Intersects(ExitGamePanel))
                {
                    Main.spriteBatch.DrawRect(ExitGamePanel, Color.Black * 0.5f);
                }
                else { Main.spriteBatch.DrawRect(ExitGamePanel, Color.White * 0.1f); }
            }
        }
    }
}
