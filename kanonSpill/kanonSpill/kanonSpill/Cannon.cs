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
        public Vector2 Direction;
        private float rotationAngle;

        public bool placing = false;
        public bool aiming = false;
        public Ball ball = null;
        public bool hasShot = false;
        


        public Cannon(Texture2D texture, Vector2 position, Vector2 direction)
            : base(texture, position)
        {
            cannonRect = new Rectangle((int)position.X - 16, (int)position.Y - 16, texture.Width, texture.Height);
            origin.X = texture.Width / 2;
            origin.Y = texture.Height / 2;
            this.Direction = direction;
            updateRotation();
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotationAngle, origin, 1.0f, SpriteEffects.None, 0.9f);
        }
        public void Control()
        {
            if (Frameinfo.MouseState.LeftButton == ButtonState.Released)
            {
                aiming = false;
                placing = false;
            }

            if (!placing && !aiming && Frameinfo.MouseState.LeftButton == ButtonState.Pressed)
            {
                if (cannonRect.Contains(Frameinfo.MouseState.X, Frameinfo.MouseState.Y))
                    placing = true;
                else
                    aiming = true;
            }

            if (aiming)
            {
                Direction = new Vector2(Frameinfo.MouseState.X - Position.X, Frameinfo.MouseState.Y - Position.Y);
                Direction.Normalize();
                Direction = Vector2.Clamp(Direction, new Vector2(-1, -1), new Vector2(1, 0));
                Direction.Normalize();
                updateRotation();
                
            }

            if (placing)
            {
                Position = Vector2.Clamp(new Vector2(Frameinfo.MouseState.X, Position.Y),new Vector2(16,0),new Vector2(464,800));
                cannonRect = new Rectangle((int)Position.X - 16, (int)Position.Y - 16, texture.Width, texture.Height);
            }
        }
        public void updateRotation()
        {
            rotationAngle = (float)Math.Atan2(Direction.Y, Direction.X);
            rotationAngle += MathHelper.Pi / 2;
            float circle = MathHelper.Pi * 2;
            rotationAngle = rotationAngle % circle;
        }
        public void Fire(Ball ball)
        {
            ball.Position = this.Position;
            ball.Velocity = this.Direction*10;
            ball.Enabled = true;
            hasShot = true;
        }


    }
}
