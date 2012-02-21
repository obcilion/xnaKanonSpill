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

        public Cannon(Texture2D texture, Vector2 position)
            : base(texture, position)
        {
            Position = position;
        }

        public Vector2 Position 
        {
            get { return position; }

            set { Position = value; }
        }

        public Vector2 GetPosition() 
        {
            return position;
        }
    }
}
