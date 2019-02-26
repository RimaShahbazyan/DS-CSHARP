using System;
namespace DS_CSHARP
{
    public static class Heap
    {
        public static void HeapifyDown(int[] arr, int i0, int end) 
        {
            int temp;
            int j;
            for(int i=i0; i*2+1 <= end; )
            {
                j = i*2+2;
                if(j > end )
                    j--;
                if( arr[i] < arr[i*2+1] && arr[i] < arr[j] )
                    return;
                
                if(arr[i*2+1] < arr [j])
                {
                    temp = arr[i*2+1];
                    arr[i*2+1] = arr[i];
                    arr[i] = temp;
                    i=i*2+1;
                }
                else 
                {
                    temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                    i=i*2+2;
                }
            }
        }
        public static void HeapifyUp(int[] arr, int j)
        {
            int temp;
            for(int i=j; (i-1)/2 >= 0; i=(i-1)/2)
            {
                if(arr[(i-1)/2]> arr[i])
                {
                    temp = arr[(i-1)/2];
                    arr[(i-1)/2] = arr[i];
                    arr[i] = temp;
                }
                else return;

            }
        }
        public static void HeapSort1(int[] arr)
        {
            int temp;
            int end = arr.Length - 1;
            for (int i = end; i >= 0; i--)
            {
                HeapifyDown(arr, i, end);
            }
            while(end>=0)
            {
                temp = arr[end];
                arr[end] = arr[0];
                arr[0] = temp;
                end--;
                HeapifyDown(arr, 0, end);

            }
        }
        public static void HeapSort2(int[] arr)
        {
            int temp;
            int end = arr.Length - 1;
            for (int i = 0; i > arr.Length; i++)
            {
                HeapifyUp(arr, i);
            }
            while (end >= 0)
            {
                temp = arr[end];
                arr[end] = arr[0];
                arr[0] = temp;
                end--;
                HeapifyDown(arr, 0, end);

            }

        }
    }
}