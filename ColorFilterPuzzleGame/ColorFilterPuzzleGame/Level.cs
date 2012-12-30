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
<<<<<<< HEAD
        private Player myPlayer;

        //Test Comment
        public Level(Texture2D background, Platform[] platform, Door door, Player p)
=======
        private Player thePlayer;

        public Level(Texture2D background, Platform[] platform, Door door, Player p, Vector2 v)
>>>>>>> bbe3f193d1c4a64b8a3debcfc3bc602c9ed9d0ab
        {
            Background = background;
            platforms = platform;
            goal = door;
<<<<<<< HEAD
            myPlayer = p;
=======
            thePlayer = p;
            thePlayer.Location = v;
>>>>>>> bbe3f193d1c4a64b8a3debcfc3bc602c9ed9d0ab
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