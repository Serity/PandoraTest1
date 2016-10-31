using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace PandoraTest1.Managers
{
    public class OLDInputManager
    {
        private static KeyboardState oldKeyboardState;
        private static KeyboardState newKeyboardState;
        private static MouseState oldMouseState;
        private static MouseState newMouseState;
        private static int _currentScrollWheel = 0;
        private static Vector2 oldMouseCoords = new Vector2();

        public static int ScrollWheel = 0;
        public static Vector2 MouseCoords = new Vector2();

        public static void Update(GameTime gameTime)
        {
            newKeyboardState = Keyboard.GetState();
            newMouseState = Mouse.GetState();
            MouseCoords = new Vector2(newMouseState.X, newMouseState.Y);

            ScrollWheel = newMouseState.ScrollWheelValue - _currentScrollWheel;
            _currentScrollWheel += ScrollWheel;

            StateManager.currentState.Update(gameTime);

            oldKeyboardState = newKeyboardState;
            oldMouseState = newMouseState;
            oldMouseCoords = MouseCoords;
        }
        public static bool IsKeyPressed(Keys key) { return oldKeyboardState.IsKeyUp(key) && newKeyboardState.IsKeyDown(key); }
        public static bool IsKeyReleased(Keys key) { return oldKeyboardState.IsKeyDown(key) && newKeyboardState.IsKeyUp(key); }
        public static bool IsKeyDown(Keys key) { return newKeyboardState.IsKeyDown(key); }
        public static bool IsKeyUp(Keys key) { return newKeyboardState.IsKeyUp(key); }

        public static bool IsLMBPressed() { return oldMouseState.LeftButton == ButtonState.Released && newMouseState.LeftButton == ButtonState.Pressed; }
        public static bool IsLMBReleased() { return oldMouseState.LeftButton == ButtonState.Pressed && newMouseState.LeftButton == ButtonState.Released; }
        public static bool IsLMBDown() { return newMouseState.LeftButton == ButtonState.Pressed; }
        public static bool IsLMBUp() { return newMouseState.LeftButton == ButtonState.Released; }

        public static bool IsRMBPressed() { return oldMouseState.RightButton == ButtonState.Released && newMouseState.RightButton == ButtonState.Pressed; }
        public static bool IsRMBReleased() { return oldMouseState.RightButton == ButtonState.Pressed && newMouseState.RightButton == ButtonState.Released; }
        public static bool IsRMBDown() { return newMouseState.RightButton == ButtonState.Pressed; }
        public static bool IsRMBUp() { return newMouseState.RightButton == ButtonState.Released; }

        public static bool IsMMBPressed() { return oldMouseState.MiddleButton == ButtonState.Released && newMouseState.MiddleButton == ButtonState.Pressed; }
        public static bool IsMMBReleased() { return oldMouseState.MiddleButton == ButtonState.Pressed && newMouseState.MiddleButton == ButtonState.Released; }
        public static bool IsMMBDown() { return newMouseState.MiddleButton == ButtonState.Pressed; }
        public static bool IsMMBUp() { return newMouseState.MiddleButton == ButtonState.Released; }




    }
}
