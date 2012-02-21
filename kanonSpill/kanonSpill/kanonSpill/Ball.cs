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

namespace kanonSpill
{
    //Test oipojpogajiipjopjiaepirjgpojeoafijeoaijfoieiorj
    //waz up?
    //no much...

    class Ball : GameObject
    {
        Vector2 velocity = Vector2.Zero;
        float friction = 0.99f;
        float radius = 10f;

        Vector2 initialVelocity;


        public Ball(Texture2D texture, Cannon cannon)  
            :base(texture, cannon.Position) 
        {
           
            initialVelocity = (cannon.Position - (new Vector2(Mouse.GetState().X, Mouse.GetState().Y)));
            initialVelocity.Normalize();

            initialVelocity *= 10;
            velocity = initialVelocity;
        }

        public void update() 
        {
            velocity *= friction;
            position -= velocity;


        }

        private void wallCollisionCheck()
        {

            if (position.X > 800f - radius)
            {
                position.X = 800f - radius;
                velocity *= new Vector2(-1, 1);
            }
            else if (position.X < radius)
            {
                position.X = radius;
                velocity *= new Vector2(-1, 1);
            }

            
            if (position.Y > 480f - radius)
            {
                position.Y = 480f - radius;
                velocity *= new Vector2(1, -1);
            }
            else if (position.Y < radius)
            {
                position.Y = radius;
                velocity *= new Vector2(1, -1);
            }

          
        }
    }
}
