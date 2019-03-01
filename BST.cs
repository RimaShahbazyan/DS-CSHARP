using System;
namespace DS_CSHARP
{
    public class BST<K, V> where K : IComparable<K>
    {
        public BST()
        {
            Size = 0;
        }
        protected Node root=null;
        public int Size{get;set;}

        //Adds an element to BST
        public virtual void Add(K key, V value)
        {
            add(key, value);
        }
        public Node add(K key ,V value)
        {
            Node newNode = new Node(key, value);
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
                        newNode.Parent = current;
                        Size++;
                        return newNode;
                    }
                    current = current.LeftChild;
                }
                else
                {
                    if (current.RightChild == null)
                    {
                        current.RightChild = newNode;
                        newNode.Parent = current;
                        Size++;
                        return newNode ;
                    }
                    current = current.RightChild;
                }
            }

        }
        //Findes the 1st node with given key
        protected Node Find(K x)
        {
            Node current=root;
            while ( current != null )
            {
                if (current.Key .CompareTo( x)>=0)
                    current = current.LeftChild;
                if (current.Key .CompareTo( x)==-1)
                    current = current.RightChild;
                else return current;

            }
            return null;
        }

        public V Search (K x)
        {
            Node result = Find(x);
            if (result != null)
                return result.Value;
            else throw new MissingMemberException();
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
        public virtual V Remove(K x)
        {
            Node delete = Find(x);
            Node current ;

            if (delete == null)
                throw new MissingMemberException("the tree doesn't contain current key");

            if (delete.Parent.RightChild == delete)
                current=delete.Parent.RightChild = nextInOrder(delete);
            
            else
                current=delete.Parent.LeftChild = nextInOrder(delete);

            if (current != null)
            {
                current.Parent = delete.Parent;
                current.LeftChild = delete.LeftChild;
                current.RightChild = delete.RightChild;
            }
            Size--;
            return delete.Value;
               
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

        public class Node
        {
            public Node(K key, V value )
            {
                Key = key;
                Value = value;
            }

            public K Key { get; private set; }
            public V Value { get; private set; }

            public Node Parent { get; set; }

            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }

            public int Height { get; set; }
            

             
        }
    }
}
