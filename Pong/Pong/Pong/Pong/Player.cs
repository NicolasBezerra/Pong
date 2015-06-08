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
    class Player : GameObject
    {
        public Vector2 velocity;

        public void  Movimentos() {
            KeyboardState keyState = Keyboard.GetState();
           
            if (keyState.IsKeyDown(Keys.W))

                this.Position.Y -= 5;

            else if (keyState.IsKeyDown(Keys.S))

                this.Position.Y += 5;
        }
        public void Movimentos2() {
            KeyboardState keyState = Keyboard.GetState();
           
            if (keyState.IsKeyDown(Keys.Up))

                this.Position.Y -= 5;

            else if (keyState.IsKeyDown(Keys.Down))

                this.Position.Y += 5;
        
        }
        public void Colisao() {
            if (this.Position.Y <= 0)
            {
                this.Position.Y = 0;
            }
            if (this.Position.Y  + this.Texture.Height >= Game1.ScreenHeight)
            {
                this.Position.Y = Game1.ScreenHeight - this.Texture.Height ;
            }
        }

    }
}
