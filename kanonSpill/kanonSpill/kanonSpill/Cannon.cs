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
    public class Cannon : GameObject
    {
        Rectangle cannonRect;
        Vector2 origin;
        public Vector2 Direction;
        private float rotationAngle;

        /*Vector2 aim = Vector2.Zero;
        public bool HasShot = false;
        Rectangle cannonRect;
        public bool placing = false;
        public bool aiming = false;
        private float RotationAngle;
        Vector2 origin;
        static float bottom = 784f;
        static float middle = 240;
        public Vector2 direction;
         */


        public Cannon(Texture2D texture, Vector2 position,Vector2 direction)
            :base(texture, position)
        { 
            cannonRect = new Rectangle((int)position.X-16, (int)position.Y-16, texture.Width, texture.Height);
            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2;
            this.Direction = direction;
        }

        public Vector2 Position { get { return position; } set { position = value; } }
        
        public void Update()
        {
            rotationAngle = (float)Math.Atan2(Direction.Y, Direction.X);
            rotationAngle += MathHelper.Pi / 2;
            float circle = MathHelper.Pi * 2;
            rotationAngle = rotationAngle % circle;
            
            /*
            if (FrameInfo.MouseState.LeftButton == ButtonState.Released)
            {
                aiming = false;
                placing = false;
            }

            if (!placing && !aiming && FrameInfo.MouseState.LeftButton == ButtonState.Pressed)
            {
                if (cannonRect.Contains(FrameInfo.MouseState.X, FrameInfo.MouseState.Y))
                    placing = true;
                else 
                    aiming = true;     
            }

            if (aiming)
            {
                direction = new Vector2(FrameInfo.MouseState.Y - position.Y, FrameInfo.MouseState.X - position.X);
                direction.Normalize();
                RotationAngle = (float)Math.Atan2(direction.Y, direction.X);
                RotationAngle += MathHelper.Pi / 2;
                float circle = MathHelper.Pi * 2;
                RotationAngle = RotationAngle % circle;           
            }     

            if(placing)
            {
                position = new Vector2(FrameInfo.MouseState.X, bottom);
                cannonRect = new Rectangle((int)position.X-16, (int)position.Y-16, texture.Width, texture.Height);
            }*/
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position,null, Color.White, rotationAngle,origin, 1.0f, SpriteEffects.None, 0f);
        }


    }
}
