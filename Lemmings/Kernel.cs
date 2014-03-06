#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Lemmings.Objects;
using Lemmings.Interfaces;
using Lemmings.Managers;
#endregion

namespace Lemmings
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Kernel : Game
    //Kernel will be used to initialise and create stuff, factory, managers etc.
    {
        #region DataMembers
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ParticleEngine particleEngine;
        InputManager inputManager;
        ObjectManager kObjectManager;
        ObjectFactory kObjectFactory;
        Renderer kRenderer;

        // Create an instance of Texture2D that will contain the background texture.
        Texture2D background;
        Texture2D defaultLemmingSheet;
        Rectangle mainFrame;
        #endregion DataMembers

        #region Constructor
        public Kernel()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }
        #endregion Constructor

        #region Methods
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            inputManager = new InputManager();
            
            kObjectFactory = new ObjectFactory();
            
            base.Initialize();
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("ourlevel");

            //For testing purposes until we know where to load the textures from.
            defaultLemmingSheet = Content.Load<Texture2D>("Lemmings_Sheet_1");

            //particles stuff which needs to be moved, partial tutorial done.
            mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            List<Texture2D> textures = new List<Texture2D>();
            textures.Add(Content.Load<Texture2D>("red"));
            textures.Add(Content.Load<Texture2D>("yellow"));
            textures.Add(Content.Load<Texture2D>("orange"));
            particleEngine = new ParticleEngine(textures, new Vector2(400, 240));
           
            kRenderer = new Renderer(spriteBatch, defaultLemmingSheet); //The spritesheet and batch will definitely need to be passed in somewhere else. NEED TO DISCUSS!
            kObjectManager = new ObjectManager(kObjectFactory, kRenderer);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            inputManager.update();
            
            // TODO: Add your update logic here
            base.Update(gameTime);
           
            //Particle engine initialisation
            //particleEngine.EmitterLocation = new Vector2(300,300);
           // particleEngine.Update();
            kObjectManager.UpdateEntities();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(background, mainFrame, Color.White);
            particleEngine.Draw(spriteBatch);
            
            //The renderer can be asked to draw things in this section i.e. renderer.DrawEntities(spriteBatch). 
            kObjectManager.CallRendererToDraw();
            spriteBatch.End();
            base.Draw(gameTime);
        }
        #endregion Methods
        
        
        

       
    }
}
