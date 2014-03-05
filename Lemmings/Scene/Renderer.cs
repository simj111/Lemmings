using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Lemmings.Interfaces;
using Lemmings.Objects;

namespace Lemmings
{
    class Renderer : IRenderer
    //Used to render the most up to date frames on screen.
    //Gets a list of current entities that need to be drawn from manager(Not sure yet if render manager or entity manager?) NEED TO DISCUSS!
    {
        #region DataMembers
        SpriteBatch mySpriteBatch;
        Texture2D currentSpriteSheet;
        #endregion DataMembers

        #region Properties
        
        #endregion Properties

        #region Constructor
        public Renderer(SpriteBatch sBatch, Texture2D spriteSheet) //The spritesheet is gonna need to be passed to the entity somehow at a later point.
        {
            mySpriteBatch = sBatch;
            currentSpriteSheet = spriteSheet;
        }
        #endregion Constructor

        #region Methods
        public void DrawEntities(IList<ParentObject> CurrentEntitiesToDraw)
        {
            foreach (ParentObject drawableObject in CurrentEntitiesToDraw)
            {
                drawableObject.DrawSelf(mySpriteBatch,currentSpriteSheet);
            }
        }

        #endregion Methods
    }
}
