using System;
namespace DataStructures
{
    public class Queue<T>
    {
        SinglyLinkedList<T> list;
        public Queue()
        {
            list= new SinglyLinkedList<T>();
        }
        public T Peek()
        {
            return list.First();
        }
        public void Enqueue(T value)
        {
            list.AddLast(value);
        }
        public T Dequeue ()
        {
            return list.RemoveFirst();
        }
        public int Size()
        {
            return list.Size();
        }
        public bool IsEmpty()
        {
            return list.IsEmpty();
        }
        public void Print()
        {
            list.Print();
        }

    }

}
