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
        public bool button1Pressed = false;
        Rectangle button2;
        Texture2D button2Texture;
        public bool button2Pressed = false;
        Rectangle button3;
        Texture2D button3Texture;
        public bool button3Pressed = false;
        Rectangle button4;
        Texture2D button4Texture;
        public bool button4Pressed = false;

        public menuSplash(SpriteBatch spriteBatch, ContentManager content, String backTexture, 
            string button1Texture, string button2Texture, string button3Texture, string button4Texture, int gameStateIndex)
            : base(spriteBatch, content, backTexture, gameStateIndex)
        {
            button1 = new Rectangle(180, 400, 120, 50);
            this.button1Texture = content.Load<Texture2D>(button1Texture);
            button2 = new Rectangle(180, 470, 120, 50);
            this.button2Texture = content.Load<Texture2D>(button2Texture);
            button3 = new Rectangle(180, 540, 120, 50);
            this.button3Texture = content.Load<Texture2D>(button3Texture);
            button4 = new Rectangle(180, 610, 120, 50);
            this.button4Texture = content.Load<Texture2D>(button4Texture);
        }

        public void update()
        {
            if ((Frameinfo.PreviousMouseState.LeftButton == ButtonState.Pressed) &&
                (Frameinfo.MouseState.LeftButton == ButtonState.Released) &&
                (new Vector2(Frameinfo.MouseState.X, Frameinfo.MouseState.Y) == new Vector2(button1.X, button1.Y)))
                button1Pressed = true;

            if ((Frameinfo.PreviousMouseState.LeftButton == ButtonState.Pressed) &&
                (Frameinfo.MouseState.LeftButton == ButtonState.Released) &&
                (new Vector2(Frameinfo.MouseState.X, Frameinfo.MouseState.Y) == new Vector2(button2.X, button2.Y)))
                button2Pressed = true;

            if ((Frameinfo.PreviousMouseState.LeftButton == ButtonState.Pressed) &&
                (Frameinfo.MouseState.LeftButton == ButtonState.Released) &&
                (new Vector2(Frameinfo.MouseState.X, Frameinfo.MouseState.Y) == new Vector2(button3.X, button3.Y)))
                button3Pressed = true;

            if ((Frameinfo.PreviousMouseState.LeftButton == ButtonState.Pressed) &&
                (Frameinfo.MouseState.LeftButton == ButtonState.Released) &&
                (new Vector2(Frameinfo.MouseState.X, Frameinfo.MouseState.Y) == new Vector2(button4.X, button4.Y)))
                button4Pressed = true;
            
        }

        public override void  Draw()
        {
 	        base.Draw();
            SpriteBatch.Draw(button1Texture, button1, Color.White);
            SpriteBatch.Draw(button2Texture, button2, Color.White);
            SpriteBatch.Draw(button3Texture, button3, Color.White);
            SpriteBatch.Draw(button4Texture, button4, Color.White);
        }
    }
}
