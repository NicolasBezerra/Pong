using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pong
{
    class Bola : GameObject
    {
        public Vector2 Velocity;
        public Random random;
        public Bola()
        {
            random = new Random();
        }

        public void Lauch(float speed)
        {
            Position = new Vector2(Game1.ScreenWidth/2 - Texture.Width/2, Game1.ScreenHeight/2 - Texture.Height/2);//new Vector2(Game1.ScreenHeight / 2 - Texture.Height / 2 - Texture.Width / 2);
            float rotation = (float) (Math.PI/2 + (random.NextDouble() * (Math.PI/1.5f) - Math.PI/3));

            Velocity.X = (float)Math.Sin(rotation);
            Velocity.Y = (float)Math.Cos(rotation);

            if (random.Next(2) == 1)
            {
                Velocity.X *= -1; 
            }

            Velocity *= speed;    
      
            
        }
        public void ColisaoComParedes()
        {
            if (Position.Y <= 0)
            {
                Position.Y = 0;
                Velocity.Y *= -1;
                Game1.soundEffect2.Play();
            }

            if (Position.Y + this.Texture.Height >= Game1.ScreenHeight)
            {
                Position.Y = Game1.ScreenHeight - this.Texture.Height;
                Velocity.Y *= -1;
                Game1.soundEffect2.Play();
            }
            if (Position.X <= 0)
            {
                Game1.pontosPlayer2 += 1;
                Lauch(Game1.Ball_Start_Speed);
                Velocity.X *= -1;
                
                
            }

            if (Position.X + this.Texture.Width >= Game1.ScreenWidth || Position.X <= 0)
            {
                Game1.pontosPlayer1 += 1;
                Lauch(Game1.Ball_Start_Speed);
                 
            }




        }
    }
}
