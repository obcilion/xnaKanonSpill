using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace CannonGame
{
    public class SimpleSplash : GameState
    {
        Texture2D splashTexture;
        
        public SimpleSplash(SpriteBatch spriteBatch, ContentManager content, String texture, int gameStateIndex)
            : base(spriteBatch, content, gameStateIndex)
        {
            splashTexture = content.Load<Texture2D>(texture);
        }

        /*public override void Update()
        {

            if ((Frameinfo.PreviousMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed) &&
                (Frameinfo.MouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released))
                CannonGame.ChangeState(NextState);
        }*/

        public override void Draw()
        {
            SpriteBatch.Draw(splashTexture, Vector2.Zero, Color.White);
        }
    }
}
