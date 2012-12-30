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
        private Player thePlayer;
        private Door end;
        private Platform[] platforms;
        private bool canIncrease;


        public TheGame()
        {
            levels = new Level[2];
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
            thePlayer = new Player(Content.Load<Texture2D>("PlayerSprite"), new Vector2(600, 200));
<<<<<<< HEAD

            //Level One
            Platform[] onePlatforms = new Platform[4];
            onePlatforms[0] = new Platform(Content.Load<Texture2D>("Platform2"), 50, 400);
            onePlatforms[1] = new Platform(Content.Load<Texture2D>("Platform2"), 250, 400);
            onePlatforms[2] = new Platform(Content.Load<Texture2D>("Platform2"), 500, 400);
            onePlatforms[3] = new Platform(Content.Load<Texture2D>("Platform2"), 750, 400);
            levels[0] = new Level(Content.Load<Texture2D>("space"), onePlatforms, new Door(Content.Load<Texture2D>("Door"), 1300, 350), thePlayer, new Vector2(600, 200));
            
            //Level Two
            Platform[] twoPlatforms = new Platform[3];
            twoPlatforms[0] = new Platform(Content.Load<Texture2D>("Platform2"), 1000, 700);
            twoPlatforms[1] = new Platform(Content.Load<Texture2D>("Platform2"), 900, 600);
            twoPlatforms[2] = new Platform(Content.Load<Texture2D>("Platform2"), 800, 500);
            levels[1] = new Level(Content.Load<Texture2D>("stars"), twoPlatforms, new Door(Content.Load<Texture2D>("Door"), 1300, 100), thePlayer, new Vector2(400, 100));
                        
            theLevel = levels[0];
            end = levels[0].goal;
            platforms = levels[0].platforms;
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
            thePlayer.Update(platforms);

            //Watch for the player to press E when on the door to advance to the next level
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.E))
            {
                if(end.ImmediateCollision(thePlayer)){                 
                    if (canIncrease)
                    {
                        currentLevel++;
                    }
                    canIncrease = false;
                    theLevel = levels[currentLevel];
                    thePlayer.Location = theLevel.playerLocation;
                    platforms = theLevel.platforms;
                    end = theLevel.goal;
                }
            }
            if (keyState.IsKeyUp(Keys.E))
            {
                canIncrease = true;
            }

            //Exit the game by pressing Escape
            if(keyState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            if (keyState.IsKeyDown(Keys.D1))
            {
                filterBlack();
            }
            if (keyState.IsKeyDown(Keys.D2))
            {
                platforms[0].setX(platforms[0].permX);
                platforms[1].setX(platforms[1].permX);
                platforms[2].setX(platforms[2].permX);
                platforms[3].setX(platforms[3].permX);

                platforms[0].setY(platforms[0].permY);
                platforms[1].setY(platforms[1].permY);
                platforms[2].setY(platforms[2].permY);
                platforms[3].setY(platforms[3].permY);
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
            base.Draw(gameTime);
        }

        public void filterBlack()
        {
            foreach (Platform p in platforms)
            {
                p.setX(-100);
                p.setY(-100);
            }
        }
    }
}