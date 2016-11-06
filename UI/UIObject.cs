using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using PandoraTest1.Managers;
using System.Linq;
using System.Text;

namespace PandoraTest1.UI
{
    public abstract class UIObject
    {
        public UIObject parent;
        public List<UIObject> children = new List<UIObject>();
        
        // location/size
        public Rectangle dimensions;
        // inner dimensions are dimensions with padding included
        // used to specify positioning coordinates for children
        public Rectangle innerDimensions;

        // 0.0~1.0 quickly align within parent element (0 horiz = far left, 1 horiz = far right)
        public float alignHorizontal;
        public float alignVertical;

        // offset X/Y by values
        public int Left;
        public int Top;

        public int Width;
        public int Height;

        // Padding for innerDimensions (paddingTop = 2 means children coords will be rendered from (X+2)=top left)
        public int PaddingLeft;
        public int PaddingRight;
        public int PaddingTop;
        public int PaddingBottom;

        // return true to prevent parent click events from triggering
        public Func<bool> OnMouseDown;
        public Func<bool> OnMouseUp;
        public Func<bool> OnMouseClick;
        public Func<bool> OnMouseEnter;
        public Func<bool> OnMouseLeave;
        public Func<bool> OnMouseHeld;
        public Func<bool> OnMouseHover;

        public Vector2 Center {
            get { return dimensions.Center.ToVector2(); }
        }
        public virtual void Draw(GameTime gameTime)
        {
            foreach (UIObject uic in children) { uic.Draw(gameTime); }
        }
        public virtual bool Update(GameTime gameTime)
        {
            bool hover = InputManager.Mouse.MouseHover(dimensions);
            if (!hover) { return false; }

            bool childDidClick = false; 

            foreach (UIObject uic in children) {
                childDidClick = uic.Update(gameTime);
                if (childDidClick) { return true; }
            }
            if (InputManager.Mouse.MouseClick(dimensions) && OnMouseClick != null) { return OnMouseClick(); }
            else if (InputManager.Mouse.MouseDown() && OnMouseDown != null) { return OnMouseDown(); }
            else if (InputManager.Mouse.MouseUp() && OnMouseUp != null) { return OnMouseUp(); }
            else if (InputManager.Mouse.MouseEnter(dimensions) && OnMouseEnter != null) { return OnMouseEnter(); }
            else if (InputManager.Mouse.MouseLeave(dimensions) && OnMouseLeave != null) { return OnMouseLeave(); }
            else if (InputManager.Mouse.MouseHeld() && OnMouseHeld != null) { return OnMouseHeld(); }
            else if (InputManager.Mouse.MouseHover(dimensions) && OnMouseHover != null) { return OnMouseHover(); }

            return false;
        }

        public void SetParent(UIObject uio)
        {
            parent = uio;
            uio.children.Add(this);
        }
        public void Recalculate()
        {
            Vector2 pCoords = parent != null ? parent.innerDimensions.Location.ToVector2() : Vector2.Zero;
            Vector2 pSize = parent != null ? parent.innerDimensions.Size.ToVector2() : new Vector2(Main.GameWidth, Main.GameHeight);
            Rectangle pRect = new Rectangle((int)pCoords.X, (int)pCoords.Y, (int)pSize.X, (int)pSize.Y);

            Rectangle dim = new Rectangle();
            dim.X = (int)(alignHorizontal * (pRect.Width - Width)) + pRect.X;
            dim.X += Left;
            dim.Y = (int)(alignVertical * (pRect.Height - Height)) + pRect.Y;
            dim.Y += Top;
            dim.Width = Width;
            dim.Height = Height;
            dimensions = dim;

            dim.X += PaddingLeft;
            dim.Y += PaddingTop;
            dim.Width -= PaddingLeft + PaddingRight;
            dim.Height -= PaddingTop + PaddingBottom;
            innerDimensions = dim;

            RecalculateChildren();
        }
        public void RecalculateChildren()
        {
            foreach (UIObject uio in children) { uio.Recalculate(); }
        }
    }
}
