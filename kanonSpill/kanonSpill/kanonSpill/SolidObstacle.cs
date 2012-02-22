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

    class SolidObstacle : GameObject
    {
        float height;
        float width;
        Vector2 position;


        public SolidObstacle(Texture2D texture, position, float height, float width)
            :base(texture, position)
        {
            
        }

    }
}
