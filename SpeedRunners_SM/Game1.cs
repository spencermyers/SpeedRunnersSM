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

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        
        Random random;
        Vector2 position;
        Texture2D image;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ScrollingBackground scrolling;
        Sprite gameover;
        Pokemon pikachu;
        Color txtcolor;
        Vector2 txtpos;
        SpriteFont spriteFont;
        MouseState prevMs;
        MouseState ms;
        Texture2D obstacleImage;
        Texture2D GoodBrickImage;
        TimeSpan delay;
        TimeSpan elapsedTime;
        StaminaBar staminaBar;

        bool lost;
        

        string Txt = "Level 1";
        int pos = 0;
        int level = 1;
        List<Obstacle> obstacles;

        string GoodBrickTxt = "Level 1";
        int GoodBrickpos = 0;
        int GoodBricklevel = 1;
        List<GoodBrick> GoodBricks;
        private Vector2 origin;
        private Color color;
        private SpriteEffects effects;
        private float layerDepth;
        private float rotate;
        private Vector2 scale;

        Texture2D otherBackground;
        Texture2D otherPokemon;
        Texture2D thirdPokemon;
        Texture2D fourthPokemon;
        Texture2D otherPokemonProjectile;
        Texture2D otherPokemonObstacle;
        Texture2D otherPokemonDED;
        Texture2D otherPokeball;

        Texture2D elseBackground;
        Texture2D elsePokemon;
        Texture2D elsePokemonProjectile;
        Texture2D elsePokemonObstacle;
        Texture2D elsePokemonDED;
        Texture2D elsePokeball;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 700;
            graphics.ApplyChanges();
            graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
          
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary> 
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            random = new Random();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D background = Content.Load<Texture2D>("Pretty desert backgrnd");
            scrolling = new ScrollingBackground(background);
            

            otherBackground = Content.Load<Texture2D>("2ndBackground");
            otherPokemon = Content.Load<Texture2D>("otherPokemon");
            otherPokemonProjectile = Content.Load<Texture2D>("otherPokemonProjectile");
            otherPokemonDED = Content.Load<Texture2D>("otherPokemonDED");
            otherPokemonObstacle = Content.Load<Texture2D>("Rock");
            otherPokeball = Content.Load<Texture2D>("Pokeball2");

            elseBackground = Content.Load<Texture2D>("Otherbackground 2");
            elsePokemon = Content.Load<Texture2D>("Squirtle");
            elsePokemonProjectile = Content.Load<Texture2D>("SquirtleAttack");
            elsePokemonDED = Content.Load<Texture2D>("DEDSquirtle");
            elsePokemonObstacle = Content.Load<Texture2D>("SHel");
            elsePokeball = Content.Load<Texture2D>("MasterBALL");
            
            Texture2D pikachuImage = Content.Load<Texture2D>("Pikachu");
            Texture2D thunderBolt = Content.Load<Texture2D>("Thunderbolt");
            Texture2D deadPikImage = Content.Load<Texture2D>("Ded Pikachu");
            obstacleImage = Content.Load<Texture2D>("Pokeball");
            GoodBrickImage = Content.Load<Texture2D>("GoodBrick");
            gameover = new Sprite(Content.Load<Texture2D>("Gameover"), new Vector2(800, 200), Color.White);

            pikachu = new Pokemon(pikachuImage, new Vector2(10, GraphicsDevice.Viewport.Height - pikachuImage.Height), Color.White, thunderBolt, deadPikImage);
            obstacles = new List<Obstacle>();
            GoodBricks = new List<GoodBrick>();
            GoodBricks.Add(new GoodBrick(Content.Load<Texture2D>("GoodBrick"), new Vector2(GraphicsDevice.Viewport.Width + 100, random.Next(400, 641)), Color.White, new Vector2(1, 1)));
            addNewObstacle();
            spriteFont = Content.Load<SpriteFont>("Levels");
            elapsedTime = TimeSpan.Zero;
            delay = new TimeSpan(0, 10, 0);
            lost = false;
            Txt = "Level 1";
            level = 1;
            scale = new Vector2(1, 1);
            staminaBar = new StaminaBar(Content.Load<Texture2D>("Stamina Slow Orang"), Content.Load<Texture2D>("Stamina Speed BLue"), new Vector2 (200,3), origin, Color.White, effects, layerDepth, rotate, scale);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
   
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {


            KeyboardState ks = Keyboard.GetState();
            elapsedTime += gameTime.ElapsedGameTime;
            prevMs = ms;
            ms = Mouse.GetState();
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //background speed 
            pos += -1;
            scrolling.Update(pos);
            // TODO: Add your update logic here
            
            if (pikachu.Position.X + pikachu.Width > GraphicsDevice.Viewport.Width)
            {
                level++;
                if (level == 5)
                {


                    //get dead texture for bulbasaur and attack texture.                
                    scrolling = new ScrollingBackground(otherBackground);
                    GoodBricks.Clear();
                    GoodBrickImage = otherPokemonObstacle;
                    obstacles.Clear();
                    obstacleImage = otherPokeball;
                    pikachu = new Pokemon(otherPokemon, new Vector2(10, 700 - otherPokemon.Height), Color.White, otherPokemonProjectile, otherPokemonDED);

                    


                    //thunderBolt = new ThunderBolt(otherPokemonProjectile, Vector2.Zero, Color.White, Vector2 );
                }
                

                if (level == 10)
                {
                    //get dead texture for squirtle and attack texture
                    scrolling = new ScrollingBackground(otherBackground);
                    GoodBricks.Clear();
                    GoodBrickImage = elsePokemonObstacle;
                    obstacles.Clear();
                    obstacleImage = elsePokeball;
                    pikachu = new Pokemon(elsePokemon, new Vector2(10, 700 - elsePokemon.Height), Color.White, elsePokemonProjectile, elsePokemonDED);



                }
            }
            pikachu.Update(gameTime, ks, ms, prevMs, GraphicsDevice.Viewport);

               
            //eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
            
            for (int i = 0; i < obstacles.Count; i++)
            //foreach (Obstacle obstacle in obstacles)
            
            {
                
                obstacles[i].Update(gameTime);
                Rectangle PikachuBottom = new Rectangle(pikachu.Hitbox.X, pikachu.Hitbox.Y + pikachu.Height - 20, pikachu.Hitbox.Width, 20);
                Rectangle ObstacleTop = new Rectangle(obstacles[i].Hitbox.X, obstacles[i].Hitbox.Y, obstacles[i].Width, 20);
                if (PikachuBottom.Intersects(ObstacleTop))
                {
                    pikachu.Jump();
                }
                else if (obstacles[i].Hitbox.Intersects(pikachu.Hitbox))
                {
                    pikachu.pokemonState = PokemonState.dead;
                    lost = true;
                    //pikachu automatically jumps when on top of poke ball
                    
                }
                if (pikachu.DestroyObstacle(obstacles[i]))
                {
                    obstacles.RemoveAt(i--);
                }
                //if (pikachu.Hitbox.Intersects())
            }
            for (int i = 0; i < GoodBricks.Count; i++)
            
            {
                if (GoodBricks[i].Hitbox.Intersects(pikachu.Hitbox))
                {
                     pikachu.Position -= new Vector2(10, 0);
                }
            }
            
            //Make it so pikahu, thunderbolt, and obstacles intersect
            for (int i = 0; i < GoodBricks.Count; i++)
            
            {
                GoodBricks[i].Update(gameTime);
            }
            
            //eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
            if(elapsedTime > delay)
            {
                elapsedTime = TimeSpan.Zero;
                addNewObstacle();
            }
            if(elapsedTime > delay)
            {
                elapsedTime = TimeSpan.Zero;
                addNewObstacle();
            }
            if (ks.IsKeyDown(Keys.R))
            {
                Initialize();
            }

               Txt = $"Level {level}";

            //Make it so pikachu dies once his position is completely off the screen
            
            {
                if (pikachu.Position.X < -pikachu.Hitbox.Width)
                {
                    pikachu.pokemonState = PokemonState.dead;
                    lost = true;
                }
            }


            {
                if(pikachu.pokemonState != PokemonState.dead && staminaBar.staminaPercentage > 0)
                {
                    if (ks.IsKeyDown(Keys.A))
                    {
                        pikachu.Position -= new Vector2(6, 0);
                        staminaBar.staminaPercentage -= 0.8f;
                    }
                    if (ks.IsKeyDown(Keys.D))
                    {
                        pikachu.Position += new Vector2(3, 0);
                        staminaBar.staminaPercentage -= 0.8f;
                        //staminaBar.Scale = new Vector2(staminaBar.Scale.X - 0.1f, staminaBar.Scale.Y);
                    }
                    
                }


                //make stamina bar go down
            }

            base.Update(gameTime);

            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();



            scrolling.Draw(spriteBatch);

            pikachu.Draw(spriteBatch);

            staminaBar.Draw(spriteBatch);

            spriteBatch.DrawString(spriteFont, Txt, Vector2.Zero, new Color(31, 26, 23));
            spriteBatch.DrawString(spriteFont, $"{pikachu.ShotsAmount}/5", new Vector2 (50,50), new Color (31, 26, 23));

            foreach(Obstacle obstacle in obstacles)
            {
                obstacle.Draw(spriteBatch);
            }
            if (lost)
            {
                gameover.Draw(spriteBatch);
            }
            foreach (GoodBrick GoodBrick in GoodBricks)
            {
                GoodBrick.Draw(spriteBatch);
            }
            if (lost)
            {
                gameover.Draw(spriteBatch);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        void addNewObstacle()
        {
            int Obstacleposition = random.Next(GraphicsDevice.Viewport.Height / 4, GraphicsDevice.Viewport.Height - obstacleImage.Height);
            obstacles.Add(new Obstacle(obstacleImage, new Vector2(GraphicsDevice.Viewport.Width, Obstacleposition), Color.White, new Vector2(-5, 0)));
            int Brickposition = random.Next(GraphicsDevice.Viewport.Height / 2, GraphicsDevice.Viewport.Height - obstacleImage.Height);
            GoodBricks.Add(new GoodBrick(GoodBrickImage, new Vector2(GraphicsDevice.Viewport.Width, Brickposition), Color.White, new Vector2(-6, 0)));
        }
    }
}


//make obsticles in game, and make so that their not in eachother.