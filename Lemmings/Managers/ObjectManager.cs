﻿using System;
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
            //objectsToDraw = factory.createObjects(objectsToCreate) can be used to pass in the current objects to be created in factory
            
        }

        //----- Properties -----
        ObjectFactory factory;
        IList<ParentObject> objectsToCreate;
        IList<ParentObject> objectsToDraw;

        //----- Methods -----
        public void DefaultObjects()
        {
            //add the default objects that need to be drawn to the list "objectsToCreate".
        }

        public void CallRendererToDraw(IList<ParentObject>createThesePlease)
        {
           
            //Needs to return a list of parent objects that are now created.
            //These will then get added to objectsToDraw.
        }

        public void TerminateObject(int objectID, Lemming objectToTerminate)
        {
            objectToTerminate.Terminate(objectID);
        }

        // Public void ObjectsCollide(int objectID1, int objectID2) [Potential collision method]
    

    }
}
