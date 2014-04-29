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
        ParentObject[] temp;
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
            CheckCollisionList();
        }

        //This method returns the list of objects that need to be drawn on the screen.
        public List<ParentObject> GetListToDraw()
        {
            return sGraph.drawingList;
        }

        public void CheckCollisionList()
        {
            temp = sGraph.drawingList.ToArray();
			
			foreach(ParentObject obj in temp){
                foreach(ParentObject obj2 in temp)
                {
                    checkCollision(obj,obj2);
                }
                
            }
           
           
        }
        public void checkCollision(ParentObject E1, ParentObject E2)
        {
            if (sGraph.DoesKeyExist(E1.objectID) == true && sGraph.DoesKeyExist(E2.objectID) == true)
            {
                if (E1.boundBox.Intersects(E2.boundBox))
                {
                    ProcessCollision(E1, E2);
                }
            }
            
        }
       
        public void ProcessCollision(ParentObject E1, ParentObject E2)
        {
            if (E1.objectID == 5 && E2.objectID == 11)
            {
                TerminateEntity(E2.objectID);
                TerminateEntity(E1.objectID);
            }
            else if (E2.objectID == 5 && E1.objectID == 11)
            {
                TerminateEntity(E1.objectID);
                TerminateEntity(E2.objectID);
            }
        }
       

        public void TerminateEntity(int entityID)
        {
            
           this.RemoveEntitiesFromScene(entityID);
        } 

        #endregion Methods
    }
}
