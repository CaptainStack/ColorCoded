﻿using System;
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

        public Platform(Texture2D platform, int xPosition, int yPosition)
        {
            ThisPlatform = platform;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public void Initialize()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();

            spriteBatch.Draw(ThisPlatform, new Rectangle(xPosition, yPosition, 201, 57), Color.White);

            spriteBatch.End();

        }

    }
}