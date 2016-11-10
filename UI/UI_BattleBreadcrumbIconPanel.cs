using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraTest1.UI
{
    public class UI_BattleBreadcrumbIconPanel : UISprite
    {
        public UI_BattleSelectorPanel _originalPanel;
        public UISpriteShadow panelIcon = new UISpriteShadow();
        public UITheme.UITheme_Structure panelColor;

        public UI_BattleBreadcrumbIconPanel(UI_BattleSelectorPanel originalPanel) {
            _originalPanel = originalPanel;
            panelColor = _originalPanel.panelColor;
            panelIcon.SetSprite(_originalPanel.panelIcon.sprite);

            SetSprite(panelColor.Panel_Square);
            panelIcon.SetParent(this);

            Width = 45; Height = 45;
            Left = 0;
            Top = 0;

            panelIcon.alignHorizontal = 0f;
            panelIcon.alignVertical = 0f;
            panelIcon.Left = 0;

            PaddingAll = 4;
            Recalculate();
            panelIcon.Width = innerDimensions.Width;
            panelIcon.Height = innerDimensions.Height;
            RecalculateChildren();

            OnMouseClick = () => { _originalPanel.Unselect(); return true; };
        }
    }
}
