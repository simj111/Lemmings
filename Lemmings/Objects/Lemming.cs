using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Lemmings.Roles;
using Lemmings.Interfaces;


namespace Lemmings.Objects
{
    class Lemming : ParentObject
    //Expands on the ParentObject class and sets values to properties from ParentObject.
    //Adds it's own new ones.
    //Will use the "Roles" class. (To assign roles to lemmings?)
        // Will need to be able to specify the different lemmings, I.E if there are 10 created, which will change role when interacted with. ID?)
    {
        #region DataMembers
        private Vector2 _position; //Needed for the set in position override. Underscore is good code practice for private variables that are used for get and set.
        private Rectangle _spriteRectangle; 
        private bool _isSolid;
        private int _objectID;
        public string roleName;
        private string changeJob;
        //Need some kind of event handler to check when roleName changes. Too tired to remember syntax now :(
        public float speedX; //Horizontal movement speed of the lemming.
        public float speedY; //How fast the lemming falls.
        public IRole currentRole;
        #endregion DataMembers

        #region Properties
        public override Vector2 position
        {
            get { return _position; }
            set { _position = value; }
        }

        public override Rectangle spriteRectangle
        {
            get { return _spriteRectangle; }
            set { _spriteRectangle = value;}
        }

        public override Color colour
        {
            get { return Color.White; }
        }

        public override bool isSolid
        {
            get { return _isSolid; }
            set { _isSolid = value; }
        }
       
        public override int objectID
        {
            get { return _objectID; }
            set { _objectID = value; }
        }
        #endregion Properties

        #region Constructor
        public Lemming(int ID)
        {
            _position = new Vector2(400, 40);
            _spriteRectangle = new Rectangle(22, 0, 5, 10);
            _isSolid = false;
            _objectID = ID;
            speedX = 1f;
            speedY = 0.5f;

            //When a lemming is first created it is in a "default" role
            roleName = "Default";
            currentRole = new Default(this) as IRole;
        }
        #endregion Constructor

        #region Methods
        public override void DrawSelf(SpriteBatch sBatch, Texture2D texture)
        {
            base.DrawSelf(sBatch, texture);
        }

        public override int ReturnObjectID()
        {
            return base.ReturnObjectID();
        }

        public void Terminate(int lemmingID)
        {
            //Code to terminate the current lemming based off its ID
        }

        //When a mouse clicks a lemming we can make a string get passed to a lemming that says which role it needs to switch too
        //The lemming would then change it's current role to be whatever string is pased in e.g. blocker
        public void ChangeRole(string roleChange)
        {
            changeJob = roleChange;
            if (changeJob == "Blocker")
            {
                roleName = changeJob;
                currentRole = new Blocker(this);

            }

        }
        //Potentially something for collision and animation needs to be added into the properties and method sections.
        #endregion Methods
        
    }
}
