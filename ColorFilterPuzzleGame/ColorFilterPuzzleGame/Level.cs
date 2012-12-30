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
        private Platform[] platforms;
        private Door goal;
        private Player thePlayer;

        public Level(Texture2D background, Platform[] platform, Door door, Player p, Vector2 v)
        {
            Background = background;
            platforms = platform;
            goal = door;
            thePlayer = p;
            thePlayer.Location = v;
        }
        public void Initialize()
        {

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
        }
    }
}