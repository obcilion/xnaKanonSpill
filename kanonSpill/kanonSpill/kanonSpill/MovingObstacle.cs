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
        Vector2 position;
        float velocity;
        char axis;
        float distance;
        float distanceMoved;
        

        public MovingObstacle(Texture2D texture, Vector2 position, float height, float width, float velocity, char axis)
            :base(texture, position)
        {
            this.width = width;


        }

        public void update()
        {


        }
    }
}
