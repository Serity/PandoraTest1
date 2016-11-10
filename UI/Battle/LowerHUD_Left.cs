using PandoraTest1.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PandoraTest1.States;

namespace PandoraTest1.UI.Battle
{
    public class LowerHUD_Left : UIObject
    {
        public LowerHUD lowerhud;

        UI_BattleSelectorPanel AttackPanel = new UI_BattleSelectorPanel(UITheme.Red, "Attack", SpriteManager.GetSprite(Sheets.GIN_WT, "winged-sword"));
        UI_BattleSelectorPanel DefendPanel = new UI_BattleSelectorPanel(UITheme.Blue, "Defend", SpriteManager.GetSprite(Sheets.GIN3_WT, "shield"));
        UI_BattleSelectorPanel ItemPanel = new UI_BattleSelectorPanel(UITheme.Yellow, "Items", SpriteManager.GetSprite(Sheets.GIN6_WT, "fizzing-flask"));
        UI_BattleSelectorPanel UtilityPanel = new UI_BattleSelectorPanel(UITheme.Green, "Other", SpriteManager.GetSprite(Sheets.GIN6_WT, "exit-door"));

        public UI_BattleSelectorPanel hoveredPanel;
        public int selectedIndex = -1;

        List<UI_BattleSelectorPanel> panels = new List<UI_BattleSelectorPanel>();

        public LowerHUD_Left()
        {
            AttackPanel.SetParent(this);
            DefendPanel.SetParent(this);
            ItemPanel.SetParent(this);
            UtilityPanel.SetParent(this);
            panels.Add(AttackPanel);
            panels.Add(DefendPanel);
            panels.Add(ItemPanel);
            panels.Add(UtilityPanel);
            float top = 0.0f; // start it one-panel lower to give room for breadcrumbs
            foreach (UI_BattleSelectorPanel panel in panels)
            {
                panel.alignVertical = top;
                top += 0.33f;
            }
        }
        public override void Draw(GameTime gameTime)
        {
            if (lowerhud.BreadcrumbsCount() < 10) {
                foreach (UI_BattleSelectorPanel panel in panels)
                {
                    panel.Draw(gameTime);
                }
            }
            else { Main.spriteBatch.DrawString(Main.arialFont, lowerhud.PeekBreadcrumb()._originalPanel.text, new Vector2(80, 200), Color.Magenta); }
        }
        public override bool Update(GameTime gameTime)
        {
            if (lowerhud.BreadcrumbsCount() < 10)
            {
                foreach (UI_BattleSelectorPanel panel in panels)
                {
                    panel.Update(gameTime);
                }
            }
            return false;
        }
    }
}
