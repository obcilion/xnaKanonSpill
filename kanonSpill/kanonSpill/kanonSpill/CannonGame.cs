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
        GameState ActiveGameState = null;

        GameState NextState = null;

        //Ball niceBall;
        //Cannon niceCannon;

        //Rectangle fireButton;
        //Texture2D fireButtonTexture;
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
            this.IsMouseVisible = true;

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

            GameStates.Add(new Menu(SpriteBatch, Content,"Images/woodTable"));
            GameStates.Add(new GameLevel(SpriteBatch, Content));

            ActiveGameState = GameStates[1];

            // TODO: use this.Content to load your game content here
            //Texture2D niceBallTexture = Content.Load<Texture2D>(@"Images\ball");
            //Texture2D niceCannonTexture = Content.Load<Texture2D>(@"Images\kanon");
            //Texture2D fireButtonTexture = Content.Load<Texture2D>(@"Images\skyt");

            //fireButton = new Rectangle(480 - 64, 450, 64, 128);
            //niceCannon = new Cannon(niceCannonTexture);
            //niceBall = new Ball(niceBallTexture, niceCannon);

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
                NextState = null;
            }

            ActiveGameState.Update();

            /*if (!niceCannon.placing && !niceCannon.aiming &&
                Mouse.GetState().LeftButton == ButtonState.Pressed &&
                fireButton.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                niceCannon.HasShot = true;
            
            niceBall.update();
            niceCannon.update(gameTime);*/

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            SpriteBatch.Begin();

            ActiveGameState.Draw();

            SpriteBatch.End();

            base.Draw(gameTime);

            /*if (!niceCannon.HasShot)
            {
                SpriteBatch.Begin();
                SpriteBatch.Draw(fireButtonTexture, fireButton, Color.White);
                SpriteBatch.End();
            }

            if(niceCannon.HasShot)
            niceBall.Draw(SpriteBatch);

            if(!niceCannon.HasShot)
            niceCannon.Draw(SpriteBatch);

            

            base.Draw(gameTime);*/
        }
    }
}
