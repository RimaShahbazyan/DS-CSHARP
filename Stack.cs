using System;

namespace DS_CSHARP
{
 public class Stack<T>
    {
        SinglyLinkedList<T> list;
        public Stack()
        {
            list= new SinglyLinkedList<T>();
        }
        
        
        public T Top()
        {
            return list.First();

        }
        public void Push(T value)
        {
            list.AddFirst(value);
        }
        public T Pop()
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