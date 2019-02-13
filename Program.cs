using System;
using System.Collections.Generic;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr ={1,2,3,0,5,6};
            Hip.HipifyUp(arr,3);
            foreach (int i in arr)
                Console.WriteLine(i) ;
        } 
        
    }
}
