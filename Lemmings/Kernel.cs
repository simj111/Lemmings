﻿#region Using Statements
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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Create an instance of Texture2D that will contain the background texture.
        Texture2D background;
        Texture2D defaultLemmingSheet;
        Rectangle mainFrame;

        //LEMMING POSITION TEST
        Lemming lem1;
        public Kernel()
            : base()
        {

                graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
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
            lem1 = new Lemming("1");
            base.Initialize();
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

            mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);


            // TODO: use this.Content to load your game content here
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

            // TODO: Add your update logic here

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

            //The renderer can be asked to draw things in this section i.e. renderer.DrawEntities(spriteBatch). 
            lem1.DrawSelf(spriteBatch, defaultLemmingSheet);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
