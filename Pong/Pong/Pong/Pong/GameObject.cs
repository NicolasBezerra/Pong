using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    class GameObject
    {
        public Vector2 Position;
        public Texture2D Texture;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.DeepPink);
        }
     
        public virtual void Mover(Vector2 amount)
        {
            Position += amount;
        }
    }
}
