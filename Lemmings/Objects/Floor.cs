using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Lemmings.Objects
{
    class Floor: ParentObject
    {
        #region DataMembers

        private Vector2 _position; //Needed for the set in position override. Underscore is good code practice for private variables that are used for get and set.
        private Rectangle _spriteRectangle; 
        private bool _isSolid;
        private int _objectID;
        
        //Need some kind of event handler to check when roleName changes. Too tired to remember syntax now :(
        public float speedX; //Horizontal movement speed of the lemming.
        public float speedY; //How fast the lemming falls.
        public float Velocity;

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

        public Floor(int ID)
        {
            _position = new Vector2(200, 100);
            _spriteRectangle = new Rectangle(0, 0, 133, 14);
            _isSolid = true;
            _objectID = ID;
            speedX = 1f;
            speedY = 0.5f;
            Velocity = 0;
            
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

        public void Terminate(int FloorID)
        {
            //Code to terminate the current spider based off its ID
        }

        
       
        
        #endregion Methods
    }
}
