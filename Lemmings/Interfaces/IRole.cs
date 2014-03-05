using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemmings.Interfaces
{
    interface IRole
        //This interface is to be used by any role. It will contain things such as "UpdateLemming()", "ChangeLemmingSprite" which all roles will need.
    {
        //This method will be used to update the lemmings, even a blocker which doesn't move a lemming needs to update it to stop once it has become a blocker
        void UpdateLemming();

        //This method will be used to change the sprite of the lemming by changing where it's rectangle is on the spritesheet.
        void ChangeLemmingSprite();
    }
}
