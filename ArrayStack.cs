using System;
namespace DataStructures
{
    public class ArrayStack<T>
    {
        private T[] arr;
        private int index=-1;
        public ArrayStack(int capacity)
        {
            arr=new T[capacity];
        }
        public T Top()
        {
            if (IsEmpty())
                throw new Exception();
            return arr[index];
        }
        public void Push(T value)
        {
            if(arr.Length==Size())
            throw new Exception();
            arr[++index]=value;
        }
        public T Pop()
        {
            if(IsEmpty())
                throw new Exception();
            
            T deleted= arr[index];
            arr[index--]=default(T);
            return deleted;
            
        }
        public int Size()
        {
            return index+1;
        }
        public bool IsEmpty()
        {
            return Size()==0;
        }

        public void Reverse()
            {
                Queue <T> q= new Queue<T>();

                while(!this.IsEmpty())
                {
                q.Enqueue(this.Pop());
                
                }
                while(!q.IsEmpty())
                {
                    this.Push(q.Dequeue());
                }
                
            }
    } 
}