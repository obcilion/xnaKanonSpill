using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace cannonGame
{
    public class Level1 : GameState
    {
        public static Level1 Instance = null;

        List<GameObject> Objekter = new List<GameObject>();

        List<GameObject> KollisjonsObjekter = new List<GameObject>();


        public Level1(SpriteBatch spriteBatch, ContentManager content)
            : base(spriteBatch, content)
        {
            Instance = this;

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
