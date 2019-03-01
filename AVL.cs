using System;

namespace DS_CSHARP
{
    public class AVL<K,V>: BST<K, V> where K : IComparable<K>
    {
        public AVL()
        {

        }
        
        public override void Add(K key, V value)
        {
            Node current= addNode(key, value);
            if (current == root)
                return;
           while(current != null)
            { 
                // rightHeavy
                if(current.RightChild.GetHeight() - current.LeftChild.GetHeight() > 1)
                { 
                    if(current.RightChild.LeftChild.GetHeight() > current.RightChild.RightChild.GetHeight())
                    {
                        RotateRight(current.RightChild);
                    }
                    RotateLeft(current);
                    return;
                }

                // leftHeavy

                if (current.LeftChild.GetHeight() - current.RightChild.GetHeight() > 1)
                {
                    if (current.LeftChild.RightChild.GetHeight() > current.LeftChild.LeftChild.GetHeight())
                    {
                        RotateLeft(current.RightChild);
                    }
                    RotateRight(current);
                    return;
                }

                current = current.Parent;


            }
            


        } 




        // supposing we have a tree   B                                   D
        //                          A   D    which sholud be converted  B   E
        //                             C E                             A C
        public void RotateLeft(Node x)
        {
            Node newRoot;
            if (x.Parent==null)
                newRoot = root = x.RightChild;
            else 
                if (x.Parent.LeftChild == x)
                    newRoot=x.Parent.LeftChild = x.RightChild;
                else
                    newRoot=x.Parent.RightChild = x.RightChild;

            newRoot.Parent = x.Parent;

            //change C into the Right child of B
            x.RightChild = newRoot.LeftChild;
            if(newRoot.LeftChild != null)
            {
                newRoot.LeftChild.Parent = x;
            }

            // change  B into the left child of D
            newRoot.LeftChild = x;
            x.Parent = newRoot;
        }
        private void RotateRight(Node x)
        {
            Node newRoot;
            if (x.Parent == null)
                newRoot = root = x.LeftChild;
            else
                if (x.Parent.LeftChild == x)
                newRoot = x.Parent.LeftChild = x.LeftChild;
            else
                newRoot = x.Parent.RightChild = x.LeftChild;

            newRoot.Parent = x.Parent;

            //change C into the Left child of B
            x.LeftChild = newRoot.RightChild;
            if (newRoot.LeftChild != null)
            {
                newRoot.LeftChild.Parent = x;
            }

            // change  D into the right child of B
            newRoot.RightChild = x;
            x.Parent = newRoot;

        }


    }
}
