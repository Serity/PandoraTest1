using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PandoraTest1.UI;
using PandoraTest1.Managers;

namespace PandoraTest1.States
{
    public class BattleScreen : GameState
    {
        public BattleScreen()
        {
            input = new Input.IHBattle();
            drawPreviousGameState = true;

            int top = 0;
            panels.Add(AttackPanel);
            panels.Add(DefendPanel);
            panels.Add(ItemPanel);
            panels.Add(UtilityPanel);
            foreach (UI_BattleExtendFromLeftPanel panel in panels)
            {
                panel.Top = top;
                top += panel.Height;
            }
        }
        UI_BattleExtendFromLeftPanel AttackPanel = new UI_BattleExtendFromLeftPanel(UITheme.Red, "Attack", SpriteManager.GetSprite(Sheets.GIN_WT, "winged-sword"));
        UI_BattleExtendFromLeftPanel DefendPanel = new UI_BattleExtendFromLeftPanel(UITheme.Blue, "Defend", SpriteManager.GetSprite(Sheets.GIN3_WT, "shield"));
        UI_BattleExtendFromLeftPanel ItemPanel = new UI_BattleExtendFromLeftPanel(UITheme.Yellow, "Use Item", SpriteManager.GetSprite(Sheets.GIN6_WT,"fizzing-flask"));
        UI_BattleExtendFromLeftPanel UtilityPanel = new UI_BattleExtendFromLeftPanel(UITheme.Green, "Miscellaneous", SpriteManager.GetSprite(Sheets.GIN6_WT, "exit-door"));

        List<UI_BattleExtendFromLeftPanel> panels = new List<UI_BattleExtendFromLeftPanel>();
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Color c = Color.White;
            c *= 0.5f; // transparent
            int panelHeight = 180;
            Rectangle r = new Rectangle(0, Main.GameHeight - panelHeight, Main.GameWidth, panelHeight);
            Main.spriteBatch.DrawRect(r, c);
            Main.spriteBatch.DrawBox(r, Color.Red);
            foreach (UI_BattleExtendFromLeftPanel panel in panels)
            {
                panel.Draw(gameTime);
            }
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (UI_BattleExtendFromLeftPanel panel in panels)
            {
                panel.Update(gameTime);
            }
        }
    }
}
