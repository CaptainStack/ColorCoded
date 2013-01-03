using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ColorFilterPuzzleGame
{
    public class Door
    {
        private readonly Texture2D myDoor;
        private int X;
        private int Y;

        public Door(Texture2D door, int xPosition, int yPosition)
        {
            myDoor = door;
            X = xPosition;
            Y = yPosition;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            spriteBatch.Draw(myDoor, new Rectangle(X, Y, 64, 64), Color.White);
            //spriteBatch.End();

        }
        public bool ImmediateCollision(Player thePlayer)
        {
            return (new Rectangle(X, Y, 64, 64)).Intersects
                (
                    new Rectangle((int)thePlayer.Left, (int)thePlayer.Top, thePlayer.AtlasWidth, thePlayer.AtlasHeight)
                );
        }
    }
}