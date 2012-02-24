using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CannonGame
{
    class Level1 : GameLevel
    {

        SolidObstacle so1;
        MovingObstacle mo1;

        public Level1(SpriteBatch spriteBatch, ContentManager content)
            : base(spriteBatch, content)
        {
            so1 = new SolidObstacle(Content.Load<Texture2D>("Images/blokk1"), new Vector2(120, 150), 300, 100);
            mo1 = new MovingObstacle(Content.Load<Texture2D>("Images/blokk2"), new Vector2(0, 260),  150, 50, 1f,'Y', 50);
            target.Position = new Vector2(30, 50);
        }

        public override void Draw()
        {
            base.Draw();
            so1.Draw(SpriteBatch);
            mo1.Draw(SpriteBatch);
        }
        public override void Update()
        {
            base.Update();
            mo1.Update();
        }
    }
}
