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

        //  Lag nye objecter her/slik:


        SolidObstacle so1;
        MovingObstacle mo1;
        MovingObstacle mo2;

        public Level1(SpriteBatch spriteBatch, ContentManager content)
            : base(spriteBatch, content)
        {
            // TODO: Her/slik legges alle verdiene inn

            so1 = new SolidObstacle(Content.Load<Texture2D>("Images/blokk1"), new Vector2(120, 150), 200, 80);
            mo1 = new MovingObstacle(Content.Load<Texture2D>("Images/blokk2"), new Vector2(0, 260),  150, 50, 1f,'Y', 50);
            mo2 = new MovingObstacle(Content.Load<Texture2D>("Images/blokk3"), new Vector2(0, 430), 150, 50, 2f, 'X', 150);


            //  TODO: Sett inn prefererte posisjonsverdien til målet her
            target.Position = new Vector2(200, 100);
        }
        
        public override void Draw()
        {
            base.Draw();

            // TODO: Alle objektene må legges inn her/slik for at de skal bli tegnet
            so1.Draw(SpriteBatch);
            mo1.Draw(SpriteBatch);
            mo2.Draw(SpriteBatch);
        }


        public override void Update()
        {
            base.Update();

            // TODO: Bevegelige objekter må legges in her
            mo1.Update();
            mo2.Update();
        }
    }
}
