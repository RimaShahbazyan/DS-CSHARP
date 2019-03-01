using System;

namespace DS_CSHARP
{
    public class AVL<K,V>: BST<K, V> where K : IComparable<K>
    {
        public AVL()
        {

        }
        
        //public override void Add(K key, V value)
        //{
        //    Node current= add(key, value);
        //    if (current == root)
        //        return ;
        //    int hight0 = 0;
        //    int hightOfBro;
        //    bool Right=false;
        //    while (current != root)
        //    {
        //        if(current.Parent.RightChild == current)
        //        {
        //            hightOfBro = getHeight(current.Parent.LeftChild);
        //            Right = true;
        //        }
        //        else
        //            hightOfBro = getHeight(current.Parent.RightChild);



        //        if (( hight0 - hightOfBro>1 && Right ) ||(hight0 - hightOfBro < -1 && !Right))
        //        {

        //            RotateRight(current.Parent);
        //            return ;
        //        }
        //        if ((hight0 - hightOfBro > 1 && !Right) || (hight0 - hightOfBro < -1 && Right))
        //        {
        //            RotateLeft(current.Parent);
        //            return;
        //        }
        //        current = current.Parent;
        //        hight0++;

        //    }
        //} 

        private int getHeight(Node x)
        {
            if (x == null)
            {
                return -1;
            }

            return Math.Max(getHeight(x.LeftChild), getHeight(x.RightChild)) + 1;
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
