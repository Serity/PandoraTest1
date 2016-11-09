#define DEBUG

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace PandoraTest1.Managers
{
    public class InputManager
    {
        public static bool lockInputForOneFrame = false; // disables rest-of-frame input checking (for kb at least)
        public static bool blockedInput = false;
        public static int keybindHeldMilliRepeatDelay = 500; // number of milliseconds a keybind must be held to qualify as 'held'
        public static int keybindHeldMilliRepeatRate = 100; // number of milliseconds between keybind held repeats

        public static KeyboardHandler Keyboard = new KeyboardHandler();
        public static MouseHandler Mouse = new MouseHandler();
        public static GameTime _gameTime;

        public static void Update(GameTime gameTime)
        {
            _gameTime = gameTime;
            lockInputForOneFrame = false;
            if (blockedInput) { return; }
            Keyboard.Update();
            Mouse.Update();
        }
        public static void Reset()
        {
            lockInputForOneFrame = true;
            Keyboard.Reset();
            Mouse.Reset();
        }
        public static void BlockInput()
        {
            blockedInput = true;
            Keyboard.ClearStates();
            Mouse.ClearStates();
        }
        public static void UnblockInput()
        {
            blockedInput = false;
        }
    }
    public class KeybindHandler
    {
        public static Keybind ConfirmButton = new Keybind(Keys.Z);
        public static Keybind CancelButton = new Keybind(Keys.X);
        public static Keybind UpButton = new Keybind(Keys.Up, Keys.W);
        public static Keybind DownButton = new Keybind(Keys.Down, Keys.S);
        public static Keybind LeftButton = new Keybind(Keys.Left, Keys.A);
        public static Keybind RightButton = new Keybind(Keys.Right, Keys.D);
        public static Keybind EscButton = new Keybind(Keys.Escape);

        public static Keybind Debug1 = new Keybind(Keys.F1);
        public static Keybind Debug2 = new Keybind(Keys.F2);
        public static Keybind Debug3 = new Keybind(Keys.F3);
        public static Keybind Debug4 = new Keybind(Keys.F4);
        public static Keybind Debug5 = new Keybind(Keys.F5);
        public static Keybind Debug6 = new Keybind(Keys.F6);
        public static Keybind Debug7 = new Keybind(Keys.F7);
        public static Keybind Debug8 = new Keybind(Keys.F8);
        public static Keybind Debug9 = new Keybind(Keys.F9);
        public static Keybind Debug10 = new Keybind(Keys.F10);
        public static Keybind Debug11 = new Keybind(Keys.F11);
        public static Keybind Debug12 = new Keybind(Keys.F12);

    }
    public class Keybind
    {
        public int heldBeginDelay = 0;
        public int heldRepeatDelay = 0;

        public List<Keys> ValidKeys = new List<Keys>();
        /// <summary>
        /// Initialize the keybinding.
        /// </summary>
        /// <param name="keys">CSV or array of keys to use for this keybinding</param>
        public Keybind(params Keys[] keys)
        {
            SetKeys(keys);
        }
        /// <summary>
        /// Reconfigure the keybinding (e.g. options menu)
        /// </summary>
        /// <param name="keys">CSV or array of keys to use for this keybinding</param>
        public void SetKeys(params Keys[] keys)
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
                if (ValidKeys.Count == 0 || InputManager.lockInputForOneFrame) { return false; }
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
                if (ValidKeys.Count == 0 || InputManager.lockInputForOneFrame) { return false; }
                foreach (Keys k in ValidKeys) { if (InputManager.Keyboard.KeyUp(k)) { return true; } }
                return false;
            }
        }
        /// <summary>
        /// Returns true on the first frame a key has been held down, as well as after passing a threshold (think holding down a letter in a text editor).
        /// </summary>
        public bool DownOrHeld
        {
            get
            {
                return Down || Held;
            }
        }
        /// <summary>
        /// Returns true if the key has been held down for a specified number of frames (InputManager.keybindHeldMilliRepeatDelay)
        /// and meets the held-down repeat rate (InputManager.keybindHeldMilliRepeatRate)
        /// </summary>
        public bool Held {
            get
            {
                if (ValidKeys.Count == 0 || InputManager.lockInputForOneFrame) { return false; }
                bool incCounter = false; // flag to make sure 
                int difference = InputManager._gameTime.ElapsedGameTime.Milliseconds;
                int milliDelay = InputManager.keybindHeldMilliRepeatDelay;
                int milliRate = InputManager.keybindHeldMilliRepeatRate;

                foreach (Keys k in ValidKeys) {
                    if (InputManager.Keyboard.KeyHeld(k)) {
                        // only increase the delay if the key is actually held down, but only once per keybind check
                        // (we don't want to double up if we hold down two keys that are the same keybind)
                        if (!incCounter) {
                            heldBeginDelay += difference;
                            incCounter = true;
                            // if we've held the key long enough
                            if (heldBeginDelay >= milliDelay) {
                                // check if we've met the repeat time (it starts at 0 so it'll always activate right away when the delay threshold is crossed)
                                heldRepeatDelay -= difference;
                                // if the repeat delay has reached 0 then reset timer and return true for held
                                if (heldRepeatDelay <= 0) { heldRepeatDelay = milliRate; return true; }
                            }
                        }
                    }
                }
                // ..if the key isn't even held down, reset hold timer variables
                if (!incCounter) { heldBeginDelay = 0; heldRepeatDelay = 0; }
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
                if (ValidKeys.Count == 0 || InputManager.lockInputForOneFrame) { return false; }
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
        public void Reset()
        {
        }
        public void ClearStates()
        {
            _oldState = default(KeyboardState);
            _newState = default(KeyboardState);
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
            _MouseClickLoc[0] = _MouseClickLoc[1] = _RightMouseClickLoc[0] = _RightMouseClickLoc[1] = new Rectangle(-1, -1, 1, 1);

            _oldState = _newState;
            _newState = Mouse.GetState();

            if (InWindow())
            {
                if (MouseDown()) { coordsMouseClickDown = MouseRectangle(Coords); }
                else if (MouseUp() && coordsMouseClickDown.X != -1) { _MouseClickLoc[0] = coordsMouseClickDown; _MouseClickLoc[1] = MouseRectangle(); coordsMouseClickDown.Location = new Point(-1); }

                if (RightMouseDown()) { coordsRightMouseClickDown = MouseRectangle(Coords); }
                else if (RightMouseUp() && coordsRightMouseClickDown.X != -1) { _RightMouseClickLoc[0] = coordsRightMouseClickDown; _RightMouseClickLoc[1] = MouseRectangle(); coordsRightMouseClickDown.Location = new Point(-1); }
            }
        }
        public void Reset()
        {
            coordsMouseClickDown = coordsRightMouseClickDown = _MouseClickLoc[0] = _MouseClickLoc[1] =
                _RightMouseClickLoc[0] = _RightMouseClickLoc[1] = new Rectangle(-1, -1, 1, 1);
        }
        public void ClearStates()
        {
            _oldState = default(MouseState);
            _newState = default(MouseState);
        }
        private Rectangle[] _MouseClickLoc = new Rectangle[2];
        private Rectangle[] _RightMouseClickLoc = new Rectangle[2];
        public Rectangle coordsMouseClickDown = new Rectangle(-1, -1, 1, 1);
        public Rectangle coordsRightMouseClickDown = new Rectangle(-1, -1, 1, 1);
        /// <summary>
        /// Returns true on the first frame that the left mouse button is held down.
        /// </summary>
        public bool MouseDown() { return InWindow() && _oldState.LeftButton == ButtonState.Released && _newState.LeftButton == ButtonState.Pressed; }
        /// <summary>
        /// Returns true on the first frame that the left mouse button is released.
        /// </summary>
        public bool MouseUp() { return InWindow() && _oldState.LeftButton == ButtonState.Pressed && _newState.LeftButton == ButtonState.Released; }
        /// <summary>
        /// Returns true during the second and on frame that the left mouse button is held down.
        /// </summary>
        public bool MouseHeld() { return InWindow() && _oldState.LeftButton == ButtonState.Pressed && _newState.LeftButton == ButtonState.Pressed; }
        /// <summary>
        /// Returns true if the left mouse button is held down at all.
        /// </summary>
        public bool IsMousePressed() { return InWindow() && _newState.LeftButton == ButtonState.Pressed; }
        /// <summary>
        /// Returns true if both left MouseDown and MouseUp are within a specified rectangle.
        /// </summary>
        public bool MouseClick(Rectangle r) { return InWindow() && _MouseClickLoc[0].X != -1 && r.Intersects(_MouseClickLoc[0]) && r.Intersects(_MouseClickLoc[1]); }

        /// <summary>
        /// Returns true on the first frame that the right mouse button is held down.
        /// </summary>
        public bool RightMouseDown() { return InWindow() && _oldState.RightButton == ButtonState.Released && _newState.RightButton == ButtonState.Pressed; }
        /// <summary>
        /// Returns true on the first frame that the right mouse button is released.
        /// </summary>
        public bool RightMouseUp() { return InWindow() && _oldState.RightButton == ButtonState.Pressed && _newState.RightButton == ButtonState.Released; }
        /// <summary>
        /// Returns true during the second and on frame that the right mouse button is held down.
        /// </summary>
        public bool RightMouseHeld() { return InWindow() && _oldState.RightButton == ButtonState.Pressed && _newState.RightButton == ButtonState.Pressed; }
        /// <summary>
        /// Returns true if the right mouse button is held down at all.
        /// </summary>
        public bool IsRightMousePressed() { return InWindow() && _newState.RightButton == ButtonState.Pressed; }
        /// <summary>
        /// Returns true if both right MouseDown and MouseUp are within a specified rectangle.
        /// </summary>
        public bool RightMouseClick(Rectangle r) { return InWindow() && _RightMouseClickLoc[0].X != -1 && r.Intersects(_RightMouseClickLoc[0]) && r.Intersects(_RightMouseClickLoc[1]); }

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
        public bool MouseHover(Rectangle r) { return MouseHover(r, _newState.X, _newState.Y); }

        /// <summary>
        /// Returns true if a point at coordinates X,Y intersects a rectangle.
        /// </summary>
        /// <param name="x">Defaults to mouse current state x.</param>
        /// <param name="y">Defaults to mouse current state y.</param>
        private bool MouseHover(Rectangle r, int? x = null, int? y = null)
        {
            if (x == null) { x = _newState.X; }
            if (y == null) { y = _newState.Y; }
            Rectangle mouseRec = new Rectangle((int)x, (int)y, 1, 1);
            return r.Intersects(mouseRec) && Main.graphics.GraphicsDevice.Viewport.Bounds.Contains(mouseRec);
        }
        /// <summary>
        /// Returns the rectangle representing the mouse cursor location.
        /// </summary>
        private Rectangle MouseRectangle() { return MouseRectangle(Coords); }
        /// <summary>
        /// Returns a 1x1 rectangle representing the vector x/y location.
        /// </summary>
        private Rectangle MouseRectangle(Vector2 v) { return MouseRectangle(v.ToPoint()); }
        /// <summary>
        /// Returns a 1x1 rectangle representing the point x/y location.
        /// </summary>
        private Rectangle MouseRectangle(Point p) { return new Rectangle(p, new Point(1)); }

        /// <summary>
        /// Returns if the mouse is within the game window.
        /// </summary>
        /// <returns></returns>
        public bool InWindow() { return Main.graphics.GraphicsDevice.Viewport.Bounds.Contains(MouseRectangle()); }
    }
}