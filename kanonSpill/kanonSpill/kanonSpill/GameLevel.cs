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
    public class GameLevel : GameState
    {
        public static GameLevel Instance = null;
        public Cannon niceCannon = null;
        public Cannon badCannon = null;
        public Ball niceBall = null;
        public Ball badBall = null;
        public Target target = null;
        public Rectangle shoot;
        Texture2D fireButtonTexture;
        protected List<GameObject> Objects = new List<GameObject>();
        public int score;

        public GameLevel(SpriteBatch spriteBatch, ContentManager content)
            : base(spriteBatch, content)
        {
            Instance = this;
            
            // TODO: use Content to load your game content here
           // background = Content.Load<Texture2D>("Images/woodTable");
            fireButtonTexture = Content.Load<Texture2D>(@"Images\fireButton");

            niceCannon = new Cannon(Content.Load<Texture2D>("Images/kanon"), new Vector2(240, 784), new Vector2(0, -1));
            badCannon = new Cannon(Content.Load<Texture2D>("Images/slemKanon"), new Vector2(240, 16), new Vector2(0, 1));
            niceBall = new Ball(Content.Load<Texture2D>("Images/ball"));
            badBall = new Ball(Content.Load<Texture2D>("Images/slemBall"));
            target = new Target(Content.Load<Texture2D>("Images/mål"));
            shoot = new Rectangle(480 - 48, 450, 48, 48);
            
            
        }

        public override void Update()
        {
            score = (int)niceBall.Velocity.Length() * 100;

            if (!niceCannon.hasShot)
            {

                if (!niceCannon.placing && !niceCannon.aiming &&
                    Mouse.GetState().LeftButton == ButtonState.Pressed &&
                    shoot.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                {

                    niceCannon.Fire(niceBall);
                    badCannon.Fire(badBall);
                }
                else
                {
                    badCannon.Direction = niceCannon.Direction * new Vector2(1, -1);
                    badCannon.Position = new Vector2(niceCannon.Position.X, badCannon.Position.Y);
                    niceCannon.Control();
                    badCannon.updateRotation();
                }

            }
            else
            {
                foreach (SolidObstacle o in Objects)
                {
                    niceBall.obstacleCollision(o);
                    badBall.obstacleCollision(o);
                }
                
                niceBall.update();
                badBall.update();
                if ((niceBall.Position - target.Position).Length() < target.radius - niceBall.radius && niceCannon.hasShot)
                {
                    bool win = true;
                    //Win
                }
                if ((niceBall.Position - badBall.Position).Length() < (niceBall.radius + badBall.radius) && niceCannon.hasShot)
                {
                    bool lose = true;
                    //lose
                }
            }
        }

        public override void Draw()
        {
            //SpriteBatch.Draw(background, Vector2.Zero, Color.White);
            target.Draw(SpriteBatch);
            niceBall.Draw(SpriteBatch);
            badBall.Draw(SpriteBatch);
            niceCannon.Draw(SpriteBatch);
            badCannon.Draw(SpriteBatch);
            SpriteBatch.Draw(fireButtonTexture, shoot, Color.White);
            
        }

    }
}
