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

        //----- Constructor -----
        public ObjectFactory(IList<ParentObject> defaultObjects)
        {
            //Timer object properties
            lemmingDelay = new Timer(5000);
            lemmingDelay.Enabled = false;
            lemmingDelay.Elapsed += new ElapsedEventHandler(LemmingDelayTime);

            //The objects which need to be created first get put into the objectsForCreation list.
            objectsForCreation = defaultObjects;
            
        }

        //----- Properties -----
        private static Timer lemmingDelay;
        private IList<ParentObject> objectsForCreation;
        public enum ObjectType //The types of objects which can be created.
        {
            Lemming,
            Floor,
        }
        
        //----- Methods -----
        public IList<ParentObject>CreateObjects(IList<ParentObject> objects, ObjectType typeOfObject)
        {
            objectsForCreation = objects;

            //Creaton code goes here

            return objectsForCreation;
        }

       private static void LemmingDelayTime(object source, ElapsedEventArgs e)
       {
           //This will only get called when the timer reaches 5 seconds.
           //The factory will only create lemmings while the timer is not enabled.
           //The timer will become enable upon lemming creation.
           lemmingDelay.Enabled = false;
       }
      
          
    }
}
