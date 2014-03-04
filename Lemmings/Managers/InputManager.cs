using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Lemmings.Managers
{
    class InputManager
    //Used to manage input from the user.
    //All done through mouse for this game but if we can make it generic then that would be better.
    //if we want to add more roles on, will this need to be implimented in a specific way? (cant just be one click, need to have an option box for each role)
    {
        #region DataMembers
        MouseState currentState;
       
        int num = 0;

        #endregion DataMembers

        #region Properties

        #endregion Properties

        #region Constructor
        public InputManager()
        {

        }
        #endregion Constructor

        #region Methods

      
        public void InputMouse()
        {
            if (currentState.LeftButton == ButtonState.Pressed)
            {
                num += 1;
            }
        }
        
        
        
        
        
        public void update()
        {
            currentState = Mouse.GetState();
            InputMouse();
        }
        #endregion Methods
    }
}
