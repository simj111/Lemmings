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
        }
    class ObjectFactory
    //Used to actually create entities and assign default properties(spritebatch, position? etc.)
    {
        
        #region DataMembers
       
        private static Timer lemmingDelay;
        ParentObject newObject = null;
        int increaseObjectID;
      
        #endregion DataMembers

        #region Properties

        #endregion Properties

        #region Constructor
        public ObjectFactory()
        {
            //Timer object properties
            lemmingDelay = new Timer(2000);
            lemmingDelay.Enabled = false;
            lemmingDelay.Elapsed += new ElapsedEventHandler(LemmingDelayTime);
            increaseObjectID = 0;
        }
        #endregion Constructor

        #region Methods
        public ParentObject CreateObjects(ObjectType typeOfObject)
        {
           if (lemmingDelay.Enabled == false)
            {
                //Creaton code goes here
                switch (typeOfObject)
                {
                    case ObjectType.Lemming:
                        newObject = new Lemming(increaseObjectID);
                        lemmingDelay.Enabled = true;
                        break;

                    case ObjectType.Floor:
                        //newObject = new Floor();
                        break;

                    case ObjectType.Spider:
                        //newObject = new Spider();
                        break;
                }
                }
                increaseObjectID++;
                return newObject;
           
        }

       private void LemmingDelayTime(object source, ElapsedEventArgs e)
       {
           //This will only get called when the timer reaches 5 seconds.
           //The factory will only create lemmings while the timer is not enabled.
           //The timer will become enabled upon lemming creation.
           lemmingDelay.Enabled = false;
           
       }
        #endregion Methods
        
        
      
          
    }
}
