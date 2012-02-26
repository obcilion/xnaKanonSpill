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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class CannonGame : Microsoft.Xna.Framework.Game
    {
        public static CannonGame Instance = null;

        public GraphicsDeviceManager Graphics;
        public SpriteBatch SpriteBatch;

        FrameInfo FrameInfo = FrameInfo.Instance;

        List<GameState> GameStates = new List<GameState>();
        public static int GameStateIndex;
        GameState ActiveGameState = null;

        GameState NextState = null;

        public static void ChangeState(int index)
        {
            if (index < CannonGame.Instance.GameStates.Count)
            {
                CannonGame.Instance.NextState = CannonGame.Instance.GameStates[index];
            }
        }
        public CannonGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Graphics.PreferredBackBufferWidth = 480;
            Graphics.PreferredBackBufferHeight = 800;

            //Gjør musepekeren synlig
            IsMouseVisible = true;

            //Dette gjør at telefonen fungerer i begge landskapsmodusene.
            Graphics.SupportedOrientations = DisplayOrientation.Portrait;

            Instance = this;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            GameStates.Add(new SimpleSplash(SpriteBatch, Content, "Images/introScreen"));
            GameStates.Add(new Level1(SpriteBatch, Content));
            GameStates.Add(new Level2(SpriteBatch, Content));
            GameStates.Add(new jaLevel3(SpriteBatch, Content));
            GameStates.Add(new jaLevel4(SpriteBatch, Content));

            ActiveGameState = GameStates[0];
            GameStateIndex = 0;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            KeyboardState stat = Keyboard.GetState();
            if (stat.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            FrameInfo.GameTime = gameTime;

            //Henter inn mouseState på starten av Update, så den ikke kan endre seg underveis
            FrameInfo.MouseState = Mouse.GetState();


            if (NextState != null)
            {
                ActiveGameState = NextState;
                ActiveGameState.Reset();
                NextState = null;
            }
            /*if (GameStateIndex == 0 && GameStates[GameStateIndex].SplashFinished)
            {
                ActiveGameState = GameStates[3];
                GameStateIndex = 3;
            }*/

            ActiveGameState.Update();


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Cyan);

            SpriteBatch.Begin(SpriteSortMode.FrontToBack,BlendState.AlphaBlend);

            ActiveGameState.Draw();

            SpriteBatch.End();

            base.Draw(gameTime);
        
        }
    }
}
