using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace PandoraTest1.Managers
{
    public class InputManager
    {
        public static KeyboardHandler Keyboard = new KeyboardHandler();
        public static MouseHandler Mouse = new MouseHandler();

        public static void Update()
        {
            Keyboard.Update();
            Mouse.Update();
        }
    }
    public class KeybindHandler
    {
        public static Keybind ConfirmButton = new Keybind(new Keys[] { Keys.Z });
        public static Keybind CancelButton = new Keybind(new Keys[] { Keys.X });
        public static Keybind UpButton = new Keybind(new Keys[] { Keys.Up, Keys.W });
        public static Keybind DownButton = new Keybind(new Keys[] { Keys.Down, Keys.S });
        public static Keybind LeftButton = new Keybind(new Keys[] { Keys.Left, Keys.A });
        public static Keybind RightButton = new Keybind(new Keys[] { Keys.Right, Keys.D });
    }
    public class Keybind
    {
        public List<Keys> ValidKeys = new List<Keys>();

        public Keybind(Keys[] keys)
        {
            SetKeys(keys);
        }
        public void SetKeys(Keys[] keys)
        {
            ValidKeys.Clear();
            foreach (Keys k in keys) { ValidKeys.Add(k); }
        }
        /// <summary>
        /// Returns true on the first frame that the specified keybind is held down.
        /// </summary>
        public bool Down {
            get
            {
                foreach (Keys k in ValidKeys) { if (InputManager.Keyboard.KeyDown(k)) { return true; } }
                return false;
            }
        }
        /// <summary>
        /// Returns true on the first frame that the specified keybind is released.
        /// </summary>
        public bool Up
        {
            get
            {
                foreach (Keys k in ValidKeys) { if (InputManager.Keyboard.KeyUp(k)) { return true; } }
                return false;
            }
        }
        /// <summary>
        /// Returns true during the second and on frame that the specified keybind is held down.
        /// </summary>
        public bool Held {
            get
            {
                foreach (Keys k in ValidKeys) { if (InputManager.Keyboard.KeyHeld(k)) { return true; } }
                return false;
            }
        }
        /// <summary>
        /// Returns true if the specified keybind is held down at all.
        /// </summary>
        public bool Pressed
        {
            get
            {
                foreach (Keys k in ValidKeys) { if (InputManager.Keyboard.IsKeyPressed(k)) { return true; } }
                return false;
            }
        }
    }
    public class KeyboardHandler
    {
        public KeyboardState _oldState;
        public KeyboardState _newState;
        public void Update()
        {
            _oldState = _newState;
            _newState = Keyboard.GetState();
        }
        /// <summary>
        /// Returns true on the first frame that the specified key is held down.
        /// </summary>
        public bool KeyDown(Keys key) { return _oldState.IsKeyUp(key) && _newState.IsKeyDown(key); }
        /// <summary>
        /// Returns true on the first frame that the specified key is released.
        /// </summary>
        public bool KeyUp(Keys key) { return _oldState.IsKeyDown(key) && _newState.IsKeyUp(key); }
        /// <summary>
        /// Returns true during the second and on frame that the specified key is held down.
        /// </summary>
        public bool KeyHeld(Keys key) { return _oldState.IsKeyDown(key) && _newState.IsKeyDown(key); }
        /// <summary>
        /// Returns true if the specified key is held down at all.
        /// </summary>
        public bool IsKeyPressed(Keys key) { return _newState.IsKeyDown(key); }
        /// <summary>
        /// Returns true if either left or right shift key is pressed.
        /// </summary>
        public bool IsShiftPressed() { return IsKeyPressed(Keys.LeftShift) || IsKeyPressed(Keys.RightShift); }
    }
    public class MouseHandler
    {
        public MouseState _oldState;
        public MouseState _newState;
        public Vector2 Coords
        {
            get { return _newState.Position.ToVector2(); }
        }
        public void Update()
        {
            _oldState = _newState;
            _newState = Mouse.GetState();
        }

        /// <summary>
        /// Returns true on the first frame that the left mouse button is held down.
        /// </summary>
        public bool MouseDown() { return _oldState.LeftButton == ButtonState.Released && _newState.LeftButton == ButtonState.Pressed; }
        /// <summary>
        /// Returns true on the first frame that the left mouse button is released.
        /// </summary>
        public bool MouseUp() { return _oldState.LeftButton == ButtonState.Pressed && _newState.LeftButton == ButtonState.Released; }
        /// <summary>
        /// Returns true during the second and on frame that the left mouse button is held down.
        /// </summary>
        public bool MouseHeld() { return _oldState.LeftButton == ButtonState.Pressed && _newState.LeftButton == ButtonState.Pressed; }
        /// <summary>
        /// Returns true if the left mouse button is held down at all.
        /// </summary>
        public bool IsMousePressed() { return _newState.LeftButton == ButtonState.Pressed; }

        /// <summary>
        /// Returns true on the first frame that the right mouse button is held down.
        /// </summary>
        public bool RightMouseDown() { return _oldState.RightButton == ButtonState.Released && _newState.RightButton == ButtonState.Pressed; }
        /// <summary>
        /// Returns true on the first frame that the right mouse button is released.
        /// </summary>
        public bool RightMouseUp() { return _oldState.RightButton == ButtonState.Pressed && _newState.RightButton == ButtonState.Released; }
        /// <summary>
        /// Returns true during the second and on frame that the right mouse button is held down.
        /// </summary>
        public bool RightMouseHeld() { return _oldState.RightButton == ButtonState.Pressed && _newState.RightButton == ButtonState.Pressed; }
        /// <summary>
        /// Returns true if the right mouse button is held down at all.
        /// </summary>
        public bool IsRightMousePressed() { return _newState.RightButton == ButtonState.Pressed; }

        /// <summary>
        /// Returns whether or not the mousewheel scrolled up (1), down (-1), or didn't move (0).
        /// </summary>
        /// <returns>-1 for down, 1 for up</returns>
        public int ScrollWheelValue() { return _newState.ScrollWheelValue.CompareTo(_oldState.ScrollWheelValue); } // -1: down, 1: up

        /// <summary>
        /// Returns true during the frame the mouse enters a rectangle.
        /// </summary>
        public bool MouseEnter(Rectangle r) { return !MouseHover(r, _oldState.X, _oldState.Y) && MouseHover(r); }
        /// <summary>
        /// Returns true during the frame the mouse leaves a rectangle.
        /// </summary>
        public bool MouseLeave(Rectangle r) { return MouseHover(r, _oldState.X, _oldState.Y) && !MouseHover(r); }
        /// <summary>
        /// Returns true if the mouse is hovering over a rectangle.
        /// </summary>
        public bool MouseHover(Rectangle r)
        {
            return MouseHover(r, _newState.X, _newState.Y);
        }
        /// <summary>
        /// Returns true if a point at coordinates X,Y intersects a rectangle.
        /// </summary>
        /// <param name="x">Defaults to mouse current state x.</param>
        /// <param name="y">Defaults to mouse current state y.</param>
        private bool MouseHover(Rectangle r, int x = -1, int y = -1)
        {
            if (x == -1) { x = _newState.X; }
            if (y == -1) { y = _newState.Y; }
            return r.Intersects(new Rectangle(x, y, 1, 1));
        }
    }
}