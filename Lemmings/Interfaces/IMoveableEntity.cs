﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemmings.Objects;

namespace Lemmings.Interfaces
{
    interface IMoveableEntity
    {
        void UpdateEntity(ParentObject pObject);
    }
}
