using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpeedRunners_SM
{
    class ThunderBolt : Sprite
    {
        private Vector2 Velocity;
        public Rectangle Hitbox
        {
            get { return new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height); }
        }

        public ThunderBolt(Texture2D image, Vector2 position, Color color, Vector2 velocity) : base (image, position, color)
        {
            Velocity = velocity;
        }

        public ThunderBolt(Texture2D image, Vector2 position, Color color) : base(image, position, color)
        {
        }

        public void Update(GameTime gametime, Viewport Viewport)
        {
            Position += Velocity;
        }

        public void SetImage(Texture2D image)
        {
            this.image = image;
        }
    }
}
