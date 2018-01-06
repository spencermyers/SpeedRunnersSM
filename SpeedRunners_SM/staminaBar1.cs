using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpeedRunners_SM
{
    internal class staminaBar : StaminaBar
    {
        private SpriteEffects effects;
        private float layerDepth;
        private Vector2 origin;
        private Rectangle rectangle;
        private float rotate;
        private Texture2D texture2D1;
        private Texture2D texture2D2;
        private Vector2 position;

        public staminaBar (Texture2D texture2D1, Texture2D texture2D2, Vector2 position, Vector2 origin, Color color, Rectangle rectangle, SpriteEffects effects, float layerDepth, float rotate, Vector2 scale)
            : base (texture2D1, texture2D2, position, origin, color, effects, layerDepth, rotate, scale)
        {
            this.texture2D1 = texture2D1;
            this.texture2D2 = texture2D2;
            this.position = position;
            this.origin = origin;
            this.color = color;
            this.rectangle = rectangle;
            this.effects = effects;
            this.layerDepth = layerDepth;
            this.rotate = rotate;
            Scale = scale;
        }
    }
}