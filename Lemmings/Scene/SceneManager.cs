using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemmings.Objects;

namespace Lemmings.Scene
{
    class SceneManager
    {
        #region DataMembers
        //This dictionary is used to keep a collection of entities, that will currently be in the scene, and arange them by using their unique ID's as Keys in the dictionary.
        //It is done this way to easily differentiate between the entities, for when they need to be either added or removed from the scene.
        //It uses an int because each entity has a unique ID based on when they were created e.g. the first created entity is given 0.
        private Dictionary<int, ParentObject> _entityList; 
        #endregion DataMembers

        #region Properties
        
        public Dictionary<int, ParentObject> entityList
        {
            get{ return _entityList;}
            set{ _entityList = value;}
        }
        #endregion Properties

        #region Constructor
        //The SceneManager initialises the private entityList as a dictionary with the relevant keys.
        public SceneManager() 
        {
            _entityList = new Dictionary<int, ParentObject>();
        }
        #endregion Constructor

        #region Methods
        //This method is used to add an entity to the list of current entities in the scene.
        public void AddEntitiesToScene(ParentObject entity)
        {
            entityList.Add(entity.objectID, entity);
        }
        //This method is used to remove an entity from the scene based off of it's unique ID. 
        //This ensures that the correct entity will be removed from the list.
        public void RemoveEntitiesFromScene(int entityID)
        {
            entityList.Remove(entityID);
        }
        //This method is used to update all of the current entities in the scene that can be updated.
        public void UpdateAllEntitiesInScene()
        {
            for (int i = 0; i < entityList.Count; i++)
            {
                
                    if (entityList[i].isUpdatable == true)
                    {
                        entityList[i].Move();
                    }
                
                
               
            }
        }
        //this is used to check if the objetc int exists in the entity list key's
        public bool DoesKeyExist(ParentObject entity)
        {
            return true;
        }
        
        #endregion Methods
    }
}
