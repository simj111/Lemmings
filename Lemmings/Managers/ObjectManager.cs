using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemmings.Objects;
using Microsoft.Xna.Framework;

namespace Lemmings.Managers
{
    class ObjectManager
    //Used to manage entity creation...and interaction? collision?
    {
        #region DataMembers
        ObjectFactory factory;
        Renderer renderer;
        private IList<string> objectsToCreate = null; 
        private IList<ParentObject> objectsToDraw = null;
        #endregion DataMembers

        #region Properties

        #endregion Properties

        #region Constructor
        public ObjectManager(ObjectFactory objectFactory, Renderer createdRenderer)
        {
            objectsToCreate = new List<string>();
            objectsToDraw = new List<ParentObject>();
            //If we have kernel create the factory and renderer we can use it here
            factory = objectFactory;
            renderer = createdRenderer;

            //We call this method to define which are the default objects that the factory will need to create
            DefaultObjects();
            //Makes the factory create after default objects have been added to a list.
            CallFactoryToCreate();
        }
        #endregion Constructor

        #region Methods
        public void DefaultObjects()
        {
            //add the default objects that need to be created to the list "objectsToCreate".
            
            //Testing creation
            objectsToCreate.Add("Floor");
            objectsToCreate.Add("Floor");
            objectsToCreate.Add("Floor");
            objectsToCreate.Add("Floor");
            objectsToCreate.Add("Floor");
            objectsToCreate.Add("Floor");

            objectsToCreate.Add("Spider");

            objectsToCreate.Add("Edge_Top");
            objectsToCreate.Add("Edge_Bottom");
            objectsToCreate.Add("Edge_Left");
            objectsToCreate.Add("Edge_Right");

            objectsToCreate.Add("Lemming");
            
        }

        //This method calls the factory object to create all objects in the "objectsToCreate" list based off the string within them
        public void CallFactoryToCreate()
        {
            //Somehwere in here we need to force it to create lemmings last because they need the 5 second interval between them.
            //Other objects, spider, floor etc. can be created and drawn at the same time as the first lemming however.

            //Goes through each string object in the objectsToCreate list and makes the factory create objects based off of it. 
            //The object is then added to the objectsToDraw list of parent objects.
                foreach (string obj in objectsToCreate)
                {
                    if (obj.Contains("Lemming") || obj.Contains("lemming"))
                    {
                        objectsToDraw.Add(factory.CreateObjects(ObjectType.Lemming));
                    }

                   else if (obj.Contains("Spider"))
                    {
                        objectsToDraw.Add(factory.CreateObjects(ObjectType.Spider));
                    }

                    else if (obj.Contains("Floor"))
                    {
                        objectsToDraw.Add(factory.CreateObjects(ObjectType.Floor));
                    }

                    else if (obj.Contains("Edge_Top"))
                    {
                        factory.GetEdgeType("Top");
                        objectsToDraw.Add(factory.CreateObjects(ObjectType.Edge));
                    }

                    else if (obj.Contains("Edge_Bottom"))
                    {
                        factory.GetEdgeType("Bottom");
                        objectsToDraw.Add(factory.CreateObjects(ObjectType.Edge));
                    }

                    else if (obj.Contains("Edge_Left"))
                    {
                        factory.GetEdgeType("Left");
                        objectsToDraw.Add(factory.CreateObjects(ObjectType.Edge));
                        
                    }

                    else if (obj.Contains("Edge_Right"))
                    {
                        factory.GetEdgeType("Right");
                        objectsToDraw.Add(factory.CreateObjects(ObjectType.Edge));
                    }
                    
                }
                objectsToCreate.Clear();
                //This code is just to force one of the lemmings and spiders to appear in a different place
                objectsToDraw[1].position = new Vector2(105, 233);
                objectsToDraw[2].position = new Vector2(430, 233);
                objectsToDraw[3].position = new Vector2(266, 300);
                objectsToDraw[4].position = new Vector2(134, 374);
                objectsToDraw[5].position = new Vector2(405, 374);
                
            
            
        }

        public void CallRendererToDraw()
        {
            renderer.DrawEntities(objectsToDraw);
            //Needs to return a list of parent objects that are now created.
            //These will then get added to objectsToDraw.
        }


        public void UpdateEntities()
        {
            
            foreach (Lemming lem in objectsToDraw)
            {
                lem.currentRole.UpdateLemming();
            }
        }


        public void TerminateObject(int objectID, Lemming objectToTerminate)
        {
            objectToTerminate.Terminate(objectID);
        }

        // Public void ObjectsCollide(int objectID1, int objectID2) [Potential collision method]
        #endregion Methods
        
    

    }
}
