using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PandoraTest1.UI.Battle
{
    public class LowerHUD : UIObject
    {
        public LowerHUD_Left LeftPanel = new LowerHUD_Left();
        public LowerHUD_BreadcrumbsListPanel Breadcrumbs = new LowerHUD_BreadcrumbsListPanel();
        public UISprite divider = new UISprite();
        public LowerHUD()
        {
            Height = 45 * 5 + 4;
            Width = Main.GameWidth;
            alignVertical = 1.0f;

            Breadcrumbs.SetParent(this);
            Breadcrumbs.Width = Width;
            Breadcrumbs.Height = 45;

            divider.SetParent(this); // setparent in render order
            divider.SetSprite(UITheme.Blue._sliderHorizontal);
            divider.Width = Width;
            divider.Top = Breadcrumbs.dimensions.Bottom;

            LeftPanel.SetParent(this);
            LeftPanel.Height = 45*4+2;
            LeftPanel.Top = 2;
            LeftPanel.lowerhud = this;
            LeftPanel.alignVertical = 1.0f;

            Recalculate();
        }
        public void AddBreadcrumb(UI_BattleBreadcrumbIconPanel bcip)
        {
            bcip.Left = BreadcrumbsCount() * 45;
            Breadcrumbs.BreadcrumbList.Push(bcip);
            bcip.SetParent(Breadcrumbs);
            Breadcrumbs.Recalculate();
        }
        public void RemoveBreadcrumb()
        {
            UI_BattleBreadcrumbIconPanel peek = PeekBreadcrumb();
            Breadcrumbs.BreadcrumbList.Pop();
            Breadcrumbs.children.Remove(peek);
        }
        public int BreadcrumbsCount()
        {
            return Breadcrumbs.BreadcrumbList.Count();
        }
        public UI_BattleBreadcrumbIconPanel PeekBreadcrumb() { return Breadcrumbs.BreadcrumbList.Peek(); }
        public override void Draw(GameTime gameTime)
        {
            Main.spriteBatch.DrawRect(new Rectangle(0, divider.dimensions.Y, Width, Height - divider.Top), Color.RoyalBlue);
            base.Draw(gameTime);
            Main.spriteBatch.DrawBox(LeftPanel.dimensions, Color.Red);
        }
    }
}
