using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CannonGame
{
    public class FrameInfo
    {
        static FrameInfo _Instance = new FrameInfo();

        public static FrameInfo Instance
        {
            get
            {
                return _Instance;
            }
        }

        private FrameInfo() { }

        //Når GameTime settes oppdaterer jeg GameTime-propertien
        GameTime _GameTime = new GameTime();
        public GameTime GameTime
        {
            get
            {
                return _GameTime;
            }

            set
            {
                _GameTime = value;
                DeltaTime = (float)GameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        //Her har jeg en property hvor jeg egentlig bare bruker tilgangsstyring. Kan med fordel byttes om til en enklere versjon.
        float _DeltaTime = 0f;
        public float DeltaTime
        {
            get
            {
                return _DeltaTime;
            }

            protected set
            {
                _DeltaTime = value;
            }
        }

        //Nåværende og forrige Mousestate. Forrige oppdateres av seg selv når man setter ny MouseState
        MouseState _MouseState;
        public MouseState MouseState
        {
            get
            {
                return _MouseState;
            }

            set
            {
                PreviousMouseState = MouseState;
                _MouseState = value;
            }
        }

        public MouseState PreviousMouseState { get; set; }
    }
}
