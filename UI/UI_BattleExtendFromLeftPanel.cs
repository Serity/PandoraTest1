using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PandoraTest1.Graphics;
using PandoraTest1.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraTest1.UI
{
    public class UI_BattleExtendFromLeftPanel : UISprite
    {
        UISpriteShadow panelIcon = new UISpriteShadow();
        UITheme.UITheme_Structure panelColor;
        int extended = -1; // 0 for extending, 1 for extended, -1 for not extended

        string _text;
        public string text
        {
            get { return _text; }
            set
            {
                _text = value;
                textDimensions = Main.arialFont.MeasureString(_text);
            }
        }

        Color offColor = Color.White;
        Vector2 textDimensions;

        public UI_BattleExtendFromLeftPanel(UITheme.UITheme_Structure color, string text = "", Sprite sprite = null)
        {
            this.text = text;
            panelColor = color;
            int iconLeftPad = 2;
            panelIcon.SetSprite(sprite);
            panelIcon.Width = panelIcon.Height = 25;
            panelIcon.alignHorizontal = 1.0f;
            panelIcon.alignVertical = 0.5f;
            panelIcon.Left = iconLeftPad;
            panelIcon.SetParent(this);
            
            SetSprite(panelColor.Panel_Flat);
            PaddingAll = 6;
            PaddingRight += 2;
            int panel_left = (-1 * Width) + panelIcon.Width + PaddingRight + panelIcon.Left;
            Left = panel_left;

            OnMouseEnter = () => { Extend(); return true; };
            OnMouseLeave = () => { Retract(); return true; };
            Recalculate();
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            if (extended == -1) { Main.spriteBatch.DrawRect(dimensions, Color.Black * 0.15f); }
            Vector2 textLoc = new Vector2(innerDimensions.Right - panelIcon.Width - (int)textDimensions.X - 2,
                                                   (innerDimensions.Center.Y - textDimensions.Y / 2));
            Main.spriteBatch.DrawString(Main.arialFont, text, textLoc + new Vector2(1), Color.Black);
            Main.spriteBatch.DrawString(Main.arialFont, text, textLoc, Color.White);
            if (InputManager.Mouse.MouseHover(dimensions)) { Main.spriteBatch.Draw(Main.texturePixel, new Rectangle(InputManager.Mouse.Coords.ToPoint(), new Point(30, 30)), Color.Black); }
        }
        public void Extend()
        {
            // todo: animation (extend: 0)
            Left = -1 * PaddingLeft;
            extended = 1;
        }
        public void Retract()
        {
            int panel_left = (-1 * Width) + panelIcon.Width + PaddingRight + panelIcon.Left;
            Left = panel_left;
            extended = -1;
        }
        public void SetText(string _text)
        {
        }
    }
}
