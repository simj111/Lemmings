using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemmings.Astar
{
    public class BinaryTree
    {
        #region DataMembers

        BinaryTreeNode root = new BinaryTreeNode();

        #endregion DataMembers

        #region Properties
        public BinaryTreeNode Root
        {
            get { return root; }
            set { root = value; }
        }

        
        #endregion Properties

        #region Constructor
        public BinaryTree()
        {
            root = null;
        }
        #endregion Constructor

        #region Methods

        public void Clear()
        {
            root = null;
        }
        #endregion Methods










    }
}
