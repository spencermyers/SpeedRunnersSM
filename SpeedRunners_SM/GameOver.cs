using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpeedRunners_SM
{
    public class Gameover : Sprite
    {
        private Vector2 Velocity;

        public Gameover(Texture2D image, Vector2 position, Color color, Vector2 velocity) : base(image, position, color)
        {
            Velocity = -velocity;

        }
        public void Update(GameTime gametime)
        {
            Position -= Velocity;
        }
    }
}