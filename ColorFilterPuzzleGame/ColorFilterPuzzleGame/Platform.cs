using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ColorFilterPuzzleGame
{
    public class Platform
    {
        private Texture2D ThisPlatform { get; set; }
        private int xPosition;
        private int yPosition;
        public int permX;
        public int permY;
        public bool isRemovable;

        public float X
        {
            get { return (float)xPosition; }
        }

        public float Y
        {
            get { return (float)yPosition; }
        }

        public int Width
        {
            get { return ThisPlatform.Width; }
        }

        public int Height
        {
            get { return ThisPlatform.Height; }
        }

        public Platform(Texture2D platform, int xPosition, int yPosition, bool removable)
        {
            ThisPlatform = platform;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            permX = xPosition;
            permY = yPosition;
            isRemovable = removable;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isRemovable)
            {
                spriteBatch.Draw(ThisPlatform, new Rectangle(xPosition, yPosition, 201, 57), Color.Green);
            }
            else
            {
                spriteBatch.Draw(ThisPlatform, new Rectangle(xPosition, yPosition, 201, 57), Color.White);
            }
        }
        public void setX(int newX)
        {
            xPosition = newX;
        }
        public void setY(int newY)
        {
            yPosition = newY;
        }
    }
}