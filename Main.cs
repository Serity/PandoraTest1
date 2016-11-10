
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PandoraTest1.Managers;
using PandoraTest1.Entities;
using PandoraTest1.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace PandoraTest1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static Main instance;
        
        public static List<Tileset> tilesets = new List<Tileset>();

        public static MapEntity playerMapEntity;

        public static Texture2D texturePixel;
        public static Texture2D texturePlayer;

        public static int GameWidth;
        public static int GameHeight;

        public Main()
        {
            instance = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsFixedTimeStep = false;
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public static Actors.Actor aPandora;
        public static SpriteFont arialFont;
        public static List<Spritesheet> spritesheets = new List<Spritesheet>();
        public int curSpriteSheet = 0;
        public static Texture2D LoadTexture(string path)
        {
            return Main.instance.Content.Load<Texture2D>(path);
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GameWidth = graphics.GraphicsDevice.Viewport.Width;
            GameHeight = graphics.GraphicsDevice.Viewport.Height;

            arialFont = Content.Load<SpriteFont>("Arial");

            //thanks to Ken on StackExchange http://gamedev.stackexchange.com/questions/44015/
            texturePixel = new Texture2D(GraphicsDevice, 1, 1);
            texturePixel.SetData<Color>(new Color[] { Color.White });

            // TODO: use this.Content to load your game content here
            Tileset t = new Tilesets.Town16Test();
            t.Initialize(LoadTexture(t.texturePath));
            tilesets.Add(t);


            StateManager.currentState = StateManager.GetState(StateID.MainMenu);
            MapManager.currentMap = MapManager.GetMap(MapID.Town);

            texturePlayer = LoadTexture("test_female1");

            playerMapEntity = new Entities.MapEntity();
            MapManager.currentMap.entities.Add(playerMapEntity);

            MapEntity randomNPC = new Entities.MapEntity();
            randomNPC.X = 1;
            randomNPC.Y = 0;
            randomNPC.InteractAction = delegate (MapEntity user) { randomNPC.MoveRight(); };

            MapManager.currentMap.entities.Add(randomNPC);

            aPandora = new Actors.PartyActor();
            aPandora.name = "Pandora";
            aPandora.health.Set(300);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public static int v = 64;
        protected override void Update(GameTime gameTime)
        {

            InputManager.Update(gameTime); // calls GameState.Update() after updating all kb/m states

            StateManager.currentState.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (!InputManager.blockedInput) { GraphicsDevice.Clear(Color.CornflowerBlue); }
            else { GraphicsDevice.Clear(Color.Maroon); }


            spriteBatch.Begin();
           // spriteBatch.Begin();
            try
            {
                StateManager.currentState.Draw(gameTime);
                Main.spriteBatch.DrawString(Main.arialFont, Main.aPandora.name + "  " + Main.aPandora.health.ToString(), new Vector2(300), Color.Red);
                Main.spriteBatch.DrawString(Main.arialFont, StateManager.currentState.ToString() + "/" + StateManager.stateStack.Count +"/" + StateManager.stateStack.ElementAt(0).ToString(), new Vector2(300,320), Color.Red);

                Main.spriteBatch.DrawString(Main.arialFont, InputManager.Mouse._newState.X + "/" + InputManager.Mouse._newState.Y + "/" + InputManager.Mouse._oldState.X + "/" + InputManager.Mouse._oldState.Y, new Vector2(300, 420), Color.Red);
                //Texture2D t = ;
                // TODO: Add your drawing code here
                //spriteBatch.Draw(texturePlayer, Vector2.Zero, new Rectangle(256, v, 64, 64), Color.White, 0, Vector2.Zero, 16.0f/64.0f, SpriteEffects.None, 0);
                base.Draw(gameTime);
                
            }
            finally
            {
                spriteBatch.End();
            }
        }
    }
}
