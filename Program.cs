using System;
using System.Collections.Generic;

namespace DS_CSHARP
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 0, 5, 6 };
            AVL<int, int> x = new AVL<int, int>();

            x.Add(11, 0);
            x.Add(6, 0);
            x.Add(16, 0);
            x.Add(3, 0);
            x.Add(9, 0);
            x.Add(13, 0);
            x.Add(18, 0);
            x.Add(2, 0);
            x.add(5, 0);
            x.Add(7, 0);
            x.Add(10, 0);
            x.Add(12, 0);
            x.Add(15, 0);
            x.Add(17, 0);
            BST<int, int>.Node a = x.add(19, 0);
            x.Add(1, 0);
            x.Add(4, 0);
            x.Add(8, 0);
            x.Add(14, 0);
            x.Add(20, 0);
            x.Add(21, 0);
            x.RotateLeft(a);
            x.Print();



        } 

    }
}
