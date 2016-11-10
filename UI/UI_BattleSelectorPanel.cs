using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using PandoraTest1.Graphics;
using PandoraTest1.Managers;
using PandoraTest1.States;

namespace PandoraTest1.UI
{
    public class UI_BattleSelectorPanel : UISprite
    {
        public UISpriteShadow panelIcon = new UISpriteShadow();
        public UITheme.UITheme_Structure panelColor;

        public bool hovering = false;
        public bool collapsed = false;

        string _text;
        public string text
        {
            get {
                return _text;
            }
            set
            {
                _text = value;
                textDimensions = Main.arialFont.MeasureString(_text);
            }
        }

        Color offColor = Color.White;
        Vector2 textDimensions;
        int iconLeftPad = 2;
        public UI_BattleSelectorPanel(UITheme.UITheme_Structure color, string text = "", Sprite sprite = null)
        {
            this.text = text;
            panelColor = color;
            panelIcon.SetSprite(sprite);
            panelIcon.SetParent(this);

            panelIcon.alignHorizontal = 1.0f;
            panelIcon.alignVertical = 0.5f;
            panelIcon.Left = iconLeftPad;
            panelIcon.Width = panelIcon.Height = 25;

            SetSprite(panelColor.Panel_Flat);
            Width = 95;
            PaddingAll = 6;
            PaddingRight += 2;

            OnMouseEnter = () => { hovering = true; Main.instance.Content.Load<SoundEffect>("Audio/rollover2").Play(); return true; };
            OnMouseLeave = () => { hovering = false; return true; };
            OnMouseHover = () => {
                BattleScreen btlscr = (BattleScreen)StateManager.GetState(StateID.BattleScreen);
                if (btlscr != null) { btlscr.LowerHUD.LeftPanel.hoveredPanel = this; }
                return true;
            };
            OnMouseClick = () =>
            {
                if (collapsed) { Unselect(); }
                else { Select(); }
                Main.instance.Content.Load<SoundEffect>("Audio/click1").Play();
                return true;
            };
            Recalculate();
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            if (!hovering) { Main.spriteBatch.DrawRect(dimensions, Color.Black * 0.15f); } // dim out
            Vector2 textLoc = new Vector2(innerDimensions.Right - panelIcon.Width - (int)textDimensions.X - 2,
                                                    (innerDimensions.Center.Y - textDimensions.Y / 2));
            textLoc = new Vector2(PaddingLeft + (innerDimensions.Width - panelIcon.Width) / 2 - (int)textDimensions.X / 2,
                (innerDimensions.Center.Y - textDimensions.Y / 2));
            Main.spriteBatch.DrawString(Main.arialFont, text, textLoc + new Vector2(1), Color.Black);
            Main.spriteBatch.DrawString(Main.arialFont, text, textLoc, Color.White);
        }
        public void Select()
        {
            BattleScreen btlscr = (BattleScreen)StateManager.GetState(StateID.BattleScreen);
            if (btlscr != null) { btlscr.LowerHUD.AddBreadcrumb(new UI_BattleBreadcrumbIconPanel(this)); }
        }
        public void Unselect()
        {
            collapsed = false;

            BattleScreen btlscr = (BattleScreen)StateManager.GetState(StateID.BattleScreen);
            if (btlscr.LowerHUD.PeekBreadcrumb()._originalPanel == this) { btlscr.LowerHUD.RemoveBreadcrumb(); }
        }
    }
}
