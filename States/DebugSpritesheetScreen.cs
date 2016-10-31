using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PandoraTest1.Managers;

namespace PandoraTest1.States
{
    public class DebugSpritesheetScreen : GameState
    {
        public Rectangle ExitGamePanel;
        public int index = 0;
        public DebugSpritesheetScreen()
        {
            input = new Input.IHDebugSprite();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Main.graphics.GraphicsDevice.Clear(Color.Navy);
            KeyValuePair<string, Rectangle> kvp = Main.spritesheets[Main.instance.curSpriteSheet].sprites.ElementAt(index);
            Main.spriteBatch.DrawString(Main.arialFont, Main.spritesheets[Main.instance.curSpriteSheet].path, new Vector2(300, 12), Color.White);
            Main.spriteBatch.DrawString(Main.arialFont, index + "["+ (Main.spritesheets[Main.instance.curSpriteSheet].sprites.Count-1)+"]"+"/" + kvp.Key, new Vector2(300, 25), Color.White);
            Main.spriteBatch.Draw(Main.spritesheets[Main.instance.curSpriteSheet].sheet, new Rectangle(300, 50,25,25), kvp.Value, Color.White);
        }
        public void ChangeIndex(int i)
        {
            index += i;
            if (index < 0) { index = Main.spritesheets[Main.instance.curSpriteSheet].sprites.Count - 1; }
            else if (index >= Main.spritesheets[Main.instance.curSpriteSheet].sprites.Count) { index = 0; }
        }
        public void ChangeSheetIndex(int i)
        {
            index = 0;
            Main.instance.curSpriteSheet += i;
            if (Main.instance.curSpriteSheet < 0) { Main.instance.curSpriteSheet = Main.spritesheets.Count - 1; }
            else if (Main.instance.curSpriteSheet >= Main.spritesheets.Count) { Main.instance.curSpriteSheet = 0; }
        }
    }
}
