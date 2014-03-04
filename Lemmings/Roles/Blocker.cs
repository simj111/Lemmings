using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemmings.Objects;

namespace Lemmings.Roles
{
    class Blocker : ParentRole
    //This will use methods and properties of the parent Role class.
    //Has it's own ones unique to it e.g. make assigned lemmings movement stop still etc.
    {
        #region DataMembers

        #endregion DataMembers

        #region Properties
        //These will be gained from parent class
        #endregion Properties

        #region Constructor
       public Blocker(Lemming myLemming)
            : base(myLemming)
        {
        }
        #endregion Constructor

        #region Methods

        #endregion Methods
        
    }
}
