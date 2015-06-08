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
using System.Diagnostics;


namespace Pong
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static int ScreenWidth;
        public static int ScreenHeight;

        const int OFFSET = 70;
        public const float Ball_Start_Speed = 8f;
        Player player1;
        Player player2;
        Bola ball;
        SpriteFont Score1;
        SpriteFont Score2;
        public static int pontosPlayer1;
        public static int pontosPlayer2;
        SoundEffect soundEffect;
        public static SoundEffect soundEffect2;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenWidth = GraphicsDevice.Viewport.Width;
            player1 = new Player();
            player2 = new Player();
            ball = new Bola();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            player1.Texture = Content.Load<Texture2D>("Content/paddle");
            player2.Texture = Content.Load<Texture2D>("Content/paddle");
            ball.Texture = Content.Load<Texture2D>("Content/ball");
            Score1 = Content.Load<SpriteFont>("Content/Score1");
            Score2 = Content.Load<SpriteFont>("Content/Score2");
            soundEffect = Content.Load<SoundEffect>("Content/PaddleBallCollision");
            soundEffect2 = Content.Load<SoundEffect>("Content/BallWallCollision");
            player1.Position = new Vector2(OFFSET , ScreenHeight / 2 - player1.Texture.Height / 2);
            player2.Position = new Vector2 (ScreenWidth - player2.Texture.Width - OFFSET, ScreenHeight / 2 - player2.Texture.Height / 2);
            ball.Lauch(Ball_Start_Speed);

          

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            ScreenWidth = GraphicsDevice.Viewport.Width;
            ScreenHeight = GraphicsDevice.Viewport.Height;
            ball.Mover(ball.Velocity);
            ball.ColisaoComParedes();
            player1.Mover(player1.velocity);
            player2.Mover(player2.velocity);

            player1.Colisao();
            player2.Colisao();
            player1.Movimentos();
            player2.Movimentos2();
            base.Update(gameTime);
            //
            if (ball.Position.X < player1.Position.X + player1.Texture.Width &&
                ball.Position.X + ball.Texture.Width > player1.Position.X &&
                ball.Position.Y < player1.Position.Y + player1.Texture.Height &&
                ball.Texture.Height + ball.Position.Y > player1.Position.Y && ball.Velocity.X < 0) {
                   
                    ball.Velocity.X *= -1;
                    soundEffect.Play();
            }

            if (ball.Position.X < player2.Position.X + player2.Texture.Width &&
                ball.Position.X + ball.Texture.Width > player2.Position.X &&
                ball.Position.Y < player2.Position.Y + player2.Texture.Height &&
                ball.Texture.Height + ball.Position.Y > player2.Position.Y && ball.Velocity.X > 0) { ball.Velocity.X *= -1; soundEffect.Play(); }


            Debug.WriteLine(pontosPlayer1 + " / " + pontosPlayer2);
             
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            spriteBatch.DrawString(Score1,"" + pontosPlayer1, new Vector2(ScreenWidth/2 - 60, ScreenHeight/2 -60), Color.Black);
            spriteBatch.DrawString(Score2, "" + pontosPlayer2, new Vector2(ScreenWidth / 2  , ScreenHeight / 2 -60 ), Color.Black);

            spriteBatch.End();

            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
