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
            CheckCollision();
        }

        //This method returns the list of objects that need to be drawn on the screen.
        public List<ParentObject> GetListToDraw()
        {
            return sGraph.drawingList;
        }

        public void CheckCollision()
        {
            temp = sGraph.drawingList.ToArray();
            for (int i = 0; i < temp.Length; i++)
            {
                for (int j = i + 1; j < temp.Length; j++)
                {

                    checkCollision(temp[i], temp[j]);
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
            if (E1.type == ObjectType.Spider && E2.type == ObjectType.Lemming)
            {
                TerminateEntity(E2.objectID);
            }
            if(E1.type == ObjectType.Lemming && E2.type == ObjectType.Spider)
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
