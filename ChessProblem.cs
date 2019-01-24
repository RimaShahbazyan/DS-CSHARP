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
            int i=0;
            for(int j=0; j< size ;j--)
            {
                
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
                    // if(i==size-1) // checks if we got to the edge of the board 
                    // {
                        //j--; // goes to the previous column
                        
                        // if(j<0)
                        // {
                        //     throw new Exception("Not Possible");
                        // }

                        //i=queens[j]; // makes to start checking from the next row
                        //queens[j]=0; //erases the wrongly placed queen
                        
                   // }
                    
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