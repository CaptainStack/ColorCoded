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

        private Song song;

        private Level[] levels;
        private int currentLevelNumber;
        private Level currentLevel;

        private Player thePlayer;
        private Door end;
        private Platform[] platforms;
        private bool canIncrease;
        private bool isFiltered;
        private bool spacepress;


        public TheGame()
        {
            levels = new Level[4];
            currentLevelNumber = 0;
            Content.RootDirectory = "Content";
            isFiltered = false;
            spacepress = false;
            Initialize();
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
            if (graphics == null)
            {
                graphics = new GraphicsDeviceManager(this);
                graphics.PreferredBackBufferHeight = 768;
                graphics.PreferredBackBufferWidth = 1280;
                graphics.PreferMultiSampling = false;
                graphics.IsFullScreen = true;
            }
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //Play the background music on a loop
            song = Content.Load<Song>("Audio/SoundTrack");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            thePlayer = new Player(Content.Load<Texture2D>("Entities/PlayerSprite"), new Vector2(0, 0));

            //Tutorial
            Platform[] tutorialPlatforms = new Platform[9];
            tutorialPlatforms[0] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 0, 600, false);
            tutorialPlatforms[1] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 200, 600, false);
            tutorialPlatforms[2] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 400, 600, false);
            tutorialPlatforms[3] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 600, 600, false);
            tutorialPlatforms[4] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 800, 600, false);
            tutorialPlatforms[5] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 1000, 600, false);
            tutorialPlatforms[6] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 1200, 600, false);

            tutorialPlatforms[7] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 540, 480, true);
            tutorialPlatforms[8] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 1000, 150, true);

            Door tempDoor = new Door(Content.Load<Texture2D>("Entities/Door"), 1200, 536);
            Player tempPlayer = new Player(Content.Load<Texture2D>("Entities/PlayerSprite"), new Vector2(200, 445));
            levels[0] = new Level(Content.Load<Texture2D>("Backgrounds/TutorialBackground"), tutorialPlatforms, tempDoor, tempPlayer);

            //Level One
            Platform[] tempPlatforms = new Platform[6];
            tempPlatforms[0] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 0, 500, false);
            tempPlatforms[1] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 300, 400, true);
            tempPlatforms[2] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 500, 400, true);
            tempPlatforms[3] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 750, 400, true);
            tempPlatforms[4] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 1000, 300, true);
            tempPlatforms[5] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 1200, 150, false);
            tempDoor = new Door(Content.Load<Texture2D>("Entities/Door"), 1200, 86);
            tempPlayer = new Player(Content.Load<Texture2D>("Entities/PlayerSprite"), new Vector2(200, 445));
            levels[1] = new Level(Content.Load<Texture2D>("Backgrounds/background1"), tempPlatforms, tempDoor, tempPlayer);
            
            //Level Two
            Platform[] twoPlatforms = new Platform[10];
            twoPlatforms[0] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 0, 500, false);
            twoPlatforms[1] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 300, 400, true);
            twoPlatforms[2] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 500, 600, true);
            twoPlatforms[3] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 700, 450, true);
            twoPlatforms[4] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 500, 200, false);
            twoPlatforms[5] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 500, 300, false);
            twoPlatforms[6] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 500, 100, false);
            twoPlatforms[7] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 825, 700, true);
            twoPlatforms[8] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 950, 350, true);
            twoPlatforms[9] = new Platform(Content.Load<Texture2D>("Entities/Platform2"), 1200, 200, false);

            tempDoor = new Door(Content.Load<Texture2D>("Entities/Door"), 1200, 136);
            tempPlayer = new Player(Content.Load<Texture2D>("Entities/PlayerSprite"), new Vector2(250, 382));
            levels[2] = new Level(Content.Load<Texture2D>("Backgrounds/background2"), twoPlatforms, tempDoor, tempPlayer);
            
            //Victory Screen
            Platform[] threePlatforms = new Platform[0];
            tempDoor = new Door(Content.Load<Texture2D>("Entities/Door"), 2000, 100);
            tempPlayer = new Player(Content.Load<Texture2D>("Entities/PlayerSprite"), new Vector2(-500, 800));
            levels[3] = new Level(Content.Load<Texture2D>("Backgrounds/victory"), threePlatforms, tempDoor, tempPlayer);

            thePlayer = levels[0].player;
            currentLevel = levels[0];
            end = levels[0].door;
            platforms = levels[0].platforms;
            //filterBlack();
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
                        currentLevelNumber++;
                    }
                    canIncrease = false;
                    currentLevel = levels[currentLevelNumber];
                    thePlayer = currentLevel.player;
                    thePlayer.Location = currentLevel.player.Location;
                    platforms = currentLevel.platforms;
                    end = currentLevel.door;

                    // Play the sound effect
                    SoundEffect soundEffect;
                    soundEffect = Content.Load<SoundEffect>("Audio/Change9");                    
                    soundEffect.Play();
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
            if (keyState.IsKeyDown(Keys.Space) && spacepress == false)
            {
                spacepress = true;
                if (isFiltered)
                {
                    filterBlack();
                    isFiltered = false;
                }
                else
                {
                    foreach (Platform x in platforms)
                    {
                        if (x.isRemovable)
                        {
                            x.setX(x.permX);
                            x.setY(x.permY);

                        }
                    }
                    SoundEffect soundEffect;
                    soundEffect = Content.Load<SoundEffect>("Audio/Change4");
                    // Play the sound
                    soundEffect.Play();
                    isFiltered = true;
                }
            }
            if (keyState.IsKeyUp(Keys.Space))
            {
                spacepress = false;
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
            currentLevel.Draw(spriteBatch);
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