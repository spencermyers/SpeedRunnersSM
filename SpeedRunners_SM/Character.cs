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
    class Character : Sprite
    {
        private Texture2D thunderBolt;

        public Character(Texture2D image, Vector2 position, Color color) : base (image, position, color)
        {

        }

        public Character(Texture2D image, Vector2 position, Color color, Texture2D thunderBolt) : this(image, position, color)
        {
            this.thunderBolt = thunderBolt;
        }
    }
}
