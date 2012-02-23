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
        public Ball(Texture2D texture) : base(texture,new Vector2(0,0))
        {
        }
        public void update()
        {
        }

        /*Vector2 velocity = Vector2.Zero;
        float friction = 0.993f;
        float radius = 16f;
        float screenWidth = 480f;
        float screenHeight = 800f;

        Vector2 initialVelocity;
        Cannon cannon;


        public Ball(Texture2D texture, Cannon cannon)  
            :base(texture, cannon.GetPosition()  -new Vector2(16, 16))
        {
           
            //initialVelocity = (cannon.GetPosition() - new Vector2(16, 16) - (new Vector2(Mouse.GetState().X, Mouse.GetState().Y)));
            //initialVelocity.Normalize();
            initialVelocity = cannon.direction;
            initialVelocity *= 10;
            velocity = initialVelocity;
            this.cannon = cannon;
        }

        public void update() 
        {
            initialVelocity = cannon.direction;
            initialVelocity *= 10;
            velocity = initialVelocity;
            wallCollisionCheck();
            velocity *= friction;

            if (velocity.Length() > 0.1)
            position += velocity;


        }

        private void wallCollisionCheck()
        {

            if (position.X > screenWidth - radius)
            {
                position.X = screenWidth - radius;
                velocity *= new Vector2(-1, 1);
            }
            else if (position.X < radius)
            {
                position.X = radius;
                velocity *= new Vector2(-1, 1);
            }

            
            if (position.Y > screenHeight - radius)
            {
                position.Y = screenHeight - radius;
                velocity *= new Vector2(1, -1);
            }
            else if (position.Y < radius)
            {
                position.Y = radius;
                velocity *= new Vector2(1, -1);
            }

         
        } 

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position - new Vector2(radius, radius), Color.White);
            spriteBatch.End();
        }*/
    }
}
