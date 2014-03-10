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
        Node[] searchSpace = new Node[256];
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
            while (currentNode != start)
            {
                 currentNode = currentNode.parent;
                nodePath.Add(currentNode);
            }
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
                             current.H = Convert.ToInt32(Math.Abs(current.position.X - goalNode.position.X) + Math.Abs(current.position.Y - goalNode.position.Y));
                             current.F = current.G + current.H;
                         }

                         else
                         {
                             if (G < current.G)
                             {
                                 current.parent = currentNode;
                                 current.G = G;
                                 current.H = Convert.ToInt32(Math.Abs(current.position.X - goalNode.position.X) + Math.Abs(current.position.Y - goalNode.position.Y));
                                 current.F = current.G + current.H;
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
