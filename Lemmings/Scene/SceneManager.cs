using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemmings.Objects;

namespace Lemmings.Scene
{
    class SceneManager
        //The SceneManager is used to communicate with the scene graph. When another class needs to do something with the scene, like add an entity, it needs to go through the SceneManager.
    {
        #region DataMembers
        private SceneGraph sGraph;
        #endregion DataMembers

        #region Properties

        #endregion Properties

        #region Constructor
        public SceneManager()
        {
            sGraph = new SceneGraph();
        }
        #endregion Constructor

        #region Methods
        public void AddEntitiesToScene(ParentObject entity)
        {
            sGraph.AddEntitiesToScene(entity);
        }

        public void RemoveEntitiesFromScene(int entityID)
        {
            sGraph.RemoveEntitiesFromScene(entityID);
        }

        public void UpdateAllEntitiesInScene()
        {
            sGraph.UpdateAllEntitiesInScene();
        }

        //This method returns the list of objects that need to be drawn on the screen.
        public List<ParentObject> GetListToDraw()
        {
            return sGraph.drawingList;
        }
        #endregion Methods
    }
}
