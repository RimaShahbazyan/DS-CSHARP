using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GCD.gcd(6,16));
        }

        static void Reverse<T>(Stack<T> stack)
        {
            Queue <T> q= new Queue<T>();

            while(!stack.IsEmpty())
            {
            q.Enqueue(stack.Pop());
            
            }
            while(!q.IsEmpty())
            {
                stack.Push(q.Dequeue());
            }
            
        }
    }
}
