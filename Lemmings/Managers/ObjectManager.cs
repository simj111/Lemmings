using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Lemmings.Objects;
using Lemmings.Scene;
using Lemmings.Interfaces;

namespace Lemmings.Managers
{
    class ObjectManager : ITerminate
    //Used to manage entity creation
    {
        #region DataMembers
        ObjectFactory factory;
        Renderer renderer;
        SceneManager sManager;
        private IList<string> objectsToCreate = null; 
        private IList<ParentObject> defaultObjectsToDraw = null;
        #endregion DataMembers

        #region Properties

        #endregion Properties

        #region Constructor
        public ObjectManager(ObjectFactory objectFactory, Renderer createdRenderer, SceneManager pSceneManager)
        {
            objectsToCreate = new List<string>();
            defaultObjectsToDraw = new List<ParentObject>();
            //If we have kernel create the factory and renderer we can use it here
            factory = objectFactory;
            renderer = createdRenderer;
            sManager = pSceneManager;

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
            

            objectsToCreate.Add("Spider");

            objectsToCreate.Add("Edge_Top");
            objectsToCreate.Add("Edge_Bottom");
            objectsToCreate.Add("Edge_Left");
            objectsToCreate.Add("Edge_Right");

            objectsToCreate.Add("Gate");

            objectsToCreate.Add("Lemming");
            
        }

        //This method calls the factory object to create all objects in the "objectsToCreate" list based off the string within them
        public void CallFactoryToCreate()
        {
            //Somehwere in here we need to force it to create lemmings last because they need the 5 second interval between them.
            //Other objects, spider, floor etc. can be created and drawn at the same time as the first lemming however.

            //Goes through each string object in the objectsToCreate list and makes the factory create objects based off of it. 
            //The object is then added to the defaultdefaultObjectsToDraw list of parent objects.
                foreach (string obj in objectsToCreate)
                {
                    if (obj.Contains("Lemming") || obj.Contains("lemming"))
                    {
                        defaultObjectsToDraw.Add(factory.CreateObjects(ObjectType.Lemming));
                        sManager.AddEntitiesToScene(defaultObjectsToDraw[defaultObjectsToDraw.Count - 1]);
                    }

                   else if (obj.Contains("Spider"))
                    {
                        defaultObjectsToDraw.Add(factory.CreateObjects(ObjectType.Spider));
                        sManager.AddEntitiesToScene(defaultObjectsToDraw[defaultObjectsToDraw.Count - 1]);
                    }

                    else if (obj.Contains("Floor"))
                    {
                        defaultObjectsToDraw.Add(factory.CreateObjects(ObjectType.Floor));
                        sManager.AddEntitiesToScene(defaultObjectsToDraw[defaultObjectsToDraw.Count - 1]);
                    }

                    else if (obj.Contains("Edge_Top"))
                    {
                        factory.GetEdgeType("Top");
                        defaultObjectsToDraw.Add(factory.CreateObjects(ObjectType.Edge));
                        sManager.AddEntitiesToScene(defaultObjectsToDraw[defaultObjectsToDraw.Count - 1]);
                    }

                    else if (obj.Contains("Edge_Bottom"))
                    {
                        factory.GetEdgeType("Bottom");
                        defaultObjectsToDraw.Add(factory.CreateObjects(ObjectType.Edge));
                        sManager.AddEntitiesToScene(defaultObjectsToDraw[defaultObjectsToDraw.Count - 1]);
                    }

                    else if (obj.Contains("Edge_Left"))
                    {
                        factory.GetEdgeType("Left");
                        defaultObjectsToDraw.Add(factory.CreateObjects(ObjectType.Edge));
                        sManager.AddEntitiesToScene(defaultObjectsToDraw[defaultObjectsToDraw.Count - 1]);
                    }

                    else if (obj.Contains("Edge_Right"))
                    {
                        factory.GetEdgeType("Right");
                        defaultObjectsToDraw.Add(factory.CreateObjects(ObjectType.Edge));
                        sManager.AddEntitiesToScene(defaultObjectsToDraw[defaultObjectsToDraw.Count - 1]);
                    }

                    else if (obj.Contains("Gate"))
                    {
                        defaultObjectsToDraw.Add(factory.CreateObjects(ObjectType.Gate));
                        sManager.AddEntitiesToScene(defaultObjectsToDraw[defaultObjectsToDraw.Count - 1]);
                    }
                    
                }
                objectsToCreate.Clear();

                //This code is just to force the floors to appear in a different place.
                defaultObjectsToDraw[0].position = new Vector2(85, 550);
                defaultObjectsToDraw[1].position = new Vector2(85, 300);
                defaultObjectsToDraw[2].position = new Vector2(460, 300);
                defaultObjectsToDraw[3].position = new Vector2(266, 450);
                defaultObjectsToDraw[4].position = new Vector2(430, 550);

                defaultObjectsToDraw[11].position = new Vector2(115, 130);
                defaultObjectsToDraw.Clear(); //This list is only needed to help the creation of the default objects.
            
        }

        /// <summary>
        /// This method is used to make the renderer draw the entities that are in the SceneManagers list of objects to draw (drawingList).
        /// </summary>
        public void CallRendererToDraw()
        {
            renderer.DrawEntities(sManager.GetListToDraw());
        }


        public void UpdateEntities()
        {
            sManager.UpdateAllEntitiesInScene();
        
        }

        public void TerminateEntity(int entityID)
        {
            
        }

        // Public void ObjectsCollide(int objectID1, int objectID2) [Potential collision method]
        #endregion Methods

       
    }
}
