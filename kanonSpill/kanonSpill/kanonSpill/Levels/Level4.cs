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
    public class Level4 : GameLevel
    {

        int gameLevel;
        public Level4(SpriteBatch spriteBatch, ContentManager content, int gameStateIndex)
            : base(spriteBatch, content, gameStateIndex)
        {
            /* TODO: Her/slik legges alle objektene inn
            Eks :
            Objects.Add(new SolidObstacle(Content.Load<Texture2D>("Images/blokk1"), new Vector2(120, 150), 200, 80));
            Objects.Add(new SolidObstacle(Content.Load<Texture2D>("Images/blokk2"), new Vector2(0, 260),  150, 50, 1f,'Y', 50));
            Objects.Add(new SolidObstacle(Content.Load<Texture2D>("Images/blokk3"), new Vector2(0, 430), 150, 50, 2f, 'X', 150));
            */

            Objects.Add(new SolidObstacle(Content.Load<Texture2D>("Images/blokk1"), new Vector2(50, 400), 70, 40, 3f, 'X', 120));
            Objects.Add(new SolidObstacle(Content.Load<Texture2D>("Images/blokk2"), new Vector2(10, 300), 140, 60));
            Objects.Add(new SolidObstacle(Content.Load<Texture2D>("Images/blokk1"), new Vector2(50, 200), 70, 40, 3f, 'X', 120));


            //  TODO: Sett inn prefererte posisjonsverdien til målet her. (Radiuseen til målet er 32, posisjonen settes i forhold til dens sentrum)
            target.Position = new Vector2(40, 260);
            gameLevel = gameStateIndex;
        }

        public override void Draw()
        {
            base.Draw();
            foreach (SolidObstacle o in Objects)
            {
                o.Draw(SpriteBatch);
            }

        }


        public override void Update()
        {
            CannonGame.PreviousLevel = gameLevel;

            base.Update();
            foreach (SolidObstacle o in Objects)
            {
                o.Update();
            }
        }
    }
}
