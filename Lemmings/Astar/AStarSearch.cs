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
        Node child;
        Node[] searchSpace = new Node[256];
        List<Node> OpenList = new List<Node>();
        List<Node> ClosedList = new List<Node>();
        List<Node> nodePath = new List<Node>();
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
            searchSpace = pSearchSpace;
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
                CheckChildren(currentNode, goal);
               currentNode = FindFittest();
                if (currentNode == goal)
                {
                    found = true;
                }
            }
            ShowPath(goal);

        }

        public Node FindFittest()
        {
            int lowest = 100;
            foreach (Node nodes in OpenList)
            {
                if(lowest > nodes.F)
                {
                    lowest = nodes.F;
                    currentNode = nodes;
                }
            }
            return currentNode;
        }

        public bool Closed(Node cNode)
        {
            if (ClosedList.Contains(cNode))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool Opened(Node oNode)
        {
            if (OpenList.Contains(oNode))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Node>ShowPath(Node goalNode)
        {
            while (currentNode != goalNode)
            {
                 currentNode = currentNode.parent;
                nodePath.Add(currentNode);
            }
            return nodePath;
            
        }

        public void CheckChildren(Node current, Node goalNode)
        {
              int gridRow = 16 - 1;

             for(int i = 0; i < 3; i ++)
             {
                 for (int j = 0; j < 3; j++)
                 {
                    child = searchSpace[current.element + gridRow + j];
                     if (Closed(child) == true)
                     {
                         int G = 0;
                         int cost = current.G;
                         if (child.element == (current.element - 17) || child.element == (current.element -15) || child.element == (current.element + 15) || child.element == (current.element + 17))
                         {
                             G = cost + 71;
                         }
                         else
                         {
                             G = cost + 50;
                         }

                         if (Opened(child) == false)
                         {
                             OpenList.Add(child);
                             child.parent = current;
                             child.G = G;
                             child.H = Convert.ToInt32(Math.Abs(child.position.X - goalNode.position.X) + Math.Abs(child.position.Y - goalNode.position.Y));
                             child.F = child.G + child.H;
                         }

                         else
                         {
                             if (G < child.G)
                             {
                                 child.parent = current;
                                 child.G = G;
                                 child.H = Convert.ToInt32(Math.Abs(child.position.X - goalNode.position.X) + Math.Abs(child.position.Y - goalNode.position.Y));
                                 child.F = child.G + child.H;
                             }
                         }
                     }
                 }
                 gridRow = gridRow + 16;
             }
        }

           
        #endregion Methods
    }
}
