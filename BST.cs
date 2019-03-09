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
                if (current.Key .CompareTo( x) == 1)
                    current = current.LeftChild;
                else if (current.Key .CompareTo( x) == -1)
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
                if (deleted != root)
                {
                    if (deleted.Parent.RightChild == deleted)
                    {
                        deleted.Parent.RightChild = null;
                    }
                    else
                    {
                        deleted.Parent.LeftChild = null;
                    }
                }
                else root = null;
            }
            else if (deleted.RightChild == null)
            {
                if (deleted != root)
                {
                    if (deleted.Parent.RightChild == deleted)
                        deleted.Parent.RightChild = deleted.LeftChild;

                    else
                        deleted.Parent.LeftChild = deleted.LeftChild;
                }

                else root = deleted.LeftChild;

                deleted.LeftChild.Parent = deleted.Parent;

            }
            else if (deleted.LeftChild == null)
            {
                if (deleted != root)
                {
                    if (deleted.Parent.RightChild == deleted)
                        deleted.Parent.RightChild = deleted.RightChild;

                    else
                        deleted.Parent.LeftChild = deleted.RightChild;
                }
                else root = deleted.RightChild;

                deleted.RightChild.Parent = deleted.Parent;

            }

            else
            {
                Node next = nextInOrder(deleted);
                deleted.Switch(next);
                switched = true;
                deleted = next;
                RemoveNode(deleted);
            }
            if(!switched)
            {
                Size--;
                heightUpDate(current);
            }
            return deleted;
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
                Console.Write(current.Key);
                Console.Write(' ');
                current = nextInOrder(current);
            }
            Console.WriteLine();

        }

        protected class Node
        {
            public Node(K key, V value)
            {
                Key = key;
                Value = value;
                Height=0;
            }

            public K Key { get; private set; }
            public V Value { get; private set; }

            public Node Parent { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }

            public int Height { get; set; }
            public void Switch(Node x )
            {
                K tempK = this.Key;
                this.Key = x.Key;
                x.Key = tempK;

                V tempV = this.Value;
                this.Value = x.Value;
                x.Value = tempV;

                
            }
        }
    }
}
