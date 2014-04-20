using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemmings.Objects;

namespace Lemmings.Scene
{
    class SceneManager
    //The SceneManager is used to manage the Scene, with the SceneGraph, and entities that need to be visible on it. 
    //It updates the scene with adding and removing entities when they are needed.
    {
        
        #region DataMembers
        //This dictionary is used to keep a collection of entities, that will currently be in the scene, and arange them by using their unique ID's as Keys in the dictionary.
        //It is done this way to easily differentiate between the entities, for when they need to be either added or removed from the scene.
        //It uses an int because each entity has a unique ID based on when they were created e.g. the first created entity is given 0.
        private Dictionary<int, ParentObject> _entityList;

        //The list of objects called _drawingList is used to contain all of the objects that need to be drawn on the screen.
        //It gets updated whenever the dictionary does. I.e if the dictionary gets an entity added, then so does the drawing list.
        private List<ParentObject> _drawingList;
        #endregion DataMembers

        #region Properties
        public Dictionary<int, ParentObject> entityList
        {
            get{ return _entityList;}
            set{ _entityList = value;}
        }
        public List<ParentObject> drawingList
        {
            get { return _drawingList; }
            set { _drawingList = value; }
        }
        #endregion Properties

        #region Constructor
        //The SceneManager initialises the private entityList as a dictionary, and the private drawingList as a list of objects.
        public SceneManager() 
        {
            _entityList = new Dictionary<int, ParentObject>();
            _drawingList = new List<ParentObject>();
        }
        #endregion Constructor

        #region Methods
        //This method is used to add an entity to the list of current entities in the scene.
        //It also adds the entity to the list of drawable objects.
        public void AddEntitiesToScene(ParentObject entity)
        {
            entityList.Add(entity.objectID, entity);
            drawingList.Add(entity);
        }

        //This method is used to remove an entity from the scene based off of it's unique ID. 
        //This ensures that the correct entity will be removed from the list.
        //It also removes the entity from the drawing list, by using the id in the dictionary to find the correct entity.
        public void RemoveEntitiesFromScene(int entityID)
        {
            //This if statement is needed to find the correct entity, in the dictionary, so that it can be properly removed from the drawingList.
            //It needs to be removed from the drawing list first because it needs to be found in the dictionary first.
            if(drawingList.Contains(entityList[entityID]))
            {
                drawingList.Remove(entityList[entityID]);
            }
            entityList.Remove(entityID);
        }

        //This method is used to update all of the current entities in the scene that can be updated.
        public void UpdateAllEntitiesInScene()
        {
            for (int i = 0; i < entityList.Count; i++)
            {
                //The SceneManager only attempts to update an object if the "i" data member exists as a key in the dictionary, and therefore exists in the scene at this time. 
                if (DoesKeyExist(i) == true)
                {
                    // Only the objects which can be updatable are attempted to be updated.
                    if (entityList[i].isUpdatable == true)
                    {
                        entityList[i].Move();
                    }
                }
            }
        }
        //this is used to check if the object ID corresponds to a key in the entityList.
        public bool DoesKeyExist(int entityID)
        {
            if (entityList.ContainsKey(entityID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Methods
    }
}
