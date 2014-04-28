using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Timers;


namespace Lemmings.Objects
{
    public enum ObjectType //The types of objects which can be created.
    {
        Lemming,
        Floor,
        Spider,
        Edge,
        Gate,
    }
    class ObjectFactory
    //Used to actually create entities and assign default properties(spritebatch, position? etc.)
    {
        
        #region DataMembers
       
        private static Timer lemmingDelay;
        ParentObject newObject = null;
        int increaseObjectID;
        string edgeType;
        
        #endregion DataMembers

        #region Properties

        #endregion Properties

        #region Constructor
        public ObjectFactory()
        {
            //Timer object properties
            lemmingDelay = new Timer(5000);
            lemmingDelay.Interval = 5000;
            lemmingDelay.Enabled = false;
            lemmingDelay.Elapsed += new ElapsedEventHandler(LemmingDelayTime);
            
            increaseObjectID = 0;
        }
        #endregion Constructor

        #region Methods
        public ParentObject CreateObjects(ObjectType typeOfObject)
        {
            
              //This switch case checks what type of object has been passed in and creates an object based off the ObjectType enum.
                switch (typeOfObject)
                {
                    case ObjectType.Lemming:
                        newObject = new Lemming(increaseObjectID, typeOfObject);
                        lemmingDelay.Enabled = true;
                       
                        break;

                    case ObjectType.Floor:
                        newObject = new Floor(increaseObjectID, typeOfObject);
                        break;

                    case ObjectType.Spider:
                        newObject = new SpiderEnemy(increaseObjectID, typeOfObject);
                        break;
                      
                    case ObjectType.Edge:
                        newObject = new Edge(edgeType, increaseObjectID, typeOfObject);
                        break;
                    case ObjectType.Gate:
                        newObject = new Gate(increaseObjectID, typeOfObject);
                        break;
                }
                
                increaseObjectID++;
                return newObject;
           
        }
        //This method gets the type of edge that needs to be created to pass into the constructor of the Edge object.
        public void GetEdgeType(string typeOfEdge)
        {
            edgeType = typeOfEdge;
        }
       private static void LemmingDelayTime(object source, ElapsedEventArgs e)
       {
           //This will only get called when the timer reaches 5 seconds.
           //The factory will only create lemmings while the timer is not enabled.
           //The timer will become enabled upon lemming creation.
           lemmingDelay.Enabled = false;
      
       }
        #endregion Methods
        
        
      
          
    }
}
