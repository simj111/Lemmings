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
    //Gets a list of current entities that need to be drawn from ObjectManager, which is acquired from the SceneManager
    {
        #region DataMembers
        SpriteBatch mySpriteBatch;
        List<Tuple<Texture2D, string>> currentSpriteSheets = null;
        string objectName;
        string sheetName;
        #endregion DataMembers

        #region Properties
        
        #endregion Properties

        #region Constructor
        public Renderer(SpriteBatch sBatch, List<Tuple<Texture2D, string>> allSpriteSheets) //The spritesheet is gonna need to be passed to the entity somehow at a later point.
        {
            mySpriteBatch = sBatch;
            currentSpriteSheets = allSpriteSheets;
        }
        #endregion Constructor

        #region Methods
        public void DrawEntities(IList<ParentObject> CurrentEntitiesToDraw)
        {
            foreach (ParentObject drawableObject in CurrentEntitiesToDraw)
            {
                objectName = drawableObject.ToString();

                if (objectName.Contains("Spider"))
                {

                    foreach (Tuple<Texture2D, string> sheets in currentSpriteSheets)
                    {
                        if (sheets.Item2.Contains("Spider"))
                        {
                            drawableObject.DrawSelf(mySpriteBatch, sheets.Item1);
                        }
                    }
                }

                else if (objectName.Contains("Floor"))
                {
                    foreach (Tuple<Texture2D, string> sheets in currentSpriteSheets)
                    {
                        if (sheets.Item2.Contains("Floor"))
                        {
                            drawableObject.DrawSelf(mySpriteBatch, sheets.Item1);
                        }
                    }
                }

                else if (objectName.Contains("Edge"))
                {
                    foreach (Tuple<Texture2D, string> sheets in currentSpriteSheets)
                    {
                        if (sheets.Item2.Contains("EdgeTopBottom"))
                        {
                            drawableObject.DrawSelf(mySpriteBatch, sheets.Item1);
                        }
                        else if (sheets.Item2.Contains("EdgeLeftRight"))
                        {
                            drawableObject.DrawSelf(mySpriteBatch, sheets.Item1);
                        }
                    }
                }
                else if (objectName.Contains("Gate"))
                {
                    foreach (Tuple<Texture2D, string> sheets in currentSpriteSheets)
                    {
                        if (sheets.Item2.Contains("Gate"))
                        {
                            drawableObject.DrawSelf(mySpriteBatch, sheets.Item1);
                        }
                    }
                }

                else if (objectName.Contains("Lemming"))
                {

                    foreach (Tuple<Texture2D, string> sheets in currentSpriteSheets)
                    {
                        if (sheets.Item2.Contains("Lemming"))
                        {
                            drawableObject.DrawSelf(mySpriteBatch, sheets.Item1);
                        }
                    }
                }


            }
        }

        #endregion Methods
    }
}
