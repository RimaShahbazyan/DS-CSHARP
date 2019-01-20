using System;
namespace DataStructures
{
    public class ArrayQueue<T>
    {
        T [] arr;
        int index=-1;
        int capasity;
        public ArrayQueue(int n)
        {
            Size=0;
            capasity=n;
            arr = new T[capasity];
        }
        public int Size{get; private set;}
        public bool IsEmpty{get {return Size==0;}}
        public T Peek()
        {
            if (Size==0)
                throw new Exception();
            return arr[index];
        }
        public void Enqueue(T element)
        {
            if(Size == capasity)
            throw new Exception();
            if(index==capasity-1)
                index=-1;
            arr[++index]= element;
            Size++;
        }
        public T Dequeue()
        {
            if(IsEmpty)
                throw new Exception();

            T delated=arr[abs(index+1-Size)];
            arr[abs(index+1-Size)]=default(T);
            Size--;
          
                return delated;

        } 
        public void Print()
        {
            int cycle=Size;
            for(int i=abs(index+1-Size); cycle>0;cycle--)
            {
            Console.WriteLine(this.arr[i]);
            if(i==capasity-1)
                i=-1;
            i++;
            }
        }
        public void Reverse()
        {
            T[] reversed = new T[capasity];
            int cycle=Size;
            for(int i=0; i>Size; i++)
            {
                if(index-i>0)
                reversed[i]=arr[index-i];
                else
                reversed[i]=arr[index-i+capasity];
            }
            arr=reversed;
            index=Size-1;
        }
        private int abs(int n)
        {
            if(n<0)
                n=-n;
            return n;
        }
        


    }
}