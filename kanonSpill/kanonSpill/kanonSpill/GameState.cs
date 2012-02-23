using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace cannonGame
{
    public class GameState
    {
        protected SpriteBatch SpriteBatch;
        protected ContentManager Content;

        public GameState(SpriteBatch spriteBatch, ContentManager content)
        {
            SpriteBatch = spriteBatch;
            Content = content;
        }

        public virtual void Update() { }
        public virtual void Draw() { }
    }
}
