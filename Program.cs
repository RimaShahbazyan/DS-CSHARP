using System;
using System.Collections.Generic;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
             foreach (int i in WaterJugProblem.Solve(4,9,3))
             {
                 System.Console.WriteLine(i);
             }
        } 
        
    }
}
