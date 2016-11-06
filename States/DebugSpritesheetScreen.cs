using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PandoraTest1.Managers;
using PandoraTest1.Graphics;
using PandoraTest1.UI;

namespace PandoraTest1.States
{
    public class DebugSpritesheetScreen : GameState
    {
        public Rectangle ExitGamePanel;
        public int index = 0;
        public int currentSpritesheet = 0;
        public Spritesheet thisSheet;
        public DebugSpritesheetScreen()
        {
            input = new Input.IHDebugSprite();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            panel.Update(gameTime);
        }
        float align = 1.0f;
        bool _init = false;
        UISprite panelIcon = new UISprite();
        UISprite panel = new UISprite();

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            //Main.graphics.GraphicsDevice.Clear(Color.Navy);
            Vector2 a = new Vector2(300, 50); // use default size
            Rectangle b = new Rectangle(300, 50, 25, 25); // shrink to 25x25

            if (thisSheet == null) { ChangeSheetIndex(0); }
            Sprite sprite = thisSheet.sprites.ElementAt(index);
            
            Main.spriteBatch.DrawString(Main.arialFont, thisSheet.name, new Vector2(300, 12), Color.White);
            Main.spriteBatch.DrawString(Main.arialFont, index + "["+ (thisSheet.sprites.Count-1)+"]"+"/" + sprite.name, new Vector2(300, 25), Color.White);
            Main.spriteBatch.DrawString(Main.arialFont, align.ToString(), new Vector2(300, 33), Color.White);
            sprite.Draw(gameTime, (int)a.X, (int)a.Y);
            int iconLeftPad = 2;
            if (!_init)
            {
                panel.OnMouseEnter = () => { Console.WriteLine("entering panel"); return true; };
                panelIcon.OnMouseEnter = () => { Console.WriteLine("entering icon"); return true; };
                panel.OnMouseDown = () => { Console.WriteLine("Clicked panel"); return true; };
                panelIcon.OnMouseDown = () => { Console.WriteLine("Clicked icon"); return true; };


                panelIcon.SetSprite(SpriteManager.GetSprite(Sheets.GIN_WT, "winged-sword.png"));
                panel.SetSprite(SpriteManager.GetSprite("blue_button03.png"));
                panelIcon.Width = panelIcon.Height = 25;
                panelIcon.alignHorizontal = 1.0f;
                panelIcon.alignVertical = 0.5f;
                panelIcon.Left = iconLeftPad;
                panelIcon.SetParent(panel);
                panel.PaddingRight = 6 + iconLeftPad;
                panel.Left = (-1 * panel.Width) + panelIcon.Width + panel.PaddingRight + panelIcon.Left;
                panel.Recalculate();
                _init = true;
            }
            panel.Draw(gameTime);
            panel.Top += panel.Height - 2;
            panel.Recalculate();
            panel.Draw(gameTime);
            panel.Top -= panel.Height - 2;
        }
        public void ChangeAlign(float f)
        {
            align += f;
        }
        public void ChangeIndex(int i)
        {
            index += i;
            Spritesheet s = SpriteManager.sheets.ElementAt(currentSpritesheet);
            if (index < 0) { index = s.sprites.Count - 1; }
            else if (index >= s.sprites.Count) { index = 0; }
        }
        public void ChangeSheetIndex(int i)
        {
            index = 0;
            currentSpritesheet += i;
            if (currentSpritesheet < 0) { currentSpritesheet = SpriteManager.sheets.Count - 1; }
            else if (currentSpritesheet >= SpriteManager.sheets.Count) { currentSpritesheet = 0; }
            thisSheet = SpriteManager.sheets.ElementAt(currentSpritesheet);
        }
    }
}
