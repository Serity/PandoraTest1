﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PandoraTest1.Managers;
using PandoraTest1.MapEntities;
using System.Collections.Generic;

namespace PandoraTest1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        public static float angle = 0.0f;
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        public static States.GameState currentInterface;

        public static List<Tileset> tilesets = new List<Tileset>();

        public static MapEntity playerMapEntity;

        public static Texture2D texturePixel;
        public static Texture2D texturePlayer;

        public Main()
        {
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

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            Tileset t = new Tilesets.Town16Test();
            t.Initialize(Content.Load<Texture2D>(t.texturePath));
            tilesets.Add(t);
            currentInterface = new States.MainMenu();

            //thanks to Ken on StackExchange http://gamedev.stackexchange.com/questions/44015/
            texturePixel = new Texture2D(GraphicsDevice, 1, 1);
            texturePixel.SetData<Color>(new Color[] { Color.White });


            texturePlayer = Content.Load<Texture2D>("test_female1.png");

            playerMapEntity = new MapEntities.MapEntity();
            States.MainMenu.town.entities.Add(playerMapEntity);

            MapEntity randomNPC = new MapEntities.MapEntity();
            randomNPC.X = 1;
            randomNPC.Y = 0;
            randomNPC.InteractAction = delegate (MapEntity user) { randomNPC.MoveRight(); };

            States.MainMenu.town.entities.Add(randomNPC);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            InputManager.Update(); // calls GameState.Update() after updating all kb/m states

            currentInterface.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);//.CornflowerBlue);
            spriteBatch.Begin();
            try
            {
                currentInterface.Draw(gameTime);
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
