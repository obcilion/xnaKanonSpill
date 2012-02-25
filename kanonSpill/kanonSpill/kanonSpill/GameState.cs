using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CannonGame
{
    public class GameState
    {
        protected SpriteBatch SpriteBatch;
        protected ContentManager Content;
        protected FrameInfo Frameinfo = FrameInfo.Instance;
        public bool SplashFinished;

        public GameState(SpriteBatch spriteBatch, ContentManager content)
        {
            SpriteBatch = spriteBatch;
            Content = content;
            SplashFinished = false;
        }

        public virtual void Update() { }
        public virtual void Draw() { }
    }
}
