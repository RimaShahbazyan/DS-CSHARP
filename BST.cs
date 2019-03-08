using System;
namespace DS_CSHARP
{
    public class BST<K, V> where K : IComparable<K>
    {

        protected Node root=null;

        public BST()
        {
            Size = 0;
        }
        public int Size{get;set;}

        //Adds an element to BST
        public virtual void Add(K key, V value)
        {
            Node newNode = new Node(key, value);
            addNode(newNode);
        }
        protected void heightUpDate(Node current)
        {
            while (current != null)
            {
                int rightHeight;
                int leftHeight;

                if (current.RightChild == null)
                    rightHeight = -1;
                else
                    rightHeight = current.RightChild.Height;

                if (current.LeftChild == null)
                    leftHeight = -1;
                else
                    leftHeight = current.LeftChild.Height;

                current.Height = Math.Max(rightHeight, leftHeight) + 1;
                current = current.Parent;
            }
        }
        protected Node addNode(Node newNode)
        {
            if (root == null)
            {
                root = newNode;
                Size++;
                return newNode ;
            }

            Node current = root;
            while (true)
            {
                if (current.Key .CompareTo( newNode.Key)>=0)
                {
                    if (current.LeftChild == null)
                    {
                        current.LeftChild = newNode;
                        break;
                    }
                    current = current.LeftChild;
                }
                else
                {
                    if (current.RightChild == null)
                    {
                        current.RightChild = newNode;
                        break ;
                    }
                    current = current.RightChild;
                }
            }

            newNode.Parent = current;
            Size++;

            // change the height of  Nodes above
            heightUpDate(newNode.Parent);
            return newNode;

        }
        //Findes the 1st node with given key
        public V Find(K x)
        {
            Node result = findNode(x);
            if (result != null)
                return result.Value;
            else return default(V);  
        }
        protected Node findNode(K x)
        {
            Node current=root;
            while ( current != null )
            {
                if (current.Key .CompareTo( x)==1)
                    current = current.LeftChild;
                if (current.Key .CompareTo( x)==-1)
                    current = current.RightChild;
                else return current;

            }
            return null;
        }


        // returns the Next in order member
        private Node nextInOrder(Node x)
        {
            Node current = x;

            if(x == null) 
            {
                return null;
            }
            if (x.RightChild != null)
            {
                current = current.RightChild;
                while (current.LeftChild != null)
                {
                    current = current.LeftChild;
                }

                return current;
            }
            if (x.RightChild == null && x.Parent != null )
            {
                while (current.Parent != null && current.Parent.LeftChild != current )
                {
                    current = current.Parent;
                }
                if (current.Parent == null)
                    return null;
                return current.Parent;
            }
            return null;
        }

        //removes the Node with the given key
        public V Remove(K x)
        {
            Node deleted = findNode(x);
            RemoveNode(deleted).Parent = deleted;
            return deleted.Value;
        }
        protected Node RemoveNode(Node deleted)
        {
            if (deleted == null)
                throw new MissingMemberException("the tree doesn't contain current key");

            Node current = deleted.Parent;
            bool switched= false;

            if (deleted.RightChild == null && deleted.LeftChild == null)
            {
                if (deleted.Parent.RightChild == deleted)
                {
                    deleted.Parent.RightChild = null;
                    //deleted.Parent = deleted;
                }
                else 
                {
                    deleted.Parent.LeftChild = null;
                   // deleted.Parent = deleted;
                }

            }
            else if (deleted.RightChild == null)
            {
                if (deleted.Parent.RightChild == deleted)
                    deleted.Parent.RightChild = deleted.LeftChild;
                    
                else
                    deleted.Parent.LeftChild = deleted.LeftChild;

                deleted.LeftChild.Parent = deleted.Parent;

            }
            else if (deleted.LeftChild == null)
            {
                if (deleted.Parent.RightChild == deleted)
                    deleted.Parent.RightChild = deleted.RightChild;

                else
                    deleted.Parent.LeftChild = deleted.RightChild;

                deleted.RightChild.Parent = deleted.Parent;

            }

            else 
            {
                Switch(deleted, nextInOrder(deleted));
                switched = true;
                RemoveNode(deleted);
            }
            if(!switched)
            {
                Size--;
                while(current!= null)
                {
                    current.Height--;
                    current = current.Parent;
                }
            }
            return deleted;


        }

        private void Switch(Node n1, Node n2)
        {
            Node temp;
            temp = n1.Parent;
            n1.Parent = n2.Parent;
            n2.Parent = temp;

            temp = n1.RightChild;
            n1.RightChild = n2.RightChild;
            n2.RightChild = temp;
            if (n1.RightChild != null)
                n1.RightChild.Parent = n1;
            if (n2.RightChild != null)
                n2.RightChild.Parent = n2;

            temp = n1.LeftChild;
            n1.LeftChild = n2.LeftChild;
            n2.LeftChild = temp;
            if (n1.LeftChild != null)
                n1.LeftChild.Parent = n1;
            if (n2.LeftChild != null)
                n2.LeftChild.Parent = n2;

            if (n1.Parent != null)
            {
                if (n1.Parent.RightChild == n2)
                    n1.Parent.RightChild = n1;
                else n1.Parent.LeftChild = n1;

            }
            if (n2.Parent != null)
            {
                if (n2.Parent.RightChild == n1)
                    n2.Parent.RightChild = n2;
                else n2.Parent.LeftChild = n2;

            }
        }

        public  void Print()
        {
            Node current = root;
            if (current == null)
                return;
            while( current.LeftChild != null)
            {
                current = current.LeftChild;
            }
            while (current != null)
            {
                Console.WriteLine(current.Key);
                current = nextInOrder(current);
            }

        }

        protected class Node
        {
            public Node(K key, V value)
            {
                Key = key;
                Value = value;
                Height=0;
            }

            public K Key { get;  }
            public V Value { get;  }

            public Node Parent { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }

            public int Height { get; set; }
        }
    }
}
