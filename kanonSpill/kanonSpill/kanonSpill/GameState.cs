using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CannonGame
{
    public class GameState //Skrevet hovedsaklig av Ketil Almquist
    {
        protected SpriteBatch SpriteBatch;
        protected ContentManager Content;
        protected FrameInfo Frameinfo = FrameInfo.Instance;
        public int CurrentGameStateIndex;

        public GameState(SpriteBatch spriteBatch, ContentManager content, int currnetGameStateIndex)
        {
            SpriteBatch = spriteBatch;
            Content = content;
            CurrentGameStateIndex = currnetGameStateIndex;
        }
        public virtual void Reset() { }

        public virtual void Update() { }
        public virtual void Draw() { }
    }
}
