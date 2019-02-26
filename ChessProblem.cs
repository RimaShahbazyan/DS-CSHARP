using System;
using System.Collections.Generic;
namespace DS_CSHARP
{
    public class Chess
    {
        int size=0;
        private  int[] queens=null;
        public Chess(int x)
        {
            size=x;
            queens = new int[size];
            chess();
        }
        
        private void chess()
        {
            int i=0;
            for(int j=0; j< size ;j--)
            {
                if(j<0)
                {
                    throw new Exception("not possible");
                }
                
                if(i==size)
                {
                    i=queens[j]+1;
                    queens[j+1]=0;
                }
                else i=queens[j];
                
                for(; i< size; i++)
                {
                    if(isAvailable(i,j))
                    {
                        queens[j]=i;    // puts the Queen
                        j+=2;    // passes to next column
                        break;
                    }
                }
            }
            PrintAnswer();
        }
        private bool isAvailable (int qi, int qj)
        {
            for (int j=0; j<qj; j++)
            {
                if (qj-j==abs(qi-queens[j]) || queens[j]==qi)
                    return false;
            }
            return true;
        }
        private void PrintAnswer()
        {
            foreach (int k in queens)
            Console.WriteLine(k);
        }
        
        public int abs(int a)
        {
            if (a>0)
                return a;
            else return -a;
        }
        

    }
}