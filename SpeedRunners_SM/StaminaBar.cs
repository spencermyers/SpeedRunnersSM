using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedRunners_SM
{
    public class StaminaBar : Sprite
    {
        Vector2 scaleCase;
        StaminaBar staminaBar;
        Vector2 scaleFiller;
        float rotate;
        float layerDepth;
        Rectangle caseSourceRectangle;
        Rectangle fillerSourceRectangle;
        Vector2 origin;
        Texture2D fillerTexture;
        Texture2D caseTexture;
        SpriteEffects effects;
        Color color;
        private object caseSourecRectangle;
        private Texture2D texture2D1;
        private Texture2D texture2D2;
        private Vector2 vector2;
        private Rectangle rectangle;
        public float staminaPercentage = 100;

        public Vector2 Scale
        {
            get
            {
                return scaleFiller;
            }
            set
            {
                scaleFiller = value;
            }

        }

        public StaminaBar(Texture2D caseTexture, Texture2D fillerTexture, Vector2 position, Vector2 origin, Color color, SpriteEffects effects, float layerDepth, float rotate, Vector2 scale)
            :base (caseTexture, position, color)
        {
            this.caseTexture = caseTexture;
            this.scaleCase = new Vector2(1.0f);
            this.scaleFiller = scale;
            this.rotate = rotate; 
            this.layerDepth = layerDepth;
            this.origin = origin;
            this.fillerTexture = fillerTexture;
            this.effects = effects;
            this.color = color;
            this.fillerTexture = fillerTexture;

            caseSourceRectangle = new Rectangle(0, 0, caseTexture.Width, caseTexture.Height);
            fillerSourceRectangle = new Rectangle(0, 0, fillerTexture.Width, fillerTexture.Height);

        }

        
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(caseTexture, position, caseSourceRectangle, color, rotate, origin, scaleCase, effects, layerDepth);
            //spriteBatch.Draw(fillerTexture, position, SourceRectangle, color, rotate, origin, scaleStamina, effects, layerDepth);
            spriteBatch.Draw(fillerTexture, position, fillerSourceRectangle, color, rotate, origin, new Vector2(staminaPercentage / 100f, 1.0f), effects, layerDepth);
        }

    }
}