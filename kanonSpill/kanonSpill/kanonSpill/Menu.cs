using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace CannonGame
{
    public class Menu : GameState
    {
        Texture2D MenuTexture;

        int NextState = 0;

        public Menu(SpriteBatch spriteBatch, ContentManager content, String texture)
            : base(spriteBatch, content)
        {
            MenuTexture = content.Load<Texture2D>(texture);
        }

        public override void Update()
        {
        }

        public override void Draw()
        {
            SpriteBatch.Draw(MenuTexture, Vector2.Zero, Color.White);
        }
    }
}
