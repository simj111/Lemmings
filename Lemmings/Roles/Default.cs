using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Lemmings.Objects;
using Lemmings.Interfaces;

namespace Lemmings.Roles
{
    class Default : ParentRole, IRole
    {
        //This will be the standard behaviour role that the lemmings will take untill they are interacted with. This will have to interact with the A* algorithm.
        #region DataMembers
        Lemming controlledLemming;
        Vector2 newPos; //This is needed to change the position of lemming through role, as you can't be specific with Y and X values of Lemming Position.
        #endregion DataMembers

        #region Properties

        #endregion Properties

        #region Constructor
        public Default(Lemming myLemming)
        {
            controlledLemming = myLemming;
            newPos = controlledLemming.position;
        }
        #endregion Constructor

        #region Methods
        //This method will update the lemming in a way specific to the role. As this is default it will only make it move by whatever speed y and x we have preset in the Lemming class.
        public void UpdateLemming()
        {
            newPos.Y += controlledLemming.speedY;

            controlledLemming.position = newPos;
        }

        public void ChangeLemmingSprite()
        {
            
        }
        #endregion Methods

        
    }
}
