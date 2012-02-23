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

        public GameLevel(SpriteBatch spriteBatch, ContentManager content)
            : base(spriteBatch, content)
        {
            Instance = this;
            niceCannon = new Cannon(Content.Load<Texture2D>("kanon"));
            badCannon = new Cannon(Content.Load<Texture2D>("slemKanon"));

            
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
