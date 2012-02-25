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
        

        public SolidObstacle(Texture2D texture, Vector2 position, int height, int width)
            :base(texture, position)
        {
            this.height = height;
            this.width = width;
            obstacle = new Rectangle((int)position.X, (int)position.Y, height, width);
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, obstacle, Color.White);
        }
    }
}
