using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
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

        public override void Update()
        {

            if ((Frameinfo.PreviousMouseState.LeftButton == ButtonState.Pressed) &&
                (Frameinfo.MouseState.LeftButton == ButtonState.Released))
            {
                if (CurrentGameStateIndex == 0)
                    CannonGame.ChangeState(1);
                else if (CurrentGameStateIndex == 2)
                    CannonGame.ChangeState(3);
                else if (CurrentGameStateIndex == 3)
                    CannonGame.ChangeState(1);
                else if (CurrentGameStateIndex == 4)
                    CannonGame.ChangeState(1);
            }

        }

        public override void Draw()
        {
            SpriteBatch.Draw(splashTexture, Vector2.Zero, Color.White);
        }
    }
}
