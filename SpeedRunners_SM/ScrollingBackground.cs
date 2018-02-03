using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedRunners_SM
{
    class ScrollingBackground
    {
        Sprite[] background;
        int offset;
        int width;
        public ScrollingBackground(Texture2D texture)
        {
            width = texture.Width;
            background = new Sprite[3];
            background[0] = new Sprite(texture, Vector2.Zero, Color.White);
            background[1] = new Sprite(texture, new Vector2(width, 0), Color.White);
            background[2] = new Sprite(texture, Vector2.Zero, Color.White);
        }

        public ScrollingBackground()
        {
        }

        public void Update(int offset)
        {
            background[0].Position = new Vector2(+(offset % width), 0);
            background[1].Position = new Vector2(+(offset % width) + width, 0);
            background[2].Position = new Vector2(+(offset % width) + width + width, 0);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            background[0].Draw(spriteBatch);
            background[1].Draw(spriteBatch);
            background[2].Draw(spriteBatch);
        }
    }
}
