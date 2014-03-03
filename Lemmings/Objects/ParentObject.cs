﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Lemmings.Objects
{
    abstract class ParentObject
    //Used as parent class to all other objects e.g. lemmings, wall, floor etc.
    //Contains basic properties that all objects will need e.g. height, width, texture etc.
    {

        //Current position of object.
        public abstract Vector2 position { get; set; }

        //Selection of what sprite to use in the sprite sheet.
        public abstract Rectangle spriteRectangle { get; set; }

        //Needed in the draw method.
        public abstract Color colour { get; }

        //Defines whether an object is solid or not.
        public abstract bool isSolid { get; set; }

        //ID so that it is possible to interact with a certain object.
        public abstract string objectID { get; set; }

        //A method to actually draw the object on the screen, depending on their properties. 
        //This will be called by the Renderer.
        public virtual void DrawSelf(SpriteBatch sBatch, Texture2D texture)
        {
            sBatch.Draw(texture, position,spriteRectangle, colour);
        }

    }
}
