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

        public Cannon(Texture2D texture, Vector2 position)
            : base(texture, position)
        {

        }

        public void update()
        {
            if()
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.End();
        }

    }
}
