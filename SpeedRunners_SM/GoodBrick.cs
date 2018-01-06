using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpeedRunners_SM
{
    public class GoodBrick : Sprite
    {
        private Vector2 Velocity;
        public Rectangle obHitbox
        {
            get { return new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height); }
        }

        public GoodBrick(Texture2D image, Vector2 position, Color color, Vector2 velocity) : base(image, position, color)
        {
            Velocity = -velocity;
            

        }
        public void Update(GameTime gametime)
        {
            Position -= Velocity;
        }
    }
}