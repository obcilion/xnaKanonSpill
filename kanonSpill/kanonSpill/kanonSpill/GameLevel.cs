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
        public BadCannon badCannon = null;
        public Ball niceBall = null;
        public Ball badBall = null;
        public Target target = null;

        public GameLevel(SpriteBatch spriteBatch, ContentManager content)
            : base(spriteBatch, content)
        {
            Instance = this;
            niceCannon = new Cannon(Content.Load<Texture2D>("Images/kanon"));
            badCannon = new BadCannon(Content.Load<Texture2D>("Images/slemKanon"));
            niceBall = new Ball(Content.Load<Texture2D>("Images/ball"));
            badBall = new Ball(Content.Load<Texture2D>("Images/slemBall"));
            target = new Target(Content.Load<Texture2D>("Images/mål"));

            
            // TODO: use Content to load your game content here
        }

        public override void Update()
        {

        }

        public override void Draw()
        {
        }
    }
}
