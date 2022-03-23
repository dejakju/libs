using System.Collections.Generic;

namespace libs
{
    public class Node<T>
    {
        #region Private Members

        private T data;
        private Node<T> next;

        #endregion

        #region Constructors

        public Node()
        {
            data = default;
            next = null;
        }

        public Node(T o)
        {
            data = o;
            next = null;
        }

        public Node(T o, Node<T> n)
        {
            data = o;
            next = n;
        }

        #endregion

        #region Public Getters and Setters

        public T getData()
        {
            return data;
        }

        public Node<T> getNextNode()
        {
            return next;
        }
        
        public void setData(T o)
        {
            data = o;
        }

        public void setNextNode(Node<T> n)
        {
            next = n;
        }

        #endregion
    }
}