using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace libs
{
    public class ExecException : System.Exception
    {
        public ExecException() { }
        public ExecException(string message) : base(message) { }
        public ExecException(string message, System.Exception inner) : base(message, inner) { }
        protected ExecException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public static class Exec
    {
        private static Node<object> headNode;
        public static Node<object> HeadNode { get => headNode; set => headNode = value; }



        // Non-Zero-Based List Nodes
        public static bool Insert<T>(int position, object node)
        {
            // If the inserted node is null (i.e. invalid) or the position before the first (hence, non-zero-based), then return
            if (node is null || position <= 0)
            {
                return false;
            }

            // Check for the first position
            if (position == 1)
            {
                Node<object> currentNode = HeadNode;
                Node<object> newNode = new Node<object>(node);
                newNode.setNextNode(currentNode);
                HeadNode = newNode;
                return true;
            }

            // Traverse list for correct insert position (non-zero-based)
            if (position > 1)
            {
                Node<object> currentNode = HeadNode;
                // Traverse
                // A -> B -> ()  C -> D -> F
                // 1 -> 2 -> ()  3 -> 4 -> 5

                // p=3, i=0, 0<2 -> true
                // p=3, i=1, 1<2 -> true
                // p
                for (int i = 0; i < position - 1 && currentNode != null; i++)
                {
                    currentNode = currentNode.getNextNode();
                }
                // Check for a null node (i.e. we have a invalid node)
                if (currentNode == null)
                {
                    return false;
                }
                // Insert node at specified position
                // A -> B -> ()  C -> D -> F
                Node<object> newNode = new Node<object>(node);
                newNode.setNextNode(currentNode.getNextNode());
                currentNode.setNextNode(newNode);
                return true;
            }

            return false;
        }

        public static bool Add<T>(object node)
        {
            return Insert<T>(GetLength() + 1, node);
        }

        public static int GetLength()
        {
            Node<object> currentNode = HeadNode;
            int ctr = 0;
            while (currentNode != null)
            {
                currentNode = currentNode.getNextNode();
                ctr++;
            }
            return ctr;
        }

        public static bool IsEmpty()
        {
            return (HeadNode == null);
        }
    }

}