using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PandoraTest1.UI.Battle
{
    public class LowerHUD_BreadcrumbsListPanel : UIObject
    {
        public Stack<UI_BattleBreadcrumbIconPanel> BreadcrumbList = new Stack<UI_BattleBreadcrumbIconPanel>();
    }
}
