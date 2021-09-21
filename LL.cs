//     public class NodeCollection
//     {
//         private Node headNode;

//         public Node GetNodeAt(int position)
//         {
//             if (IsEmpty() || position < 1)
//             {
//                 return null;
//             }

//             Node currentNode = headNode;
//             object tmpObj = headNode.getData();

//             for (int i = 0; i < (position - 1) && currentNode != null; i++)
//             {
//                 currentNode = currentNode.getNextNode();
//             }
//             if (currentNode == null)
//             {
//                 return null;
//             }
//             return currentNode;
//         }

//         public bool InsertAt(int position, object newEntry)
//         {
//             Node tmp = headNode;
//             if (position >= 0)
//             {
//                 Node newNode = new Node(newEntry);
//                 if (IsEmpty() || position == 0)
//                 {
//                     newNode.setNextNode(tmp);
//                     headNode = newNode;
//                     return true;
//                 }
//                 else
//                 {
//                     for (int i = 0; i < position && tmp != null; i++)
//                     {
//                         tmp = tmp.getNextNode();
//                     }
//                     if (tmp == null)
//                     {
//                         return false;
//                     }
//                     newNode.setNextNode(tmp.getNextNode());
//                     tmp.setNextNode(newNode);
//                     return true;
//                 }
//             }
//             else
//             {
//                 return false;
//             }
//         }

//         public bool Insert(object newEntry)
//         {
//             if (IsEmpty())
//                 return InsertAt(GetLength(), newEntry);
//             else
//                 return InsertAt(GetLength() + 1, newEntry);
//         }

//         public bool IsEmpty()
//         {
//             return (headNode == null);
//         }

//         public bool IsFull()
//         {
//             return false;
//         }

//         public object RemoveAt(int position)
//         {
//             object tmpObj = null;
//             if (IsEmpty() || position < 0)
//             {
//                 return null;
//             }

//             Node currentNode = headNode;

//             if (position == 1)
//             {
//                 tmpObj = currentNode.getData();
//                 headNode = currentNode.getNextNode();
//             }
//             else
//             {
//                 for (int i = 0; i < position && currentNode != null; i++)
//                 {
//                     currentNode = currentNode.getNextNode();
//                 }
//                 if (currentNode == null)
//                 {
//                     return null;
//                 }

//                 tmpObj = currentNode.getNextNode().getData();
//                 currentNode.setNextNode(currentNode.getNextNode().getNextNode());
//             }
//             return tmpObj;
//         }

//         public bool Replace(int position, object newEntry)
//         {
//             if (IsEmpty() || position < 0)
//             {
//                 return false;
//             }

//             Node currentNode = headNode;

//             for (int i = 0; i < position; i++)
//             {
//                 currentNode = currentNode.getNextNode();
//             }
//             currentNode.setData(newEntry);
//             return true;
//         }

//         public object GetEntry(int position)
//         {
//             if (IsEmpty() || position < 0)
//             {
//                 return null;
//             }

//             Node currentNode = headNode;
//             object tmpObj = headNode.getData();

//             for (int i = 0; i < position && currentNode != null; i++)
//             {
//                 currentNode = currentNode.getNextNode();
//             }
//             if (currentNode == null)
//             {
//                 return null;
//             }
//             return currentNode.getData();
//         }

//         public bool Contains(object entry)
//         {
//             Node currentNode = headNode;
//             while (currentNode != null)
//             {
//                 if (currentNode.getData() == entry)
//                 {
//                     return true;
//                 }
//                 currentNode = currentNode.getNextNode();
//             }
//             return false;
//         }

//         public void Clear()
//         {
//             headNode = null;
//         }

//         public int GetLength()
//         {
//             int count = 0;
//             Node currentNode = headNode;
//             while (currentNode != null)
//             {
//                 currentNode = currentNode.getNextNode();
//                 count++;
//             }
//             return count;
//         }



//         // Insert(node) - add a new node at the end of the list
//         // InsertAt(node, index) - add a new node at the specified index
//         // Contains(pattern) - find a pattern in the data of the node
//         // RemoveAt(index) - remove a node at a specified index
//         // bool IsEmpty() - checks if a Nodes list is empty
//         // IsFull() - returns if a Nodes list is full (which is always false)

//     }


//     public class SingleLL
//     {
//         private Node headNode = null;

//         public bool InsertAt(int position, object newObject)
//         {
//             // There are no negative positions
//             if (position < 0)
//                 return false;
            
//             // Insert as the very first node
//             if (position == 0)
//             {
//                 Node tmpNode = headNode;
//                 Node newNode = new Node(newObject);
//                 newNode.setNextNode(tmpNode);
//                 headNode = newNode;
//                 return true;
//             }
//             else if (position > 0)
//             {
//                 Node currentNode = headNode;

//                 for (int i = 0; i <= position && currentNode != null; i++)
//                 {
//                     currentNode = currentNode.getNextNode();
//                 }
//                 if (currentNode == null)
//                 {
//                     return false;
//                 }
//                 Node newNode = new Node(newObject);
//                 newNode.setNextNode(currentNode);
//                 headNode = newNode;
//                 return true;
//             }

//             return false;
//         }

//         public bool Insert(object newObject)
//         {
//             return InsertAt(GetLength(), newObject);
//         }

//         public bool IsEmpty()
//         {
//             return (headNode == null);
//         }

//         public bool IsFull()
//         {
//             return false;
//         }

//         public void Clear()
//         {
//             headNode = null;
//         }

//         public object GetDataAt(int position)
//         {
//             // !!! TODO !!!
//             object tmpObj = null;
//             return tmpObj;

//         }

//         public int GetLength()
//         {
//             int counter = 0;
//             Node currentNode = headNode;
//             while (currentNode != null)
//             {
//                 currentNode = currentNode.getNextNode();
//                 counter++;
//             }
//             return counter;
//         }
//     }

//     public class Node
//     {
//         #region Private Members
//         private object data;
//         private Node next;
//         #endregion

//         #region Constructors
//         public Node()
//         {
//             data = null;
//             next = null;
//         }

//         public Node(object o)
//         {
//             data = o;
//             next = null;
//         }

//         public Node(object o, Node n)
//         {
//             data = o;
//             next = n;
//         }
//         #endregion

//         #region Public Getters/Setters
//         public void setNextNode(Node n)
//         {
//             next = n;
//         }

//         public Node getNextNode()
//         {
//             return next;
//         }

//         public void setData(object o)
//         {
//             data = o;
//         }

//         public object getData()
//         {
//             return data;
//         }
//         #endregion
//     }
// }