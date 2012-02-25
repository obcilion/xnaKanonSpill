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

    class SolidObstacle : GameObject
    {
        float height;
        float width;
        public Rectangle obstacle;
        float velocity;
        char axis;
        float distance;
        float distanceMoved;
        bool direction = true;
        bool moving = false;
        

        public SolidObstacle(Texture2D texture, Vector2 position, int height, int width)
            :base(texture, position)
        {
            this.height = height;
            this.width = width;
            obstacle = new Rectangle((int)position.X, (int)position.Y, height, width);
            this.origin.X = obstacle.Center.X;
            this.origin.Y = obstacle.Center.Y;
        }
        public SolidObstacle(Texture2D texture, Vector2 position, int height, int width, float velocity, char axis, int distance)
            :this(texture, position, height, width)
        {
            
            this.velocity = velocity;
            this.axis = axis;
            this.distance = distance;
            this.moving = true;

        }
        public override void Update()
        {
            if (moving)
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
                obstacle.X = (int)position.X;
                obstacle.Y = (int)position.Y;
            }
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, obstacle, Color.White);
        }
    }
}
