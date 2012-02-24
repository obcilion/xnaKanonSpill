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

namespace CannonGame
{
    
    public class Ball : GameObject
    {
        public Vector2 Velocity = Vector2.Zero;
        public bool Enabled = false;
        float friction = 0.998f;
        public float radius = 16f;
        float screenWidth = 480f;
        float screenHeight = 800f;

        public Ball(Texture2D texture) : base(texture,new Vector2(0,0))
        {
        }

        public void update()
        {
            wallCollisionCheck();
            Velocity *= friction;

            if (Velocity.Length() > 0.1)
                Position += Velocity;
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            if (Enabled){
                spriteBatch.Draw(texture, position - new Vector2(radius, radius), Color.White);
            }
        }

        private void wallCollisionCheck()
        {

            if (Position.X > screenWidth - radius)
            {
                position.X = screenWidth - radius;
                Velocity *= new Vector2(-1, 1);
            }
            else if (position.X < radius)
            {
                position.X = radius;
                Velocity *= new Vector2(-1, 1);
            }

            
            if (position.Y > screenHeight - radius)
            {
                position.Y = screenHeight - radius;
                Velocity *= new Vector2(1, -1);
            }
            else if (position.Y < radius)
            {
                position.Y = radius;
                Velocity *= new Vector2(1, -1);
            }

         
        } 
    }
}
