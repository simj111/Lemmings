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
using Lemmings.Astar;
using Lemmings.Scene;
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
        ParticleEngine particleEngine2;
        InputManager inputManager;
        ObjectManager kObjectManager;
        ObjectFactory kObjectFactory;
        Renderer kRenderer;
        SceneManager kSceneManager;
        AStarSearch search;
        MouseState mouseState;

        Node[] nodeArray;
        const int GRID_SIZE = 16;
        int element;
        private int xVar;
        private int yVar;
        Node start;
        Node goal;
        Node blocked;
        Texture2D nodePath;

        // Create an instance of Texture2D that will contain the background texture.
        Texture2D background;
        Texture2D defaultLemmingSheet;
        Texture2D spiderEnemySheet;
        Texture2D floorSheet;
        Texture2D edgeTopBottom;
        Texture2D edgeLeftRight;
        Texture2D gate;

        List<Tuple<Texture2D, string>> allSheets = null;
        Rectangle mainFrame;
        #endregion DataMembers

        #region Constructor
        public Kernel()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
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
            
            allSheets = new List<Tuple<Texture2D, string>>();
            kObjectFactory = new ObjectFactory();
            kSceneManager = new SceneManager();
            start = new Node();
            goal = new Node();
            blocked = new Node();

            

            search = new AStarSearch();

            nodeArray = new Node[256];

            for (int i = 0; i < 256; i++)
            {
                nodeArray[i] = new Node();
                nodeArray[i].element = i;

            }
            base.Initialize();
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    nodeArray[i * (GRID_SIZE) + j].position = new Vector2(xVar, yVar);
                    nodeArray[i * (GRID_SIZE) + j].texture = Content.Load<Texture2D>("griddefault");
                    xVar += nodeArray[i * (GRID_SIZE) + j].texture.Width;
                }
                xVar = 0;
                yVar += 50;
            }
            start = nodeArray[124];
            start.texture = Content.Load<Texture2D>("gridgreen");

            goal = nodeArray[34];
            goal.texture = Content.Load<Texture2D>("gridred");

            nodePath = Content.Load<Texture2D>("gridwhite");
            for (int num = 49; num < 55; num++)
            {
                blocked = nodeArray[num];
                blocked.texture = Content.Load<Texture2D>("gridblue");
                blocked.blocked = true;
            }
            //search.Search(nodeArray, start, goal, goal.texture, nodePath);


            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("ourlevel");

            //For testing purposes until we know where to load the textures from.
            defaultLemmingSheet = Content.Load<Texture2D>("Lemmings_Sheet_1");
            allSheets.Add(Tuple.Create(defaultLemmingSheet, "LemmingSheet"));

            spiderEnemySheet = Content.Load<Texture2D>("spider");
            allSheets.Add(Tuple.Create(spiderEnemySheet, "SpiderSheet"));

            floorSheet = Content.Load<Texture2D>("platform");
            allSheets.Add(Tuple.Create(floorSheet, "FloorSheet"));

            edgeTopBottom = Content.Load<Texture2D>("topbottom");
            allSheets.Add(Tuple.Create(edgeTopBottom, "EdgeTopBottom"));

            edgeLeftRight = Content.Load<Texture2D>("leftright");
            allSheets.Add(Tuple.Create(edgeLeftRight, "EdgeLeftRight"));

            gate = Content.Load<Texture2D>("gate");
            allSheets.Add(Tuple.Create(gate, "Gate"));

            //particles stuff which needs to be moved, partial tutorial done.
            mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            List<Texture2D> textures = new List<Texture2D>();
            textures.Add(Content.Load<Texture2D>("red"));
            textures.Add(Content.Load<Texture2D>("yellow"));
            textures.Add(Content.Load<Texture2D>("orange"));
            particleEngine = new ParticleEngine(textures, new Vector2(400, 240));
            particleEngine2 = new ParticleEngine(textures, new Vector2(400, 240));

            kRenderer = new Renderer(spriteBatch, allSheets); //The spritesheet and batch will definitely need to be passed in somewhere else. NEED TO DISCUSS!
            kObjectManager = new ObjectManager(kObjectFactory, kRenderer, kSceneManager);
            inputManager = new InputManager(kObjectManager);
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

           


            particleEngine.EmitterLocation = new Vector2(675 ,516);
            particleEngine2.EmitterLocation = new Vector2(630, 516);
            particleEngine.Update();
            particleEngine2.Update();
            kObjectManager.UpdateEntities();
        
            base.Update(gameTime);
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



            //for (int i = 0; i < 256; i++)
            //{
            //    nodeArray[i].Draw(spriteBatch);
            //}

            //The renderer can be asked to draw things in this section i.e. renderer.DrawEntities(spriteBatch). 
            kObjectManager.CallRendererToDraw();
            particleEngine.Draw(spriteBatch);
            particleEngine2.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        #endregion Methods





    }
}
