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
        Vector2 position;
        Rectangle cannonRect;

        public Cannon(Texture2D texture, Vector2 position)
            : base(texture, position)
        {
            cannonRect = new Rectangle(position.X, position.Y, texture.Width, texture.Height);
        }

        public void update()
        {
            if (cannonRect.Contains(Mouse.GetState()) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                position = new Vector2(Mouse.GetState().X, 400);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.End();
        }

    }
}
