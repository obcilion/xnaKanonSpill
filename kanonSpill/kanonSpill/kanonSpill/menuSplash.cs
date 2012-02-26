using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace CannonGame
{
    class menuSplash : SimpleSplash
    {
        Rectangle button1;
        Texture2D button1Texture;
        Rectangle button2;
        Texture2D button2Texture;
        Rectangle button3;
        Texture2D button3Texture;
        Rectangle button4;
        Texture2D button4Texture;

        public menuSplash(SpriteBatch spriteBatch, ContentManager content, String backTexture, 
            string button1Texture, string button2Texture, string button3Texture, string button4Texture)
            : base(spriteBatch, content, backTexture)
        {
            button1 = new Rectangle();
            this.button1Texture = content.Load<Texture2D>(button1Texture);
            button2 = new Rectangle();
            this.button2Texture = content.Load<Texture2D>(button2Texture);
            button3 = new Rectangle();
            this.button3Texture = content.Load<Texture2D>(button3Texture);
            button4 = new Rectangle();
            this.button4Texture = content.Load<Texture2D>(button4Texture);
        }

        public void update()
        {
            if ((Frameinfo.PreviousMouseState.LeftButton == ButtonState.Pressed) &&
                (Frameinfo.MouseState.LeftButton == ButtonState.Released) && 
                (new Vector2(Frameinfo.MouseState.X, Frameinfo.MouseState.Y) == new Vector2(button1.X, button1.Y)))
            {
                
                CannonGame.ChangeState(1);
            }
        }
    }
}
