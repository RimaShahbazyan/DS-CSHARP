using System;
using System.Collections.Generic;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr ={1,9,3,4,5,6};
            Heap.HeapifyDown(arr,1);
            foreach (int i in arr)
                Console.WriteLine(i) ;
        } 
        
    }
}
