using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Lemmings.Objects;
using Lemmings.Interfaces;

namespace Lemmings.Roles
{
    class Blocker : ParentRole, IRole
    //This will use methods and properties of the parent Role class.
    //Has it's own ones unique to it e.g. make assigned lemmings movement stop still etc.
    {
        #region DataMembers
        Lemming controlledLemming;
        #endregion DataMembers

        #region Properties
        //These will be gained from parent class
        #endregion Properties

        #region Constructor
       public Blocker(Lemming myLemming)
            
        {
            controlledLemming = myLemming;
        }
        #endregion Constructor

        #region Methods
        public void UpdateLemming()
        {
           controlledLemming.speedX = 0;
           controlledLemming.speedY = 0;
        }

        public void ChangeLemmingSprite()
        {
            //We may need to make all of the lemmings go into one sprite sheet or we will need to pass it in here as a parameter.
            //controlledLemming.spriteRectangle = new Rectangle(new rectangle coordinates);
        }

        #endregion Methods

        
    }
}
