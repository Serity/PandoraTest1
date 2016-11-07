using PandoraTest1.Graphics;
using PandoraTest1.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandoraTest1.UI
{
    public class UITheme
    {
        // Unfortunately, the Grey/Red Kenney UI packs have the buttons/panels in a different order
        public static UITheme_Structure Blue = new UITheme_Structure(UITheme_Color.Blue,
                                                                    "button00", "button01", "button02", "button03",
                                                                    "button04", "button05", "button13", "button07",
                                                                    "button08", "button09", "button10", "button11",
                                                                    "button12", "button06");
        public static UITheme_Structure Green = new UITheme_Structure(UITheme_Color.Green,
                                                                      "button00", "button01", "button02", "button03",
                                                                      "button04", "button05", "button13", "button07",
                                                                      "button08", "button09", "button10", "button11",
                                                                      "button12", "button06");
        public static UITheme_Structure Grey = new UITheme_Structure(UITheme_Color.Grey,
                                                                     "button15", "button00", "button01", "button02",
                                                                     "button03", "button04", "button14", "button08",
                                                                     "button09", "button10", "button11", "button12",
                                                                     "button13", "button07");
        public static UITheme_Structure Red = new UITheme_Structure(UITheme_Color.Red,
                                                                    "button11", "button12", "button13", "button00",
                                                                    "button01", "button02", "button10", "button04",
                                                                    "button05", "button06", "button07", "button08",
                                                                    "button09", "button03");
        public static UITheme_Structure Yellow = new UITheme_Structure(UITheme_Color.Yellow,
                                                                      "button00", "button01", "button02", "button03",
                                                                      "button04", "button05", "button13", "button07",
                                                                      "button08", "button09", "button10", "button11",
                                                                      "button12", "button06");
        public class UITheme_Color
        {
            private UITheme_Color(string v) { Value = v; }
            public string Value { get; set; }
            public static UITheme_Color Blue { get { return new UITheme_Color("blue"); } }
            public static UITheme_Color Green { get { return new UITheme_Color("green"); } }
            public static UITheme_Color Grey { get { return new UITheme_Color("grey"); } }
            public static UITheme_Color Red { get { return new UITheme_Color("red"); } }
            public static UITheme_Color Yellow { get { return new UITheme_Color("yellow"); } }
        }
        public class UITheme_Structure
        {
            UITheme_Color PanelColor;
            public UITheme_Structure(UITheme_Color color,
                                     string _panel_half_shadow, string _panel_half, string _panel_flat_shadow, string _panel_flat,
                                     string _panel_gradient_shadow, string _panel_gradient, string _panel_grey_with_border_shadow,
                                     string _button_half_shadow, string _button_half, string _button_flat_shadow, string _button_flat,
                                     string _button_gradient_shadow, string _button_gradient, string _button_grey_with_border_shadow)
            {
                _Panel_HalfShadow = _panel_half_shadow; _Panel_Half = _panel_half; _Panel_FlatShadow = _panel_flat_shadow; _Panel_Flat = _panel_flat;
                _Panel_GradientShadow = _panel_gradient_shadow; _Panel_Gradient = _panel_gradient; _Panel_GreyWithBorderShadow = _panel_grey_with_border_shadow;
                _Button_HalfShadow = _button_half_shadow; _Button_Half = _button_half; _Button_FlatShadow = _button_flat_shadow; _Button_Flat = _button_flat;
                _Button_GradientShadow = _button_gradient_shadow; _Button_Gradient = _button_gradient; _Button_GreyWithBorderShadow = _button_grey_with_border_shadow;
                PanelColor = color;
                if (PanelColor == UITheme_Color.Grey)
                {
                    // also has white versions :/
                    _Checkmark += "Grey";
                    _Cross += "Grey";
                    _Tick += "Grey";
                }
            }
            private Sprite GetSprite(string s)
            {
                string text = PanelColor.Value + "_" + s;
                // these sprites only exist in the grey sheet 
                string[] greyOnly = { "sliderHorizontal", "sliderVertical", "sliderEnd", "arrowDownGrey",
                    "arrowDownWhite", "arrowUpGrey", "arrowUpWhite", "checkmarkWhite", "crossWhite", "tickWhite", "box" };
                if (greyOnly.Contains(s)) { text = "grey_" + s; }
                return SpriteManager.GetSprite(text);
            }
            private string _Panel_HalfShadow;
            private string _Panel_Half;
            private string _Panel_FlatShadow;
            private string _Panel_Flat;
            private string _Panel_GradientShadow;
            private string _Panel_Gradient;
            private string _Panel_Square = "panel";
            private string _Panel_GreyWithBorderShadow;
            private string _Button_HalfShadow;
            private string _Button_Half;
            private string _Button_FlatShadow;
            private string _Button_Flat;
            private string _Button_GradientShadow;
            private string _Button_Gradient;
            private string _Button_GreyWithBorderShadow;
            private string _Checkmark = "checkmark"; // grey checkmarkWhite & checkmarkGrey
            private string _Cross = "cross"; // grey crossWhite & crossGrey
            private string _Tick = "tick"; // grey tickWhite & tickGrey
            private string _Circle = "circle";
            private string _CheckmarkBox = "boxCheckmark";
            private string _CrossBox = "boxCross";
            private string _RadioButton = "boxTick";
            private string _SliderDown = "sliderDown";
            private string _SliderLeft = "sliderLeft";
            private string _SliderUp = "sliderUp";
            private string _SliderRight = "sliderRight";
            public Sprite Panel_HalfShadow { get { return GetSprite(_Panel_HalfShadow); } }
            public Sprite Panel_Half { get { return GetSprite(_Panel_Half); } }
            public Sprite Panel_FlatShadow { get { return GetSprite(_Panel_FlatShadow); } }
            public Sprite Panel_Flat { get { return GetSprite(_Panel_Flat); } }
            public Sprite Panel_GradientShadow { get { return GetSprite(_Panel_GradientShadow); } }
            public Sprite Panel_Gradient { get { return GetSprite(_Panel_Gradient); } }
            public Sprite Panel_Square { get { return GetSprite(_Panel_Square); } }
            public Sprite Panel_GreyWithBorderShadow { get { return GetSprite(_Panel_GreyWithBorderShadow); } }
            public Sprite Button_HalfShadow { get { return GetSprite(_Button_HalfShadow); } }
            public Sprite Button_Half { get { return GetSprite(_Button_Half); } }
            public Sprite Button_FlatShadow { get { return GetSprite(_Button_FlatShadow); } }
            public Sprite Button_Flat { get { return GetSprite(_Button_Flat); } }
            public Sprite Button_GradientShadow { get { return GetSprite(_Button_GradientShadow); } }
            public Sprite Button_Gradient { get { return GetSprite(_Button_Gradient); } }
            public Sprite Button_GreyWithBorderShadow { get { return GetSprite(_Button_GreyWithBorderShadow); } }
            public Sprite Checkmark { get { return GetSprite(_Checkmark); } }
            public Sprite Cross { get { return GetSprite(_Cross); } }
            public Sprite Tick { get { return GetSprite(_Tick); } }
            public Sprite Circle { get { return GetSprite(_Circle); } }
            public Sprite CheckmarkBox { get { return GetSprite(_CheckmarkBox); } }
            public Sprite CrossBox { get { return GetSprite(_CrossBox); } }
            public Sprite RadioButton { get { return GetSprite(_RadioButton); } }
            public Sprite SliderDown { get { return GetSprite(_SliderDown); } }
            public Sprite SliderLeft { get { return GetSprite(_SliderLeft); } }
            public Sprite SliderUp { get { return GetSprite(_SliderUp); } }
            public Sprite SliderRight { get { return GetSprite(_SliderRight); } }

            // grey also has sliderHorizontal, sliderVertical, sliderEnd, arrowDownGrey, arrowDownWhite, 
            // arrowUpGrey, arrowUpWhite, checkmarkWhite, crossWhite, tickWhite, box.
            public Sprite _sliderHorizontal { get { return GetSprite("sliderHorizontal"); } }
            public Sprite _sliderVertical { get { return GetSprite("sliderVertical"); } }
            public Sprite _sliderEnd { get { return GetSprite("sliderEnd"); } }
            public Sprite _arrowDownGrey { get { return GetSprite("arrowDownGrey"); } }
            public Sprite _arrowDownWhite { get { return GetSprite("arrowDownWhite"); } }
            public Sprite _arrowUpGrey { get { return GetSprite("arrowUpGrey"); } }
            public Sprite _arrowUpWhite { get { return GetSprite("arrowUpWhite"); } }
            public Sprite _checkmarkWhite { get { return GetSprite("checkmarkWhite"); } }
            public Sprite _crossWhite { get { return GetSprite("crossWhite"); } }
            public Sprite _tickWhite { get { return GetSprite("tickWhite"); } }
            public Sprite _greyBox { get { return GetSprite("box"); } }
        }


    }

}
