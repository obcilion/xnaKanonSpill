﻿using System;
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
    public class GameLevel : GameState //Skrevet av Ketil Almquist med litt fra Jan Arild Brobak
    {
        public static GameLevel Instance = null;
        public Cannon niceCannon = null;
        public Cannon badCannon = null;
        public Ball niceBall = null;
        public Ball badBall = null;
        public Target target = null;
        public Rectangle shoot;
        Texture2D fireButtonTexture;
        protected List<GameObject> Objects;
        SpriteFont Font;
        public int score;
        
        SoundEffect win;
        SoundEffect lose;
<<<<<<< HEAD
        public GameLevel(SpriteBatch spriteBatch, ContentManager content, int gameStateIndex)
            : base(spriteBatch, content, gameStateIndex)
        {
            Instance = this;
            
            // TODO: use Content to load your game content here
           // background = Content.Load<Texture2D>("Images/woodTable");
            fireButtonTexture = Content.Load<Texture2D>(@"Images\fireButton");

            Font = Content.Load<SpriteFont>("Font");

            win = Content.Load<SoundEffect>("Sound/Cannon_Game_Win");
            lose = Content.Load<SoundEffect>("Sound/Cannon_Game_Lose");

            niceCannon = new Cannon(Content.Load<Texture2D>("Images/kanon"), new Vector2(240, 784), new Vector2(0, -1));
            badCannon = new Cannon(Content.Load<Texture2D>("Images/slemKanon"), new Vector2(240, 16), new Vector2(0, 1));
            niceBall = new Ball(Content.Load<Texture2D>("Images/ball"));
            badBall = new Ball(Content.Load<Texture2D>("Images/slemBall"));
            target = new Target(Content.Load<Texture2D>("Images/mål"));
            shoot = new Rectangle(480 - 48, 450, 48, 48);
            score = 0;
            Objects = new List<GameObject>();
            
        }
        public override void Reset()
        {
            niceCannon = new Cannon(Content.Load<Texture2D>("Images/kanon"), new Vector2(240, 784), new Vector2(0, -1));
            badCannon = new Cannon(Content.Load<Texture2D>("Images/slemKanon"), new Vector2(240, 16), new Vector2(0, 1));
            niceBall = new Ball(Content.Load<Texture2D>("Images/ball"));
            badBall = new Ball(Content.Load<Texture2D>("Images/slemBall"));
            score = 0;
        }
        public override void Update()
        {

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
                score = (int)(niceBall.Velocity.Length() * 1000);
                niceBall.update();
                badBall.update();
                if ((niceBall.Position - target.Position).Length() < target.radius - niceBall.radius && niceCannon.hasShot)
                {
                    win.Play();
                    Reset();
                    //Win
                }
                if (((niceBall.Position - badBall.Position).Length() < (niceBall.radius + badBall.radius) || niceBall.Velocity == Vector2.Zero) && niceCannon.hasShot)
                {
                    lose.Play();
                    Reset();
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
            SpriteBatch.Draw(fireButtonTexture, shoot,null, Color.White,0,Vector2.Zero,SpriteEffects.None,1);
            SpriteBatch.DrawString(Font, "Score: " + score.ToString(), new Vector2(15, 15), Color.Red,0,Vector2.Zero,1f,SpriteEffects.None,1f);
            
        }

    }
}
