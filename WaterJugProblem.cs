using System;
namespace DataStructures
{
    public class WaterJugProblem
    {
        private WaterJugProblem(int jug1, int jug2, int result)
        {
            Solve( jug1,  jug2, result);
        }
        public static  int[] Solve(int jug1, int jug2, int result)
        {
            if(result%GCD.gcd(jug1,jug2)!=0)
                throw new Exception("not possible!");
            int i=0,j=0,remained=0;
            while(remained!=result)
            {
                if(remained>result)
                {
                    remained-=jug1;
                    i++;
                }
                else
                {
                    remained+=jug2;
                    j++;
                }
            }
            int[] answer={i,j};
            return answer;
        }
    }
}