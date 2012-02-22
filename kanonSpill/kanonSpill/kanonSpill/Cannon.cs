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
    class Cannon : GameObject
    {

        Vector2 aim = Vector2.Zero;
        bool hasShot = false;
        Rectangle cannonRect;
        bool dragging = false;

        public Cannon(Texture2D texture)
            :base(texture, new Vector2(300-16, 420-16))
        { 
            cannonRect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void update()
        {
            if (cannonRect.Contains(Mouse.GetState().X, Mouse.GetState().Y) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                dragging = true;
            if(dragging && Mouse.GetState().LeftButton == ButtonState.Released)
                dragging = false;

            if(dragging)
            {

                position = new Vector2(Mouse.GetState().X - 16, 420-16);
                cannonRect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
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
