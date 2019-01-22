using System;
namespace DataStructures
{
    public class Chess
    {
        public byte[,] board = new byte[8,8];
        public void chess()
        {
            var Q = new {i=0 , j=0};
            
            // for(byte i=0; i<8;i++)
            // {
            //         for(int j=0; j<8;j++)
            //     {
            //         //board[i,j]=f;
            //     }

            // }
        }
        private void close (byte i1 ,byte j1)
        {
            byte i;
            byte j;
            for(i=0; i<8;i++)
            {
                board[i,j1]++;
                board[i1,i]++;
            }

            i=i1;
            j=j1;
            while (i*j!=0)
            {
                board[i,j]++;
                i--;j++;
            }

        }
        private byte min(byte a, byte b)
        {
            if(a<b)
                return a;
            return b;
        }

    }
}