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
    public class GameObject
    {
        protected Texture2D texture;
        protected Vector2 position;

        public GameObject(Texture2D texture, Vector2 position) 
        {
            this.texture = texture;
            this.position = position;
        }

        public Vector2 Position
        {
            get;
            protected set;
        }
    }
}
