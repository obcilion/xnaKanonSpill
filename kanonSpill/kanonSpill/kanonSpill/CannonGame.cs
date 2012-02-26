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

/*Bakgrunnsbilder laget av �ystein Anthonsen
 * Spillsprites laget av Raymond Gulbrandsen
 * Lyder laget av Jan Arild Broboak
 * Konsept laget av alle
 * 
 * Noe problemer p� gruppa...
 * Bare noen timer til s� hadde dette "spillet blitt ganske mer komplett"
 */



namespace CannonGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class CannonGame : Microsoft.Xna.Framework.Game //Skrevet hovedsaklig av Ketil Almquist, Jan Arild Brobak, �ystein Anthonsen, J�rund Mj�set Bogen og Raymond Gulbrandsen
    {
        public static CannonGame Instance = null;

        public GraphicsDeviceManager Graphics;
        public SpriteBatch SpriteBatch;

        FrameInfo FrameInfo = FrameInfo.Instance;

        public static bool ExitGame = false;

        List<GameState> GameStates = new List<GameState>();
        GameState ActiveGameState = null;

        GameState NextState = null;
        public static int PreviousLevel;


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

            //Gj�r musepekeren synlig
            IsMouseVisible = true;

            //Dette gj�r at telefonen fungerer i begge landskapsmodusene.
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

            GameStates.Add(new SimpleSplash(SpriteBatch, Content, "Images/introScreen", 0));
            GameStates.Add(new menuSplash(SpriteBatch, Content, "Images/menu", 
                "Images/playButton", "Images/howToPlayButton", "Images/creditsButton", "Images/quitButton", 1));
            GameStates.Add(new SimpleSplash(SpriteBatch, Content, "Images/howToPlay", 2));
            GameStates.Add(new SimpleSplash(SpriteBatch, Content, "Images/createdBy", 3));
            GameStates.Add(new LevelSelecter(SpriteBatch, Content, "Images/selectLevel", 4));
            GameStates.Add(new menuSplash(SpriteBatch, Content, "Images/levelCleared",
                "Images/replayButton", "Images/nextLevel", "Images/selectLevelButton2", "Images/menuButton2", 5));
            GameStates.Add(new menuSplash(SpriteBatch, Content, "Images/gameOver",
                "Images/tryAgainButton", "Images/selectLevelButton", "Images/menuButton", "Images/RAGEQUITbutton", 6));
            GameStates.Add(new Level1(SpriteBatch, Content, 7));
            GameStates.Add(new Level2(SpriteBatch, Content, 8));
            GameStates.Add(new Level3(SpriteBatch, Content, 9));
            GameStates.Add(new Level4(SpriteBatch, Content, 10));

            ActiveGameState = GameStates[0];
            
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
            if (stat.IsKeyDown(Keys.Escape) || ExitGame)
            {
                this.Exit();
            }
            FrameInfo.GameTime = gameTime;

            //Henter inn mouseState p� starten av Update, s� den ikke kan endre seg underveis
            FrameInfo.MouseState = Mouse.GetState();
            

            if (NextState != null)
            {         
                ActiveGameState = NextState;
                ActiveGameState.Reset();
                NextState = null;
            }

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
