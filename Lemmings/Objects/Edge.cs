using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Lemmings.Objects
{
    class Edge : ParentObject
    {
        #region DataMembers

        private Vector2 _position; //Needed for the set in position override. Underscore is good code practice for private variables that are used for get and set.
        private Rectangle _spriteRectangle;
        private Rectangle _boundBox;
        private float _rotation;
        private SpriteEffects _spriteEffect;
        private bool _isSolid;
        private int _objectID;
        private bool _isUpdatable;
        private ObjectType _type;

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

        public override Rectangle boundBox
        {
            get { return _boundBox; }
            set { _boundBox = value; }
        }

        public override Color colour
        {
            get { return Color.White; }
        }

        public override float rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        public override Vector2 origin
        {
            get { return new Vector2(0,0); }
        }

        public override float scale
        {
            get { return 1; }
        }

        public override SpriteEffects spriteEffect
        {
            get { return _spriteEffect; }
            set { _spriteEffect = value; }
        }

        public override float depth
        {
            get { return 1; }
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

        public override bool isUpdatable
        {
            get { return _isUpdatable; }
            set { _isUpdatable = value; }
        }

        public override ObjectType type
        {
            get { return _type; }
        }
        #endregion Properties

        #region Constructor

        public Edge(string edgeSide, int ID, ObjectType myType)
        {
            switch (edgeSide)
            {
                case "Top":
                _position = new Vector2(0, 0);
                _spriteRectangle = new Rectangle(0, 0, 800, 49);
                _boundBox = new Rectangle(0, 0, 800, 49);
                _spriteEffect = SpriteEffects.None;
                break;

                case "Left":
                _position = new Vector2(0, 0);
                _spriteRectangle = new Rectangle(0, 0, 49, 600);
                _boundBox = new Rectangle(0, 0, 49, 600); 
                _spriteEffect = SpriteEffects.None;
                break;

                case "Right":
                _position = new Vector2(751, 0);
                _spriteRectangle = new Rectangle(0, 0, 49, 600);
                _boundBox = new Rectangle(0, 0, 49, 600); 
                _spriteEffect = SpriteEffects.FlipHorizontally;
                break;

                case "Bottom":
                _position = new Vector2(0, 551);
                _spriteRectangle = new Rectangle(0, 0, 800, 49);
                _boundBox = new Rectangle(0, 0, 800, 49);
                _spriteEffect = SpriteEffects.None;
                break;
            }
            _rotation = 0;
            _isSolid = true;
            _objectID = ID;
            _isUpdatable = false;
            _type = myType;
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

        public void Terminate(int EdgeID)
        {
            //Code to terminate the current edge based off its ID
        }

        public override void Move()
        {
        }
        #endregion Methods
    }
}
