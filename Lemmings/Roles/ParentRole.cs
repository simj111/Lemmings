using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemmings.Objects;
using Lemmings.Interfaces;

namespace Lemmings.Roles
{
    class ParentRole : IRole
    {
        //This will be the parent class for all the roles that could be added to lemmings.
        //When a role is created, that is a child from parent, they need to be passed in the lemming object that they will be controlling.
        #region DataMembers

        #endregion DataMembers

        #region Properties

        #endregion Properties

        #region Constructor
        public ParentRole()
        {
            //If we write the code to assign a role to that lemming in here any child will use it via the parent...I.e. we don't write the same code for each role we could create
        }
        #endregion Constructor

        #region Methods
        public void UpdateLemming()
        {
            
        }

        public void ChangeLemmingSprite()
        {
            
        }
        #endregion Methods


        
    }
}
