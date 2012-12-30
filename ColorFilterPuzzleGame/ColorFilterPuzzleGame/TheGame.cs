using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;



namespace ColorFilterPuzzleGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class TheGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Level[] levels;
        private int currentLevel;

        private Level theLevel;
        Player thePlayer;
        private Door end;
        private Platform[] platforms;


        public TheGame()
        {
            currentLevel = 0;
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 768;
            graphics.PreferredBackBufferWidth = 1366;
            Content.RootDirectory = "Content";
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

            platforms = new Platform[3];
            platforms[0] = new Platform(Content.Load<Texture2D>("Platform2"), 10, 20);
            platforms[1] = new Platform(Content.Load<Texture2D>("Platform2"), 100, 200);
            platforms[2] = new Platform(Content.Load<Texture2D>("Platform2"), 500, 500);
            end = new Door(Content.Load<Texture2D>("Door"), 1300, 350);

            thePlayer = new Player(Content.Load<Texture2D>("Player"), new Vector2(600, 200));
            theLevel = new Level(Content.Load<Texture2D>("space"), platforms, end, thePlayer);      

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            thePlayer.Update(platforms);
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.M))
            {
                //Platform[] levelTwoPlatforms = new Platform[3];
                platforms[0] = new Platform(Content.Load<Texture2D>("Platform2"), 70, 30);
                platforms[1] = new Platform(Content.Load<Texture2D>("Platform2"), 200, 150);
                platforms[2] = new Platform(Content.Load<Texture2D>("Platform2"), 250, 400);
                Door twoEnd = new Door(Content.Load<Texture2D>("Door"), 1300, 100);
                theLevel = new Level(Content.Load<Texture2D>("stars"), platforms, twoEnd, thePlayer, new Vector2(400, 400));
            }
            if(keyState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            theLevel.Draw(spriteBatch);
            thePlayer.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}