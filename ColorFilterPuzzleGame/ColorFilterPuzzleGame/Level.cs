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
        public Door door;
        public Player player;
        public Vector2 playerLocation;

        public Level(Texture2D background, Platform[] platform, Door d, Player p)
        {
            Background = background;
            platforms = platform;
            door = d;
            player = p;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Background, new Rectangle(0, 0, 1280, 768), Color.White);

            door.Draw(spriteBatch);
            foreach (Platform x in platforms)
            {
                x.Draw(spriteBatch);
            }            
            player.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}