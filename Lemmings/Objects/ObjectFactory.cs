using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Timers;

namespace Lemmings.Objects
{
    class ObjectFactory
    //Used to actually create entities and assign default properties(spritebatch, position? etc.)
    {
        
        #region DataMembers
        public enum ObjectType //The types of objects which can be created.
        {
            Lemming,
            Floor,
        }
        private static Timer lemmingDelay;
        private IList<string> objectsForCreation;
        #endregion DataMembers

        #region Properties

        #endregion Properties

        #region Constructor
        public ObjectFactory()
        {
            //Timer object properties
            lemmingDelay = new Timer(5000);
            lemmingDelay.Enabled = false;
            lemmingDelay.Elapsed += new ElapsedEventHandler(LemmingDelayTime);
        }
        #endregion Constructor

        #region Methods
        public void CreateObjects(IList<string> objects, ObjectType typeOfObject)
        {

            //Creaton code goes here

  
        }

       private static void LemmingDelayTime(object source, ElapsedEventArgs e)
       {
           //This will only get called when the timer reaches 5 seconds.
           //The factory will only create lemmings while the timer is not enabled.
           //The timer will become enable upon lemming creation.
           lemmingDelay.Enabled = false;
       }
        #endregion Methods
        
        
      
          
    }
}
