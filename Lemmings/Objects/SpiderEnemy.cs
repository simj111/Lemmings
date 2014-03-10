using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace Lemmings.Objects
{
    class SpiderEnemy : ParentObject
    {
         #region DataMembers

        private Vector2 _position; //Needed for the set in position override. Underscore is good code practice for private variables that are used for get and set.
        private Rectangle _spriteRectangle;
        private float _rotation;
        private SpriteEffects _spriteEffect;
        private bool _isSolid;
        private int _objectID;
        private bool _isUpdatable;

        private Vector2 direction;
        private Vector2 velocity;
        private Vector2 desiredVelocity;
        private Vector2 steeringForce;
        private float mass = 50f;
        private float maxForce = 0.3f;
        public float speedX; //Horizontal movement speed of the spider.
        public float speedY; //Vertical speed of spider.
        public float Velocity;
        private float maxVelocity = 2f;
        private Vector2 lemmingposition;

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

        public override float rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        public override Vector2 origin
        {
            get { return new Vector2(_spriteRectangle.Height / 2, _spriteRectangle.Width / 2); }
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
        #endregion Properties

        #region Constructor

        public SpiderEnemy(int ID)
        {
            _position = new Vector2(625, 375);
            _spriteRectangle = new Rectangle(0, 1, 33, 32);
            _rotation = 0;
            _spriteEffect = SpriteEffects.None;
            _isSolid = false;
            _objectID = ID;
            _isUpdatable = true;

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

        public void Terminate(int SpiderEnemyID)
        {
            //Code to terminate the current spider based off its ID
        }

        public override void Move()
        {
            lemmingposition = new Vector2(115, 130);
            direction = lemmingposition - _position;
            direction.Normalize();

            Seek(position);
            _position += velocity;

            _rotation = (float)Math.Atan2(velocity.X, velocity.Y);

        }

        public void Seek(Vector2 myPos)
        {
            velocity = direction * maxVelocity;
            desiredVelocity = velocity;
            steeringForce = desiredVelocity - velocity;

            steeringForce = CheckMax(steeringForce, maxForce);
            steeringForce /= mass;

            velocity += steeringForce;
            velocity = CheckMax(velocity, maxVelocity);
        }

        public Vector2 CheckMax(Vector2 vector, float cap)
        {
            float x = cap - vector.Length();
            if (x < 1.0)
            {
                x = 1.0f;
            }
            vector.X += x;
            vector.Y += x;
            return vector;
        }
        
       
        
        #endregion Methods
        





    }
}
