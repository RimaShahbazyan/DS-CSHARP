using System;

namespace DS_CSHARP
{
    public class AVL
    {
        public AVL()
        {
        }
        private  Node root;
        private  Node addAsBST(int value)
        {
            Node newNode = new Node(value);
            if (root == null)
            {
                root = newNode;
                return newNode;
            }

            Node current=root;
            while (true)
            {
                if (current.Value >= newNode.Value)
                {
                    if (current.LeftChild == null)
                    {
                        current.LeftChild = newNode;
                        return newNode;
                    }
                    current = current.LeftChild;
                }
                else
                {
                    if (current.RightChild == null)
                    {
                        current.RightChild = newNode;
                        return newNode;
                    }
                    current = current.RightChild;
                }
            }
        }

        private void rotateRight(Node x)
        {
             if(x.IsLeftChild && x.Parent != null)
                x.Parent.LeftChild= x.LeftChild;

            else if (x.Parent != null)
                x.Parent.RightChild = x.LeftChild;

            x.LeftChild.Parent = x.Parent;
            x.LeftChild = x.LeftChild.RightChild;
            x.LeftChild.RightChild = x;

        }
        private void rotateLeft(Node x)
        {
            if (x.IsLeftChild && x.Parent!=null)
                x.Parent.LeftChild = x.RightChild;

            else if(x.Parent != null)
                x.Parent.RightChild = x.RightChild;

            x.RightChild.Parent = x.Parent;
            x.LeftChild = x.RightChild.RightChild;
            x.RightChild.LeftChild = x;

        }

        public void AddNode(int value)
        {
            Node current = addAsBST(value);
            while(current!= null) 
            { 
                if(current.RightChild.getHeight() - current.LeftChild.getHeight() > 1 )
                { 
                    rotateLeft(current);
                    return;
                }
                if (current.RightChild.getHeight()- current.LeftChild.getHeight() < -1 )
                {
                    rotateRight(current);
                    return;
                }
                current = current.Parent;
            }
        }

        

        private class Node
        {
            public Node(int num)
            {
                Value = num;
            }


            public int Value { get; private set; } 

            public Node Parent { get; set; }

            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }

            public int Height { get { return getHeight(); } }
            public int getHeight ()
            {
                if(this.LeftChild== null && this.RightChild == null)
                {
                    return -1;
                }
                if (this.LeftChild == null)
                {
                    return this.RightChild.getHeight()+1;
                }
                if (this.RightChild == null)
                {
                    return this.LeftChild.getHeight() + 1;
                }

                return Math.Max(this.LeftChild.getHeight() , this.RightChild.getHeight())+1;
            }
            public bool IsLeftChild { get { return this.Parent.LeftChild.Value == this.Value; } }

        }
    }
}
