﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemmings.Objects;

namespace Lemmings.Roles
{
    class Default : ParentRole
    {
        //This will be the standard behaviour role that the lemmings will take untill they are interacted with. This will have to interact with the A* algorithm.
        #region DataMembers

        #endregion DataMembers

        #region Properties

        #endregion Properties

        #region Constructor
        public Default(Lemming myLemming)
            : base(myLemming)
        {
        }
        #endregion Constructor

        #region Methods

        #endregion Methods
    }
}
