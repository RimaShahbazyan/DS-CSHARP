using System;
namespace DS_CSHARP
{
    public class Heap<K, V> where  K :  IComparable<K>
    {
        private int arrsize = 256;
        private int endIndex = 0;
        private V[] HeapArr;

        Func<V, K> func;
        public V Root { get { return HeapArr[0]; } }
        public int Size { get; private set; } = 0;
        public bool IsEmpty { get { return Size == 0; } }

        public Heap(Func<V, K> func)
        {
            this.func = func;
            endIndex = 0;
            HeapArr = new V[arrsize];
        }
        public Heap(int size, Func<V, K> func)
        {
            this.func = func;
            arrsize = size;
            HeapArr = new V[arrsize];
        }
       
        public void Insert(V obj)
        {
            if (endIndex >= arrsize)
                throw new IndexOutOfRangeException("your heap capacity isn't " +
                                                    "enough to add new obj");

            HeapArr[endIndex] = obj;
            HeapifyUp(HeapArr, endIndex);
            endIndex++;
            Size++;
        }

        public V RemoveMin()
        {
            V min = HeapArr[0];
            HeapArr[0] = HeapArr[--endIndex];
            HeapifyDown( 0, endIndex);
            return min;
        }
        public static Heap<K, V> Heapify(V[] arr, Func<V, K> func)
        {
            Heap<K, V> newHeap = new Heap<K, V>(arr.Length, func);

            for (int i= arr.Length-1; i >= 0; i--)
            {
                newHeap.HeapArr[i] = arr[i];
                newHeap.HeapifyDown(i, arr.Length-1);
            }
            return newHeap;
        }




        public void HeapifyDown( int i0, int end) 
        {
            V temp;
            int j;
            for(int i=i0; i*2+1 <= end; )
            {
                j = i*2+2;
                if(j > end )
                    j--;
                if( func(HeapArr[i]).CompareTo(func(HeapArr[i*2+1]))==-1 
                    && func(HeapArr[i]).CompareTo(func(HeapArr[j]))==-1)
                    return;
                
                if(func(HeapArr[i*2+1]).CompareTo(func( HeapArr [j]))==-1)
                {
                    temp = HeapArr[i*2+1];
                    HeapArr[i*2+1] = HeapArr[i];
                    HeapArr[i] = temp;
                    i=i*2+1;
                }
                else 
                {
                    temp = HeapArr[j];
                    HeapArr[j] = HeapArr[i];
                    HeapArr[i] = temp;
                    i=i*2+2;
                }
            }
        }
        public  void HeapifyUp(V[] arr, int j)
        {
            V temp;
            for(int i=j; (i-1)/2 >= 0; i=(i-1)/2)
            {
                if(func(arr[(i-1)/2]).CompareTo(func( arr[i]))==1)
                {
                    temp = arr[(i-1)/2];
                    arr[(i-1)/2] = arr[i];
                    arr[i] = temp;
                }
                else return;

            }
        }
        //public static void HeapSort1(int[] arr)
        //{
        //    int temp;
        //    int end = arr.Length - 1;
        //    for (int i = end; i >= 0; i--)
        //    {
        //        HeapifyDown(arr, i, end);
        //    }
        //    while(end>=0)
        //    {
        //        temp = arr[end];
        //        arr[end] = arr[0];
        //        arr[0] = temp;
        //        end--;
        //        HeapifyDown(arr, 0, end);

        //    }
        //}
        //public static void HeapSort2(int[] arr)
        //{
        //    int temp;
        //    int end = arr.Length - 1;
        //    for (int i = 0; i > arr.Length; i++)
        //    {
        //        HeapifyUp(arr, i);
        //    }
        //    while (end >= 0)
        //    {
        //        temp = arr[end];
        //        arr[end] = arr[0];
        //        arr[0] = temp;
        //        end--;
        //        HeapifyDown(arr, 0, end);

        //    }
        //}
    }
   
}