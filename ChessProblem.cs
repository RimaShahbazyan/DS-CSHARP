using System;
using System.Collections.Generic;
namespace DataStructures
{
    public class Chess
    {
        static int size;
        // private static int[,] board;
        private static int[] queens;
        public Chess(int x)
        {
            size=x;
            queens = new int[size];
            // board = new int[size,size];
            chess();
        }
        
        private void chess()
        {
            for(int j=0; j< size && j>=0; )
            { 
                for(int i=queens[j]; i< size; i++)
                {
                    if(isAvailable(i,j))
                    {
                        queens[j]=i;
                        j++;
                        break;
                    }
                    if(i==size-1)
                    {
                        queens[j]=0;
                        j--;
                        
                        if(j<0)
                        {
                            throw new Exception("Not Possible");
                        }
                        i=queens[j];
                    }
                    
                }
            }
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
        public void PrintAnswer()
        {
            foreach (int k in queens)
            Console.WriteLine(k);
        }
        // public  void PrintBoard()
        // {
        //     foreach (int k in queens)
        //     {
        //         board[k,queens[k]]=1;
        //     }
        //     for (int i=0; i<size; i++)
        //     {
        //         for (int j=0; j<size;j++)
        //         {
        //             Console.Write(board[i,j]+"  ");
        //         }
        //         Console.WriteLine();
        //     }
        // }

        public int abs(int a)
        {
            if (a>0)
                return a;
            else return -a;
        }
        

    }
}