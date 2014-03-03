using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Lemmings.Roles;


namespace Lemmings.Objects
{
    class Lemming : ParentObject
    //Expands on the ParentObject class and sets values to properties from ParentObject.
    //Adds it's own new ones.
    //Will use the "Roles" class. (To assign roles to lemmings?)
        // Will need to be able to specify the different lemmings, I.E if there are 10 created, which will change role when interacted with. ID?)
    {
        
        //----- Constructor -----
        public Lemming(string ID)
        {
            _position = new Vector2(400, 40);
            _spriteRectangle = new Rectangle(22, 0, 5, 10);
            _isSolid = false;
            _objectID = ID;
            speedX = 1f;
            speedY = 1f;

            //When a lemming is first created it is in a "default" role
            roleName = "Default";
          ParentRole currentRole = new Default();
        }

        //----- Properties -----
        //Needed for the set in position override.
        //Underscore is good code practice for private variables that are used for get and set.
        private Vector2 _position; 
        public override Vector2 position
        {
            get { return _position; }
            set { _position = value; }
        }

        private Rectangle _spriteRectangle;
        public override Rectangle spriteRectangle
        {
            get { return _spriteRectangle; }
            set { _spriteRectangle = value;}
        }

        public override Color colour
        {
            get { return Color.White; }
        }

        private bool _isSolid;
        public override bool isSolid
        {
            get { return _isSolid; }
            set { _isSolid = value; }
        }

        private string _objectID;
        public override string objectID
        {
            get { return _objectID; }
            set { _objectID = value; }
        }

        public string roleName;
        //Need some kind of event handler to check when roleName changes. Too tired to remember syntax now :(

        //Horizontal movement speed of the lemming.
        public float speedX;

        //How fast the lemming falls.
        public float speedY;

        //----- Methods -----
        public override void DrawSelf(SpriteBatch sBatch, Texture2D texture)
        {
            base.DrawSelf(sBatch, texture);
        }

        public void Terminate(string lemmingID)
        {
            //Code to terminate the current lemming based off its ID
        }
        //Potentially something for collision and animation needs to be added into the properties and method sections.
    }
}
