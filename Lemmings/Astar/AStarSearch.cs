using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lemmings.Astar
{
    public class AStarSearch
    {
         #region DataMembers
        public bool found = false;
        Node start = null;
        Node goal = null;
        Node currentNode;
        Node[] searchSpace;
        List<Node> OpenList = new List<Node>();
        List<Node> ClosedList = new List<Node>();
        List<Node> nodePath = new List<Node>();
        Texture2D check;
        Texture2D path;
        private int gridRow;
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
            searchSpace = pSearchSpace;
            start = pStart;
            goal = pGoal;
            check = pCheck;
            path = pPath;

            OpenList.Add(start);
            currentNode = start;
            while (found != true || OpenList.Count == 0)
            {
                OpenList.Remove(currentNode);
                ClosedList.Add(currentNode);
                CheckChildren(currentNode, goal);
                FindFittest();
                if (currentNode == goal)
                {
                    found = true;
                }
            }
            ShowPath(goal);

        }

        public Node FindFittest()
        {
            //assign lowest f to current
            return currentNode;
        }

        public bool Closed(Node cNode)
        {
            return true;
        }

        public bool Opened(Node oNode)
        {
            return true;
        }

        public List<Node>ShowPath(Node goalNode)
        {

            return nodePath;
            
        }

        public void CheckChildren(Node current, Node goalNode)
        {
              gridRow = 16 - 1;

             for(int i = 0; i < 3; i ++)
             {
                 for (int j = 0; j < 3; j++)
                 {
                    OpenList.Add(searchSpace[current.element + gridRow + j]);
                     if (Closed(current) == true)
                     {
                         int G = 0;
                         int cost = currentNode.G;
                         if (current.element == (currentNode.element - 17) || current.element == (currentNode.element -15) || current.element == (currentNode.element + 15) || current.element == (currentNode.element + 17))
                         {
                             G = cost + 71;
                         }
                         else
                         {
                             G = cost + 50;
                         }
                    if (Opened(current) == false)
                     {
                         OpenList.Add(current);
                         current.parent = currentNode;
                         current.G = G;
                        // current.H = goalNode.position - currentNode.position;
                     }
                     }
                 }
             }
        }

           
        #endregion Methods
    }
}
