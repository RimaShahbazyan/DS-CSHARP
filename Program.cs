using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
        //     DoublyLinkedList<int> abs = new DoublyLinkedList<int>();
        //     Console.WriteLine(abs.IsEmpty());
        //     abs.AddFirst(2);
        //     abs.AddLast(3);
        //     abs.AddFirst(1);
        //     abs.AddLast(4);
        //    // Console.WriteLine(abs.RemoveFirst());
        //     abs.Reverse();
        //     abs.Print();
        //     Console.WriteLine(abs.Size);
        //     Console.WriteLine(abs.First);
        ArrayQueue<int> m= new ArrayQueue<int>(4);
        m.Enqueue(1);
        m.Enqueue(2);
        m.Enqueue(3);
        m.Enqueue(4);
        m.Dequeue();
        m.Dequeue();
        m.Enqueue(5);
        m.Dequeue();
        //m.Reverse();
       m.Print();
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
