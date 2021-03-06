﻿using System;
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
    public class GameObject //Skrevet hovedsaklig av Jørund Mjøset Bogen og Raymond Gulbrandsen
    {
        protected Texture2D texture;
        public Vector2 position;
        protected FrameInfo Frameinfo = FrameInfo.Instance;
        public Vector2 origin;

        public GameObject(Texture2D texture, Vector2 position) 
        {
            this.texture = texture;
            this.position = position;
        }
        public Vector2 Position { get { return position; } set { position = value; } }
        public Texture2D Texture { get { return texture; } set { texture = value; } }

        public virtual void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position-this.origin, Color.White);
        }
    }
}
