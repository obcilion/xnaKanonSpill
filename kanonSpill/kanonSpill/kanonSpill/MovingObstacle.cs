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

    class MovingObstacle : GameObject
    {
        float height;
        float width;
        float velocity;
        char axis;
        float distance;
        float distanceMoved;
        boolean direction = true;
        

        public MovingObstacle(Texture2D texture, Vector2 position, float height, float width, float velocity, char axis)
            :base(texture, position)
        {
            this.height = height;
            this.width = width;
            this.velocity = velocity;
            this.axis = axis;

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
    }
}
