using System.Collections.Generic;

namespace Kju
{
    public class SingleLL<T>
    {
        private Node<T> headNode;

        private string Identifier;

        // add(node)
        // add(int position, node)
        // isEmpty()
        // isFull()
        // length()
        // contains(nodeData)
        // getData(node)
        // getData(int position)
        // listAll()
        // replace(int position, node)
        // remove(int position)


        // add node in a empty list
        // add node in a list with one node
        // add node in a list with two or more nodes



        public bool add(int position, T nodeData)
        {
            if (position >= 1)
            {
                if (position == 1 && isEmpty())
                {
                    Node<T> newNode = new Node<T>(nodeData);
                    newNode.setNextNode(headNode);
                    headNode = newNode;
                    return true;
                }
                else
                {
                    Node<T> currentNode = headNode;
                    for (int i = 0; i < (position - 1) && currentNode != null; i++)
                    {
                        currentNode = currentNode.getNextNode();
                    }
                    if (currentNode == null)
                    {
                        return false;
                    }
                    // a->b->c->d->e->f

                    Node<T> newNode = new Node<T>(nodeData);
                    newNode.setNextNode(currentNode.getNextNode());
                    currentNode.setNextNode(newNode);
                    return true;
                }
            }
            else
                return false;
        }


        public bool isEmpty()
        {
            return headNode == null;
        }

        public bool isFull()
        {
            return false;
        }

        public int length()
        {
            int counter = 0;
            Node<T> currentNode = headNode;
            while (currentNode != null)
            {
                counter++;
                currentNode = currentNode.getNextNode();
            }
            return counter;
        }

        public List<T> listAll()
        {
            List<T> nodes = new List<T>();
            Node<T> currentNode = headNode;
            for (int i = 0; i < length() && currentNode != null ; i++)
            {
                nodes.Add(currentNode.getData());
                currentNode = currentNode.getNextNode();
            }
            return nodes;
        }

        public string getIdentifier()
        {
            return Identifier;
        }

        public void setIdentifier(string id)
        {
            Identifier = id;
        }

    }
}