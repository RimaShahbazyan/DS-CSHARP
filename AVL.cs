using System;

namespace DS_CSHARP
{
    public class AVL<K, V> : BST<K, V> where K : IComparable<K>
    {
        public AVL()
        {

        }

        public override void Add(K key, V value)
        {
            Node newNode = new Node(key, value);
            balance(addNode(newNode));
        }

        private void balance (Node current)
        {
            if (current == root)
                return;
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

                // rightHeavy
                if (rightHeight - leftHeight > 1)
                {
                    if (current.RightChild.RightChild == null)
                        rightHeight = -1;
                    else
                        rightHeight = current.RightChild.RightChild.Height;

                    if (current.RightChild.LeftChild == null)
                        leftHeight = -1;
                    else
                        leftHeight = current.RightChild.LeftChild.Height;

                    if (leftHeight > rightHeight)
                    {
                        RotateRight(current.RightChild);
                    }
                    RotateLeft(current);

                    break;
                }

                // leftHeavy

                if (leftHeight - rightHeight > 1)
                {
                    if (current.LeftChild.RightChild == null)
                        rightHeight = -1;
                    else
                        rightHeight = current.LeftChild.RightChild.Height;

                    if (current.LeftChild.LeftChild == null)
                        leftHeight = -1;
                    else
                        leftHeight = current.LeftChild.LeftChild.Height;

                    if (rightHeight > leftHeight)
                    {
                        RotateLeft(current.RightChild);
                    }
                    RotateRight(current);
                    break;
                }

                current = current.Parent;
            }
            heightUpDate(current);
        }

        public new V  Remove(K key)
        {

            Node delated = RemoveNode(findNode(key));
            Node current = delated.Parent;
            delated.Parent = delated;
            balance(current);
            return delated.Value;

        }


        // supposing we have a tree   B                                      D
        //                          A   D    which sholud be converted to  B   E
        //                             C E                                A C
        private void RotateLeft(Node B)
        {
            Node newRoot;
            if (B.Parent == null)
                newRoot = root = B.RightChild;
            else if (B.Parent.LeftChild == B)
                newRoot = B.Parent.LeftChild = B.RightChild;
            else
                newRoot = B.Parent.RightChild = B.RightChild;

            newRoot.Parent = B.Parent;

            //change C into the Right child of B
            B.RightChild = newRoot.LeftChild;
            if (newRoot.LeftChild != null)
            {
                newRoot.LeftChild.Parent = B;
            }

            // change  B into the left child of D
            newRoot.LeftChild = B;
            B.Parent = newRoot;
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
