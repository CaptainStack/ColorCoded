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
            thePlayer = new Player(Content.Load<Texture2D>("PlayerSprite"), new Vector2(0, 0));

            //Level One
            Platform[] onePlatforms = new Platform[6];
            onePlatforms[0] = new Platform(Content.Load<Texture2D>("Platform2"), 0, 500, false);
            onePlatforms[1] = new Platform(Content.Load<Texture2D>("Platform2"), 300, 400, true);
            onePlatforms[2] = new Platform(Content.Load<Texture2D>("Platform2"), 500, 400, true);
            onePlatforms[3] = new Platform(Content.Load<Texture2D>("Platform2"), 750, 400, true);
            onePlatforms[4] = new Platform(Content.Load<Texture2D>("Platform2"), 1000, 300, true);
            onePlatforms[5] = new Platform(Content.Load<Texture2D>("Platform2"), 1200, 150, false);
            levels[0] = new Level(Content.Load<Texture2D>("background1"), onePlatforms, new Door(Content.Load<Texture2D>("Door"), 1300, 50), thePlayer, new Vector2(200, 200));
            
            //Level Two
            Platform[] twoPlatforms = new Platform[10];
            twoPlatforms[0] = new Platform(Content.Load<Texture2D>("Platform2"), 0, 500, false);

            twoPlatforms[1] = new Platform(Content.Load<Texture2D>("Platform2"), 300, 400, true);
            twoPlatforms[2] = new Platform(Content.Load<Texture2D>("Platform2"), 500, 600, true);
            twoPlatforms[3] = new Platform(Content.Load<Texture2D>("Platform2"), 700, 450, true);

            twoPlatforms[4] = new Platform(Content.Load<Texture2D>("Platform2"), 500, 200, true);
            twoPlatforms[5] = new Platform(Content.Load<Texture2D>("Platform2"), 500, 300, true);
            twoPlatforms[6] = new Platform(Content.Load<Texture2D>("Platform2"), 500, 100, true);

            twoPlatforms[7] = new Platform(Content.Load<Texture2D>("Platform2"), 850, 750, true);
            twoPlatforms[8] = new Platform(Content.Load<Texture2D>("Platform2"), 1000, 300, true);

            twoPlatforms[9] = new Platform(Content.Load<Texture2D>("Platform2"), 1300, 200, false);
            levels[1] = new Level(Content.Load<Texture2D>("stars"), twoPlatforms, new Door(Content.Load<Texture2D>("Door"), 1300, 100), thePlayer, new Vector2(250, 382));
            
            theLevel = levels[0];
            end = levels[0].goal;
            platforms = levels[0].platforms;
            filterBlack();
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
                SoundEffect soundEffect;
                soundEffect = Content.Load<SoundEffect>("Change9");
                // Play the sound
                soundEffect.Play();
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
                foreach (Platform x in platforms)
                {
                    if (x.isRemovable)
                    {
                        x.setX(x.permX);
                        x.setY(x.permY);
                        SoundEffect soundEffect;
                        soundEffect = Content.Load<SoundEffect>("Change4");
                        // Play the sound
                        soundEffect.Play();
                    }
                }
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
                if (p.isRemovable)
                {
                    p.setX(-100);
                    p.setY(-100);

                }
            }
        }
    }
}