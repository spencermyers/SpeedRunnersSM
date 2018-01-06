using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SpeedRunners_SM
{
     public class Sprite
    {
        protected Texture2D image;
        protected Vector2 position;
        protected Color color;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public int Height
        {
            get { return image.Height; }
        }

        public int Width
        {
            get { return image.Width; }
        }

        public Rectangle Hitbox
        {
            get { return new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height); }
        }


        public Sprite(Texture2D image, Vector2 position, Color color)
        {
            this.image = image;
            this.position = position;
            this.color = color;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, position, color);
        }

        

        //public vivoid Update(GameTime gameTime)
        //{
        //}
    }
}
