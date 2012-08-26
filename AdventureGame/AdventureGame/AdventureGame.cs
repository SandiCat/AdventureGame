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

using Sandi_s_Way;
using Debugging;

namespace AdventureGameNamespace
{
    public class AdventureGame : Microsoft.Xna.Framework.Game
    {
        //Basic game info:
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static GraphicsDevice Device;

        //The debug console:
        public static DebugConsole Console;

        //References:

        public AdventureGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Device = graphics.GraphicsDevice;

            //Initialize game info:
            graphics.PreferredBackBufferWidth = 620;
            graphics.PreferredBackBufferHeight = 500;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "AdvetureGame";

            //Initialize the static classes:
            ObjectManager.Initialize();

            //Initialize the debug console:
            Console = new DebugConsole(spriteBatch, new Vector2(0, 0));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Initialize the GameInfo:
            GameInfo.RefSpriteBatch = spriteBatch;
            GameInfo.RefDevice = Device;
            GameInfo.RefDeviceManager = graphics;
            GameInfo.RefContent = Content;
            GameInfo.RefConsole = Console;

            //Initialize the texture container:
            TextureContainer.Initialize();

            //Initalize the grid:
            Grid.Initialize(40);

            //Load fonts:
            Console.Font = Content.Load<SpriteFont>("DebuggConsoleFont");

            //Initialize default sprites:
            TextureContainer.DefaultTextures[typeof(SolidObject)] = TextureContainer.ColoredRectangle(Color.Black, Grid.SquareSide, Grid.SquareSide);
            TextureContainer.DefaultTextures[typeof(Player)] = TextureContainer.ColoredRectangle(Color.Yellow, Grid.SquareSide, Grid.SquareSide);

            //Load sounds:

            //Create game objects:
            TileObjectCreator.CreateWithinGrid(
                new Dictionary<char,Type>()
                {
                    {'w', typeof(SolidObject)},
                    {'p', typeof(Player)},
                    {'.', null}
                },
                new string[]{
                    "wwwwwwwwwwwwww",
                    "w............w",
                    "w............w",
                    "w............w",
                    "w............w",
                    "w.....p......w",
                    "w............w",
                    "w............w",
                    "w............w",
                    "w............w",
                    "w............w",
                    "wwwwwwwwwwwwww"
                });

            //Make a reference to the UI objects: (so that other objects can interact with them)
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            ObjectManager.UpdateAll();
            Console.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            spriteBatch.Begin();
            ObjectManager.DrawAll();
            Console.WriteConsole();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
