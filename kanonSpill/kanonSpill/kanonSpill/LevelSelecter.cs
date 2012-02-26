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
    public class LevelSelecter : SimpleSplash
    {
        Rectangle level1;
        Rectangle level2;
        Rectangle level3;
        Rectangle level4;
        Rectangle menuButton;

        SpriteFont font;
        Texture2D button;
        Texture2D menu;
        Point mouse;

        public LevelSelecter(SpriteBatch spriteBatch, ContentManager content, String backTexture, int gameStateIndex)
            : base(spriteBatch, content, backTexture, gameStateIndex)
        {
            font = Content.Load<SpriteFont>("Font");
            button = Content.Load<Texture2D>("Images/whiteButton");
            menu = Content.Load<Texture2D>("Images/menuButton2");

            menuButton = new Rectangle(30, 720, 120, 50);

            level1 = new Rectangle(100, 200, 48, 48);
            level2 = new Rectangle(168, 200, 48, 48);
            level3 = new Rectangle(254, 200, 48, 48);
            level4 = new Rectangle(320, 200, 48, 48);

        }
        public override void Update()
        {
            mouse = new Point(Mouse.GetState().X, Mouse.GetState().Y);

            if ((Frameinfo.PreviousMouseState.LeftButton == ButtonState.Pressed) &&
                (Frameinfo.MouseState.LeftButton == ButtonState.Released))
            {
                if (level1.Contains(mouse))
                    CannonGame.ChangeState(8);
                else if (level2.Contains(mouse))
                    CannonGame.ChangeState(9);
                else if (level3.Contains(mouse))
                    CannonGame.ChangeState(10);
                else if (level3.Contains(mouse))
                    CannonGame.ChangeState(11);
                else if (menuButton.Contains(mouse))
                    CannonGame.ChangeState(1);
            }
                

        }

        public override void Draw()
        {
            base.Draw();

            SpriteBatch.Draw(menu, menuButton, Color.White);

            SpriteBatch.Draw(button, level1, Color.Blue);
            SpriteBatch.DrawString(font, "1", new Vector2(level1.X + 12, level1.Y + 12), Color.Red, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            SpriteBatch.Draw(button, level2, Color.Blue);
            SpriteBatch.DrawString(font, "2", new Vector2(level2.X + 15, level2.Y + 12), Color.Red, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            SpriteBatch.Draw(button, level3, Color.Blue);
            SpriteBatch.DrawString(font, "3", new Vector2(level3.X + 12, level3.Y + 12), Color.Red, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            SpriteBatch.Draw(button, level4, Color.Blue);
            SpriteBatch.DrawString(font, "4", new Vector2(level4.X + 12, level4.Y + 12), Color.Red, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }
    }
}
