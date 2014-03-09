using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lemmings.Astar
{
    class AStarSearch
    {
         #region DataMembers
        public bool found = false;
        Node start = null;
        Node goal = null;
        Node currentNode;
        List<Node> OpenList = new List<Node>();
        List<Node> ClosedList = new List<Node>();
        Texture2D check;
        Texture2D path;
        #endregion DataMembers

        #region Properties

        #endregion Properties

        #region Constructor
        public AStarSearch()
        {

        }
        #endregion Constructor

        #region Methods
        public void Search(Node[] pSearchSpace, Node pStart, Node pGoal, Texture2D pCheck, Texture2D pPath)
        {
            start = pStart;
            goal = pGoal;
            check = pCheck;
            path = pPath;

            OpenList.Add(start);
            currentNode = start;
            while (found != true || OpenList.Count != 0)
            {
                OpenList.Remove(currentNode);
                ClosedList.Add(currentNode);
                
            }
        }

           
        #endregion Methods
    }
}
