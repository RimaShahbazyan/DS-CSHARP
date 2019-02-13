using System;
namespace DataStructures
{
    public class Hip
    {
        public static void HipifyDown(int[] arr) 
        {
            int temp;
            int j;
            for(int i=0; i*2+1 < arr.Length; )
            {
                j= i*2+2;
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
        public static void HipifyUp(int[] arr, int j)
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
        

    }
}