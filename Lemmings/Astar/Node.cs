using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lemmings.Astar
{
    public class Node
    {
        #region DataMembers
        private string _data; 
        private List<Node> _neighbours = null; 
        private bool _visited = false;
        private Vector2 _position;
        private Texture2D _texture;
        private int _element;
        private Node _parent;
        private bool _blocked;
        private int _G = 0;
        private int _H = 0;
        private int _F = 0;

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

        public Vector2 position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Texture2D texture
        {
            get { return _texture; }
            set { _texture = value; }
        }

        public int element
        {
            get { return _element; }
            set { _element = value; }
        }

        public Node parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public bool blocked
        {
            get { return _blocked; }
            set { _blocked = false; }
        }

        public int G
        {
            get { return _G; }
            set { _G = value; }
        }
        public int H
        {
            get { return _H; }
            set { _H = value; }
        }
        public int F
        { 
            get { return _F; }
            set { _F = value; }
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
        public void Draw(SpriteBatch sBatch)
        {
            sBatch.Draw(texture, position, new Rectangle(0,0,50,50), Color.White);
            
        }
        #endregion Methods
        

       
        
       










    }
}
