using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemmings.Objects;

namespace Lemmings.Managers
{
    class ObjectManager
    //Used to manage entity creation...and interaction? collision?
    {
        //----- Constructor -----
        public ObjectManager(ObjectFactory objectFactory)
        {
            //We call this method to define which are the default objects that the factory will need to create
            DefaultObjects();

            //If we have kernel create the factory we can use it here
            factory = objectFactory;
            //factory.createDefaultObjects(objectsToCreate) can be used to pass in the current objects to be created in factory
        }

        //----- Properties -----
        ObjectFactory factory;
        IList<ParentObject> objectsToCreate;

        //----- Methods -----
        public void DefaultObjects()
        {
            //add the default objects that need to be drawn to the list "objectsToCreate".
        }

    }
}
