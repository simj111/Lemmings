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
        private Rectangle _boundBox;
        private float _rotation;
        private SpriteEffects _spriteEffect;
        private bool _isSolid;
        private int _objectID;
        private bool _isUpdatable;
        private ObjectType _type;

        public string roleName;
        private string changeJob;
        //Need some kind of event handler to check when roleName changes. Too tired to remember syntax now :(
        public float speedX; //Horizontal movement speed of the lemming.
        public float speedY; //How fast the lemming falls.
        public IRole currentRole; //The role the lemming currently has assigned
       
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
            get {return new Vector2(_spriteRectangle.Height / 2, _spriteRectangle.Width / 2); }
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
        public Lemming(int ID, ObjectType myType)
        {
            _position = new Vector2(400, 500);
            _spriteRectangle = new Rectangle(22, 0, 5, 10);
            _boundBox = new Rectangle(400, 50, 5, 10);
            _rotation = 0;
            _spriteEffect = SpriteEffects.None;
            _isSolid = false;
            _objectID = ID;
            _isUpdatable = true;
            _type = myType;
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

        public override void Move()
        {
          
        }
        //Potentially something for collision and animation needs to be added into the properties and method sections.
        #endregion Methods
        
    }
}
