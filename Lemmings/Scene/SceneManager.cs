using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemmings.Objects;
using Lemmings.Interfaces;
using Microsoft.Xna.Framework;

namespace Lemmings.Scene
{
    class SceneManager : ITerminate
        //The SceneManager is used to communicate with the scene graph. When another class needs to do something with the scene, like add an entity, it needs to go through the SceneManager.
    {
        #region DataMembers
        private SceneGraph sGraph;
        private int firstLemming = 0;
        private int lemmingKey;
        private int spiderKey;
        private Vector2 lemmingPosition;
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
            if (firstLemming == 0 && entity.Equals(Lemmings.Objects.ObjectType.Lemming) == true)
            {
                lemmingKey = entity.objectID;
                firstLemming += firstLemming;
            }
        }

        public void RemoveEntitiesFromScene(int entityID)
        {
            sGraph.RemoveEntitiesFromScene(entityID);
        }

        public void UpdateAllEntitiesInScene()
        {
            sGraph.UpdateAllEntitiesInScene();
            CheckCollision();
        }

        //This method returns the list of objects that need to be drawn on the screen.
        public List<ParentObject> GetListToDraw()
        {
            return sGraph.drawingList;
        }

        public void CheckCollision()
        {
           
            for (int e1 = 0; e1 < sGraph.entityList.Count; e1++)
            {
                for (int e2 = 0; e2 < sGraph.entityList.Count; e2++)
                {
                    if (sGraph.entityList[e1].boundBox.Intersects(sGraph.entityList[e2].boundBox))
                    {
                        ProcessCollision(sGraph.entityList[e1],sGraph.entityList[e2]);
                    }
                }
            }
        }

        public void ProcessCollision(ParentObject E1, ParentObject E2)
        {
            if (E1.Equals(Lemmings.Objects.ObjectType.Spider) == true && E2.Equals(Lemmings.Objects.ObjectType.Lemming) == true)
            {
                TerminateEntity(E1.objectID);
            }
        }
       

        public void TerminateEntity(int entityID)
        {
            this.RemoveEntitiesFromScene(entityID);
        } 

        #endregion Methods
    }
}
