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
        private bool _isSolid;
        private int _objectID;
        private string side;
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

        public Edge(string edgeSide, int ID)
        {
            switch (edgeSide)
            {
                case "Top":
                _position = new Vector2(0, 0);
                _spriteRectangle = new Rectangle(0, 0, 800, 49);
                break;

                case "Left":
                _position = new Vector2(0, 0);
                _spriteRectangle = new Rectangle(0, 0, 49, 600);
                break;

                case "Right":
                _position = new Vector2(751, 0);
                _spriteRectangle = new Rectangle(0, 0, 49, 600);
                break;

                case "Bottom":
                _position = new Vector2(0, 551);
                _spriteRectangle = new Rectangle(0, 0, 800, 49);
                break;
            }
            


            _isSolid = true;
            _objectID = ID;
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
        public void Flip()
        {
            
        }

        
       
        
        #endregion Methods
    }
}
