using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ColorFilterPuzzleGame
{
    public class Level
    {
        private Texture2D Background { get; set; }
        public Platform[] platforms;
        public Door goal;
        private Player thePlayer;
        public Vector2 playerLocation;

        public Level(Texture2D background, Platform[] platform, Door door, Player p, Vector2 v)
        {
            Background = background;
            platforms = platform;
            goal = door;
            thePlayer = p;
            playerLocation = v;
            thePlayer.Location = v;
        }
        public void Start(Vector2 v)
        {
            thePlayer.Location = v;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();

            spriteBatch.Draw(Background, new Rectangle(0, 0, 1366, 768), Color.White);


            spriteBatch.End();
            foreach (Platform x in platforms)
            {
                x.Draw(spriteBatch);
            }
            goal.draw(spriteBatch);
            thePlayer.Draw(spriteBatch);
        }
    }
}