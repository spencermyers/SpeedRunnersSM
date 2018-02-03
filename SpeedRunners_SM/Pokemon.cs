 using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedRunners_SM
{
    class Pokemon : Character
    {
        public PokemonState pokemonState;
        float rotation;
        Vector2 origin;
        public Texture2D attackTexture;
        Texture2D deadTexture;
        float yVelocity;
        bool onGround;
        bool initialJump;
        float gravity = 0.79f;
        int ground;
        public List<ThunderBolt> thunderBolts;
        TimeSpan elapsedTime;
        TimeSpan maxJumpTime;
        public int ShotsAmount = 5;

        public Pokemon(Texture2D image, Vector2 position, Color color, Texture2D attackTexture, Texture2D deadTexture) : base(image, position, color)
        {

            rotation = 0;
            origin = new Vector2(image.Width, image.Height) / 2;
            ground = (int)(position.Y + image.Height);
            thunderBolts = new List<ThunderBolt>();
            this.attackTexture = attackTexture;
            pokemonState = PokemonState.alive;
            this.deadTexture = deadTexture;
            initialJump = false;
            maxJumpTime = TimeSpan.FromMilliseconds(10000000);
        }


        public void Update(GameTime gametime, KeyboardState ks, MouseState ms, MouseState prevMs, Viewport Viewport)
        {
            if (pokemonState == PokemonState.dead)
            {
                rotation += 0.1f;
            }
            else if(pokemonState == PokemonState.alive)
            {
                Position += new Vector2(6, yVelocity);
                onGround = ground <= Position.Y + Height;
                if (onGround)
                {
                    if (ks.IsKeyDown(Keys.Space))
                    {
                        yVelocity = -20;
                        initialJump = true;
                    }
                    else
                    {
                        yVelocity = 2;
                    }

                }
                else
                {
                    //Check if initialJump is true
                    //Inside of this if statement, check if the space bar is pressed and make sure elapsedTime is less than maxJumpTime
                    if (initialJump == true)
                    {
                        if (ks.IsKeyDown(Keys.Space) && elapsedTime < maxJumpTime)
                        {
                            elapsedTime += gametime.ElapsedGameTime;
                            yVelocity -= .2f;
                        }
                        else
                        {
                            initialJump = false;
                            elapsedTime = new TimeSpan();
                        }
                    }
                    

                    //If it is true, add to elapsedTime and also subtract the yvelocity by .25

                    //Otherwise, set initialJump to false


                    yVelocity += gravity;
                }

                if (Position.Y + Height > Viewport.Height)
                {
                    Position = new Vector2(Position.X, Viewport.Height - Height);
                }
                if (ms.LeftButton == ButtonState.Pressed && prevMs.LeftButton == ButtonState.Released)
                {
                    if (ShotsAmount > 0)
                    {
                        ShotsAmount--;
                        thunderBolts.Add(new ThunderBolt(attackTexture, new Vector2 (position.X, position.Y + attackTexture.Height), Color.White, new Vector2(60, 0)));
                    }
                    
                }

                foreach (ThunderBolt bolt in thunderBolts)
                {
                    bolt.Update(gametime, Viewport);
                }
            }
        }
    

        public override void Draw(SpriteBatch spriteBatch)
        {
         
            if (pokemonState == PokemonState.dead)
            {
                spriteBatch.Draw(deadTexture, Position, null, color, rotation, origin, Vector2.One, SpriteEffects.None, 0);
            }
            else if (pokemonState == PokemonState.alive)
            {
                base.Draw(spriteBatch);

                foreach (ThunderBolt bolt in thunderBolts)
                {
                    bolt.Draw(spriteBatch);
                }
            }
           

        }
        public void Reset(float x, float y)
        {
            position = new Vector2(x, y);
            ShotsAmount = 5;
        }
        public void Jump()
        {
            yVelocity = -20;
            initialJump = true;
        }
        public bool DestroyObstacle(Obstacle obstacle)
        {
            for (int i = 0; i < thunderBolts.Count; i++)
            {
                if(thunderBolts[i].Hitbox.Intersects(obstacle.Hitbox))
                {
                    thunderBolts.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }


    }
}



/*
 * List<ThunderBolt> thunderBolts;
        Texture2D attackTexture;
        float yVelocity;
        bool onGround;
        float gravity = 0.4f;
        int ground;

 * /

/*
 * 
 *   public Character(Texture2D image, Vector2 position, Color color, Texture2D attackTexture) : base (image, position, color)
        {
            ground = (int)( position.Y + image.Height);
            thunderBolts = new List<ThunderBolt>();
            this.attackTexture = attackTexture;
        }
 * 
 * /


/*
     public void Update(GameTime gametime, KeyboardState ks, MouseState ms, MouseState prevMs, Viewport Viewport)
        {
            Position += new Vector2(4, yVelocity);
            onGround = ground <= Position.Y + Height;
            if(onGround)
            {
                if (ks.IsKeyDown(Keys.Space))
                {
                    yVelocity = -20;
                }
                else
                {
                    yVelocity = 1;
                }

            }
            else
            {
                yVelocity += gravity;
            }
        
            if(Position.Y + Height > Viewport.Height)
            {
                Position = new Vector2(Position.X, Viewport.Height - Height);
            }
            if(ms.LeftButton == ButtonState.Pressed && prevMs.LeftButton == ButtonState.Released)
            {
                thunderBolts.Add(new ThunderBolt(attackTexture, Position, Color.White, new Vector2(10, 0)));
            }

            foreach(ThunderBolt bolt in thunderBolts)
            {
                bolt.Update(gametime, Viewport);
            }

            //if pikachu +pikachu length touches hitbox, Postion.X = 0


        }
 * */




//*
 //*   public void Load(GameTime gametime)
   // {
     //   Position += new Vector2(100, yVelocity);
    //}
 //* /


   // /*
     ///*      public override void Draw(SpriteBatch spriteBatch)
        //{
          //  base.Draw(spriteBatch);
            ///foreach(ThunderBolt bolt in thunderBolts) 
            //{
              //  bolt.Draw(spriteBatch);
            //}
        //}
     //* /


   
    //
     //*  public void Reset()
       // {
         //   position = new Vector2(50, 200);
        //}
     //* /
