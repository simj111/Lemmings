using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemmings.Astar
{
    class BinaryTreeNode : Node
    {
        #region DataMembers

        #endregion DataMembers

        #region Properties
        public BinaryTreeNode Left 
        {
            get
            {
                if (neighbours == null)
                {
                    return null;
                }
                else
                {
                    return (BinaryTreeNode)neighbours[0];
                }
            }
            set
            {
                if (neighbours == null)
                {
                    List<Node> newNodes = new List<Node>();
                    neighbours = newNodes;

                    neighbours.Add(null);
                    neighbours.Add(null);

                    Left = value;
                }
            }

        }

        public BinaryTreeNode right
        {
            get
            {
                if (neighbours == null)
                {
                    return null;
                }
                else
                {
                    return (BinaryTreeNode)neighbours[1];
                }
            }
            set
            {
                if (neighbours == null)
                {
                    List<Node> newNodes = new List<Node>();
                    neighbours = newNodes;

                    neighbours.Add(null);
                    neighbours.Add(null);

                    right = value;
                }
            }
        }
        #endregion Properties

        #region Constructors
        public BinaryTreeNode() 
        {
        

        } 
        
        public BinaryTreeNode(string somedata):base(somedata,null)
        {
        

        }

        public BinaryTreeNode(string moredata, BinaryTreeNode left, BinaryTreeNode right)
        {
            data = moredata;
            List<Node> children = new List<Node>();
            children.Add(left);
            children.Add(right);

            neighbours = children;
        }
        #endregion Constructors

        #region Methods

        #endregion Methods
       

        

    }
}
