using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;




namespace ColorFilterPuzzleGame
{
    class Player
    {
        public const float GRAVITY = 7;
        public const float JUMP_SPEED = -7;
        public const float MAX_JUMP_HEIGHT = 320;
        public const int WINDOW_HEIGHT = 768;

        public Texture2D Image { get; private set; }
        public Vector2 Location { get; private set; }
        // Derived Properties
        public int Width { get { return Image.Width; } }
        public int Height { get { return Image.Height; } }
        public int Right { get { return (int)(Location.X + (float)(Width / 2)); } }
        public int Left { get { return (int)(Location.X - (float)(Width / 2)); } }
        public int Top { get { return (int)(Location.Y - (float)(Height / 2)); } }
        public int Bottom { get { return (int)(Location.Y + (float)(Height / 2)); } }

        // Atlas info
        private int Cols { get; set; }
        private int curFrame;

        // Jumping info

        private float jumpTravel;
        private bool jumping;


        public Player(Texture2D texture, Vector2 location)
        {
            Cols = 6;
            curFrame = 0;
            Location = location;
            Image = texture;
            jumpTravel = 0;
            jumping = false;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Image.Width / Cols;
            int height = Image.Height;
            int column = curFrame % Cols;
            Rectangle sourceRectangle = new Rectangle(width * column, height, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Image, Location, sourceRectangle, Color.White, (float)0, new Vector2(Width / 2, Height / 2), 1.0f, SpriteEffects.None, 1);
            spriteBatch.End();
        }


        public void Update(Platform[] risks)
        {
            KeyboardState keyState = Keyboard.GetState();

            Vector2 v = new Vector2(0, GRAVITY);
            Platform theCollision;
            ImmediateCollisions(risks, v, out theCollision);
            if (theCollision == null)
            {
                // No coming collisions
            }
            else
            {
                v = new Vector2(0, 0);
                if (v.Y == 0) jumpTravel = 0;
            }

            // Overrides gravity
            if (keyState.IsKeyDown(Keys.Up) && !jumping)
            {
                // Vertical-Above Collision Here
                if (jumpTravel >= MAX_JUMP_HEIGHT) jumping = true;
                if (jumpTravel < MAX_JUMP_HEIGHT)
                {
                    v = new Vector2(0, JUMP_SPEED);
                    ImmediateCollisions(risks, v, out theCollision);
                    if (theCollision == null)
                    {
                        // No coming collisions
                    }
                    else
                    {
                        v = new Vector2(0, 0);
                        jumpTravel = MAX_JUMP_HEIGHT;
                    }
                    jumpTravel += Math.Abs(JUMP_SPEED);
                }
            }

            if (keyState.IsKeyUp(Keys.Up))
            {
                jumping = false;
                jumpTravel = MAX_JUMP_HEIGHT;
            }            

            if (keyState.IsKeyDown(Keys.Left))
            {
                // Horizontal-Left Collision Here
                float dx = 5;
                v = new Vector2(v.X - dx, v.Y);
                ImmediateCollisions(risks, v, out theCollision);
                if (theCollision == null)
                {

                }
                else
                {
                    v = new Vector2(v.X + dx, v.Y);
                }
                curFrame++;
                if (curFrame == Cols) curFrame = 0;
            }
            else if (keyState.IsKeyDown(Keys.Right))
            {
                // Horizontal-Right Collision Here
                float dx = 5;
                v = new Vector2(v.X + dx, v.Y);
                ImmediateCollisions(risks, v, out theCollision);
                if (theCollision == null)
                {

                }
                else
                {
                    v = new Vector2(v.X - dx, v.Y);
                }
                curFrame++;
                if (curFrame == Cols) curFrame = 0;
            }

            Location = new Vector2(Location.X + v.X, Location.Y + v.Y);

        }

        private void ImmediateCollisions(Platform[] risks, Vector2 v, out Platform theCollision)
        {
            theCollision = null;
            foreach (Platform risk in risks)
            {

                if((new Rectangle((int)(Left + v.X), (int)(Top + v.Y), Width, Height))
                    .Intersects(new Rectangle((int)risk.X, (int)risk.Y, risk.Width, risk.Height))) 
                {
                    theCollision = risk;
                }

            }
        }
    }
}
