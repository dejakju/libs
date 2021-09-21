namespace Kju
{
    public class Node
    {
        #region Private Members
        private object data;
        private Node next;
        #endregion

        #region Constructors
        public Node()
        {
            data = null;
            next = null;
        }

        public Node(object o)
        {
            data = o;
            next = null;
        }

        public Node(object o, Node n)
        {
            data = o;
            next = n;
        }
        #endregion

        #region Public Getters/Setters
        public void setNextNode(Node n)
        {
            next = n;
        }

        public Node getNextNode()
        {
            return next;
        }

        public void setData(object o)
        {
            data = o;
        }

        public object getData()
        {
            return data;
        }
        #endregion
    }
}