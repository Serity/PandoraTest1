using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using PandoraTest1.Managers;
using System.Linq;
using System.Text;

namespace PandoraTest1.UI
{
    public class UIObject
    {
        public UIObject parent;
        public List<UIObject> children = new List<UIObject>();

        public bool visible = true;
        public bool updateable = true;

        // location/size
        public Rectangle dimensions;
        // inner dimensions are dimensions with padding included
        // used to specify positioning coordinates for children
        public Rectangle innerDimensions;

        // 0.0~1.0 quickly align within parent element (0 horiz = far left, 1 horiz = far right)
        public float alignHorizontal;
        public float alignVertical;

        // offset X/Y by values
        private int _left;
        private int _top;
        public int Left { get { return _left; } set { _left = value; Recalculate(); } }
        public int Top { get { return _top; } set { _top = value; Recalculate(); } }

        private int _width;
        private int _height;
        public int Width { get { return _width; } set { _width = value; Recalculate(); } }
        public int Height { get { return _height; } set { _height = value; Recalculate(); } }

        // Padding for innerDimensions (paddingTop = 2 means children coords will be rendered from (X+2)=top left)
        public int PaddingLeft;
        public int PaddingRight;
        public int PaddingTop;
        public int PaddingBottom;
        public int PaddingAll { set { PaddingLeft = PaddingRight = PaddingTop = PaddingBottom = value; } }
        // return true to prevent parent click events from triggering
        public Func<bool> OnMouseDown;
        public Func<bool> OnMouseUp;
        public Func<bool> OnMouseClick;
        public Func<bool> OnMouseEnter;
        public Func<bool> OnMouseLeave;
        public Func<bool> OnMouseHeld;
        public Func<bool> OnMouseHover;

        public Action DrawPreChildrenDelegate;
        public Action DrawPostChildrenDelegate;
        public Action UpdateDelegate;

        public Vector2 Center {
            get { return dimensions.Center.ToVector2(); }
        }
        public virtual void Draw(GameTime gameTime)
        {
            if (DrawPreChildrenDelegate != null) { DrawPreChildrenDelegate(); }
            foreach (UIObject uic in children) { uic.Draw(gameTime); }
            if (DrawPostChildrenDelegate != null) { DrawPostChildrenDelegate(); }
        }
        public virtual bool Update(GameTime gameTime)
        {
            if (UpdateDelegate != null) { UpdateDelegate(); }

            bool hover = InputManager.Mouse.MouseHover(dimensions);
            if (!hover) {
                if (InputManager.Mouse.MouseLeave(dimensions) && OnMouseLeave != null) { return OnMouseLeave(); }
                //return false;
            }

            bool childDidClick = false; 

            foreach (UIObject uic in children) {
                childDidClick = uic.Update(gameTime);
                if (childDidClick) { return true; }
            }
            if (InputManager.Mouse.MouseClick(dimensions) && OnMouseClick != null) { return OnMouseClick(); }
            else if (InputManager.Mouse.MouseDown() && OnMouseDown != null) { return OnMouseDown(); }
            else if (InputManager.Mouse.MouseUp() && OnMouseUp != null) { return OnMouseUp(); }
            else if (InputManager.Mouse.MouseEnter(dimensions) && OnMouseEnter != null) { return OnMouseEnter(); }
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
