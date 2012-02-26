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

        SpriteFont font;
        Texture2D button;
        Point mouse;

        public LevelSelecter(SpriteBatch spriteBatch, ContentManager content, String backTexture, int gameStateIndex)
            : base(spriteBatch, content, backTexture, gameStateIndex)
        {
            font = Content.Load<SpriteFont>("Font");
            button = Content.Load<Texture2D>("Images/whiteButton");

            level1 = new Rectangle(180, 400, 120, 50);
            level2 = new Rectangle(180, 470, 120, 50);
            level3 = new Rectangle(180, 540, 120, 50);
            level4 = new Rectangle(180, 610, 120, 50);

        }
        public void update()
        {
            mouse = new Point(Mouse.GetState().X, Mouse.GetState().Y);

            if ((Frameinfo.PreviousMouseState.LeftButton == ButtonState.Pressed) &&
                (Frameinfo.MouseState.LeftButton == ButtonState.Released))
            {
                if (level1.Contains(mouse))
                    CannonGame.ChangeState(8);
                else if (level1.Contains(mouse))
                    CannonGame.ChangeState(9);
                else if (level1.Contains(mouse))
                    CannonGame.ChangeState(10);
            }
                

        }

        public override void Draw()
        {
            base.Draw();

            SpriteBatch.Draw(button, level1, Color.Blue);
            SpriteBatch.DrawString(font, "1", new Vector2(level1.X + 12, level1.Y + 12), Color.Red, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            SpriteBatch.Draw(button, level2, Color.Blue);
            SpriteBatch.DrawString(font, "2", new Vector2(level2.X + 12, level2.Y + 12), Color.Red, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            SpriteBatch.Draw(button, level3, Color.Blue);
            SpriteBatch.DrawString(font, "3", new Vector2(level3.X + 12, level3.Y + 12), Color.Red, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            SpriteBatch.Draw(button, level4, Color.Blue);
            SpriteBatch.DrawString(font, "4", new Vector2(level4.X + 12, level4.Y + 12), Color.Red, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }
    }
}
