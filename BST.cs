using System;
namespace DS_CSHARP
{
    public class BST<K,V> where K: IComparable<K>
    {
        public BST()
        {


        }
        public Node root;
        public Node Add(K key ,V value)
        {
            Node newNode = new Node(key, value);
            if (root == null)
            {
                root = newNode;
                return root;
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
                        return  newNode;
                    }
                    current = current.RightChild;
                }
            }
            //return newNode;
        }
        public V Find(K x)
        {
            Node current=root;
            while ( current != null )
            {
                if (current.Key .CompareTo( x)==1)
                    current = current.LeftChild;
                if (current.Key .CompareTo( x)==-1)
                    current = current.RightChild;
                else return current.Value;

            }
            throw new  MissingMemberException("this member is missing");
        }

        public Node nextInOrder(Node x)
        {
            Node current = x;

            if(x == null) 
            {
                throw new NullReferenceException();
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
                while (current.Parent.LeftChild != current)
                {
                    current = current.Parent;
                }
                return current.Parent;
            }
            else throw new MissingMemberException("This is the last element of BST");
        }



        //public V Remove(K x)
        //{
        //    Node current = root;
        //    while (current != null)
        //    {
        //        if (current.Key.CompareTo(x) == 1)
        //            current = current.LeftChild;
        //        if (current.Key.CompareTo(x) == -1)
        //            current = current.RightChild;
        //        else
        //        {
        //            current.Parent
        //            return current.Value;
        //        }
        //    }
        //}
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

            public int Height { get; }


        }
    }
}
