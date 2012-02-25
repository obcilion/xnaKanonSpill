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
        float friction = 0.999f;
        public float radius = 16f;
        float screenWidth = 480f;
        float screenHeight = 800f;

        public Ball(Texture2D texture) : base(texture,new Vector2(0,0))
        {
            this.origin = new Vector2(radius, radius);
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
                spriteBatch.Draw(texture, position - origin, Color.White);
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
        public void obstacleCollision(SolidObstacle o)
        {
            if (intersects(o.obstacle))
            {

                if ((o.obstacle.Left <= Position.X && Position.X <= o.obstacle.Right))
                {
                    if (Math.Abs(Position.Y - o.obstacle.Top) < Math.Abs(Position.Y - o.obstacle.Bottom))
                    {
                        position.Y = o.obstacle.Top - radius;
                    }
                    else {position.Y = o.obstacle.Bottom + radius; }
                    Velocity *= new Vector2(1, -1);
                }
                else if ((o.obstacle.Top <= Position.Y && Position.Y <= o.obstacle.Bottom))
                {
                    if (Math.Abs(Position.X - o.obstacle.Left) < Math.Abs(Position.X - o.obstacle.Right))
                    {
                        position.X = o.obstacle.Left - radius;
                    }
                    else { position.X = o.obstacle.Right + radius; }
                    Velocity *= new Vector2(-1, 1);
                }

            }
        }
        bool intersects(Rectangle rect)
        {
            Vector2 circleDistance;
            circleDistance.X = Math.Abs(Position.X - rect.X - rect.Width / 2);
            circleDistance.Y = Math.Abs(Position.Y - rect.Y - rect.Height / 2);

            if (circleDistance.X > (rect.Width / 2 + radius)) { return false; }
            if (circleDistance.Y > (rect.Height / 2 + radius)) { return false; }

            if (circleDistance.X <= (rect.Width / 2)) { return true; }
            if (circleDistance.Y <= (rect.Height / 2)) { return true; }

            float cornerDistance_sq = (float)(Math.Pow((circleDistance.X - rect.Width / 2), 2) + Math.Pow((circleDistance.Y - rect.Height / 2), 2));

            return (cornerDistance_sq <= (Math.Pow(radius, 2)));
        }

    }
}
