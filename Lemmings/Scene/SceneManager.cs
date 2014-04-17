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
        //This dictionary is used to keep a collection of entities and arange them by their unique ID's.
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
        //The SceneManager will be passed a list of default entities which will be needed in the initial scene.
        public SceneManager(IList<ParentObject>defaultEntities)
        {
            foreach (ParentObject pEntity in defaultEntities)
            {
                entityList.Add(pEntity.objectID, pEntity);
            }
        }

        #endregion Constructor

        #region Methods
        public void AddEntitiesToScene(ParentObject entity)
        {
            entityList.Add(entity.objectID, entity);
        }
        public void RemoveEntitiesFromScene(int entityID)
        {
            entityList.Remove(entityID);
        }
        public void UpdateAllEntitiesInScene()
        {

        }
        #endregion Methods
    }
}
