using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ColorFilterPuzzleGame
{
    public class Door
    {
        private Texture2D myDoor { get; set; }
        private int X;
        private int Y;

        public Door(Texture2D door, int xPosition, int yPosition)
        {
            myDoor = door;
            X = xPosition;
            Y = yPosition;
        }
        public void Initialize()
        {

        }

        public void draw(SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.Draw(myDoor, new Rectangle(X, Y, 60, 100), Color.Red);
            sprite.End();

        }
        public bool ImmediateCollision(Player thePlayer)
        {
            return (new Rectangle(X, Y, 64, 64))
                .Intersects(new Rectangle((int)thePlayer.Left, (int)thePlayer.Top, thePlayer.AtlasWidth, thePlayer.AtlasHeight));
        }
    }
}
