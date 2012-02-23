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

    class MovingObstacle : SolidObstacle
    {
        
        float velocity;
        char axis;
        float distance;
        float distanceMoved;
        bool direction = true;
        

        public MovingObstacle(Texture2D texture, Vector2 position, int height, int width, float velocity, char axis, float distance)
            :base(texture, position, height, width)
        {
            this.velocity = velocity;
            this.axis = axis;
            this.distance = distance;

        }

        public void update()
        {
            if (axis == 'Y' && direction == true)
            {
                position.Y += velocity;
                distanceMoved++;
                if (distanceMoved >= distance)
                {
                    direction = false;
                }
            }
            else if (axis == 'Y' && direction == false)
            {
                position.Y -= velocity;
                distanceMoved--;
                if (distanceMoved <= 0)
                {
                    direction = true;
                }
            }
            else if (axis == 'X' && direction == true)
            {
                position.X += velocity;
                distanceMoved++;
                if (distanceMoved >= distance)
                {
                    direction = false;
                }
            }
            else if (axis == 'X' && direction == false)
            {
                position.X -= velocity;
                distanceMoved--;
                if (distanceMoved <= 0)
                {
                    direction = true;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.End();
        }
    }
}
