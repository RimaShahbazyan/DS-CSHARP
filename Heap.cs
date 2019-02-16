using System;
namespace DataStructures
{
    public class Heap
    {
        public static void HeapifyDown(int[] arr, int i0, int end) 
        {
            int temp;
            int j;
            for(int i=i0; i*2+1 < end+1; )
            {
                j = i*2+2;
                if(j == arr.Length )
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
                    temp = arr[i*2+1];
                    arr[i*2+1] = arr[i];
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
            for (int i = 0; i < arr.Length;)
            { 

            }
        }


    }
}