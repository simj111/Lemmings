using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemmings.Astar
{
    public class Node
    {
        #region DataMembers
        private string _data; 
        private List<Node> _neighbours = null; 
        private bool _visited = false;
        #endregion DataMembers

        #region Properties
        public string data
        {
            get { return _data; }
            set { _data = value; }
        }

        public List<Node> neighbours
        {
            get { return _neighbours; }
            set { _neighbours = value; }
        }

        public bool visited
        {
            get { return _visited; }
            set { _visited = value; }
        } 
        #endregion Properties

        #region Constructors
        public Node()
        {

        }

        public Node(string myData)
            : this(myData, null)
        {

        }

        public Node(string myData, List<Node> myNeighbours)
        {
            _data = myData; _neighbours = myNeighbours;
        }
        #endregion Constructors

        #region Methods

        #endregion Methods
        

       
        
       










    }
}
