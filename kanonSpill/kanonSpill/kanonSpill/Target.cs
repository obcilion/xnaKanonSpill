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

    public class Target : GameObject
    {
        public float radius = 32;

        
        public Target(Texture2D texture)
            : base(texture, Vector2.Zero)
        {
            this.origin = new Vector2(radius, radius);
            this.Position = new Vector2(200, 200);
        }

        

    }
}
