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
                int rightHeight = current.RightChild != null ?
                    current.RightChild.Height : -1;
                int leftHeight = current.LeftChild != null ? 
                    current.LeftChild.Height : -1;
                // rightHeavy
                if (rightHeight - leftHeight > 1)
                {
                    rightHeight = current.RightChild.RightChild != null ? 
                    current.RightChild.RightChild.Height : -1;
                    leftHeight = current.RightChild.LeftChild != null ? 
                    current.RightChild.LeftChild.Height : -1;

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
                    rightHeight = current.LeftChild.RightChild != null ? 
                    current.LeftChild.RightChild.Height : -1;
                    leftHeight = current.LeftChild.LeftChild != null ? 
                    current.LeftChild.LeftChild.Height : -1;

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
            else
                newRoot = B.Parent.LeftChild == B?
                B.Parent.LeftChild = B.RightChild : B.Parent.RightChild = B.RightChild;

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

        private void RotateRight(Node D)
        {
            Node newRoot;
            if (D.Parent == null)
                newRoot = root = D.LeftChild;
            else
                newRoot = D.Parent.LeftChild == D ? 
                D.Parent.LeftChild = D.LeftChild : D.Parent.RightChild = D.LeftChild;

            newRoot.Parent = D.Parent;

            //change C into the Left child of B
            D.LeftChild = newRoot.RightChild;
            if (newRoot.LeftChild != null)
            {
                newRoot.LeftChild.Parent = D;
            }

            // change  D into the right child of B
            newRoot.RightChild = D;
            D.Parent = newRoot;

        }


    }
}
