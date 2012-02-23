using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

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
        FrameInfo FrameInfo = FrameInfo.Instance;

        public GameLevel(SpriteBatch spriteBatch, ContentManager content)
            : base(spriteBatch, content)
        {
            Instance = this;
            niceCannon = new Cannon(Content.Load<Texture2D>("Images/kanon"),new Vector2(240,784),new Vector2(0,-1));
            badCannon = new Cannon(Content.Load<Texture2D>("Images/slemKanon"), new Vector2(240, 16), new Vector2(0, 1));
            niceBall = new Ball(Content.Load<Texture2D>("Images/ball"));
            badBall = new Ball(Content.Load<Texture2D>("Images/slemBall"));
            target = new Target(Content.Load<Texture2D>("Images/mål"));

            
            // TODO: use Content to load your game content here
        }

        public override void Update()
        {
            niceCannon.Update();
            badCannon.Update();
            niceCannon.Direction = new Vector2(FrameInfo.MouseState.X - niceCannon.Position.X, FrameInfo.MouseState.Y - niceCannon.Position.Y);
            badCannon.Direction = new Vector2(FrameInfo.MouseState.X - badCannon.Position.X, FrameInfo.MouseState.Y - badCannon.Position.Y);
        }

        public override void Draw()
        {
            niceCannon.Draw(SpriteBatch);
            badCannon.Draw(SpriteBatch);
        }
    }
}
