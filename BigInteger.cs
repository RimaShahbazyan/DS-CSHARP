using System;
namespace DataStructures
{
    public class BigInteger :IComparable<BigInteger> //IBigInteger
    {
        SinglyLinkedList <int> list;
        private bool sign=true;
        public BigInteger()
        {
            list=new SinglyLinkedList<int>();
            list.AddLast(0);
            
        }
        public BigInteger(long value)
        {
            if (value<0)
            {
                this.sign=false;
                value=-value;
            }
            
            
            list=new SinglyLinkedList<int>();
            if (value==0)
                list.AddLast(0);
            else
                while (value!=0)
                {
                    list.AddLast((int)(value%10));
                    value=value/10;
                }
        }
        public BigInteger(string value)
        {
            
            list=new SinglyLinkedList<int>();
            if(value==null|| value =="")
                list.AddLast(0);
            if(value[0]=='-')
                {
                    this.sign=false;
                    value=value.Substring(1);
                }
            foreach (char i in value)
            {
                list.AddFirst(i-'0');
            }

        }
        public bool Sign {get {return sign;} private set{sign=value;}}
        public void Print()
        {
            list.Reverse();
            list.Print();
            list.Reverse();
        }
        
       public int CompareTo(BigInteger num)
        {

            if(!num.sign && this.sign)
            return 1;
            if(num.sign && !this.sign)
            return -1;

            if(!num.sign)
            return -CompareAbs(num);
            return CompareAbs(num);
        }

        private int CompareAbs(BigInteger num)
        {
        
            if(this.list.Size()>num.list.Size())
            return 1;

            else if (this.list.Size()<num.list.Size())
            return -1;

            else
            {
                int i=1;
                while(i<=this.list.Size())
                {
                    if(this.list.First()==num.list.First())
                    {
                        this.list.AddLast(this.list.RemoveFirst());
                        num.list.AddLast(num.list.RemoveFirst());
                        i++;
                        continue;
                    }
                    if(this.list.First()>num.list.First())
                    return 1; 
                    return -1;
                }
                return 0;
            }

        }
        public static BigInteger Add(BigInteger n1, BigInteger n2)
        {
            
            BigInteger sum = new BigInteger();
            sum.list.RemoveFirst();

            if(n1.sign==n2.sign)
                sum.sign=n1.sign;
            else 
            {
                if (!n1.sign)
                {
                    n1.sign=true;
                    sum=Subtract(n2,n1);
                    n1.sign=false;
                }
                else
                {
                    n2.sign=true;
                    sum=Subtract(n1,n2);
                    n2.sign=false;
                }
                return sum;
            }

            SinglyLinkedList<int> list1 = new SinglyLinkedList<int>();
            SinglyLinkedList<int> list2 = new SinglyLinkedList<int>();

            int x=0;
            while (!n1.list.IsEmpty() && !n2.list.IsEmpty())
            {
               
               
                x = n1.list.First()+n2.list.First()+x;
                
                list1.AddLast(n1.list.RemoveFirst());
                list2.AddLast(n2.list.RemoveFirst());
               
                sum.list.AddLast( x%10);
                    x/=10;

                if(n1.list.IsEmpty())
                {
                    while (!n2.list.IsEmpty())
                    {
                        sum.list.AddLast((n2.list.First()+x)%10);
                        x=(n2.list.First()+x)/10;
                        list2.AddLast(n2.list.RemoveFirst()); 
                    }
                }
                else if(n2.list.IsEmpty())
                {
                    while (!n1.list.IsEmpty())
                    {
                        sum.list.AddLast((n1.list.First()+x)%10);
                        x=(n1.list.First()+x)/10;
                        list1.AddLast(n1.list.RemoveFirst());
                        
                    }
                    
                    
                }
                
            }
            
            if(x==1)
                sum.list.AddLast(x);

            n1.list = list1;
            n2.list = list2;

            
            return sum;
        }

        public static BigInteger Subtract(BigInteger n1, BigInteger n2)
        {
            
            BigInteger sub = new BigInteger();
            sub.list.RemoveFirst();

            if(n1.sign && !n2.sign)
            {
                n2.sign = true;
                sub= Add(n1,n2);
                n2.sign = false;
                return sub;
            }
            if(!n1.sign && n2.sign)
            {
                n2.sign = false;
                sub= Add(n1,n2);
                n2.sign = true;
                return sub;
            }

            if(n1.CompareAbs(n2)<0 )
            {
                sub=Subtract(n2,n1);
                sub.sign=!n1.sign;
                return sub;
            }

            SinglyLinkedList<int> list1 = new SinglyLinkedList<int>();
            SinglyLinkedList<int> list2 = new SinglyLinkedList<int>();
            sub.sign=n1.sign;
            int x=0;
            while (!n1.list.IsEmpty() && !n2.list.IsEmpty())
            {
               
                x = n1.list.First()-n2.list.First()-x;
                
                if(x<0)
                {
                    sub.list.AddLast(x+10);
                    x=1;
                }
                
                
                else
                {
                    sub.list.AddLast(x);
                    x=0;
                }
                
                list1.AddLast(n1.list.RemoveFirst());
                list2.AddLast(n2.list.RemoveFirst());
               

                if(n2.list.IsEmpty())
                {
                    while (!n1.list.IsEmpty())
                    {
                        if (n1.list.First()==0 && x==1)
                            sub.list.AddLast(9);
                        else
                        {
                            sub.list.AddLast(n1.list.First()-x);
                            x=0;
                        }
                        list1.AddLast(n1.list.RemoveFirst());
                    }
                } 
            }
            
            while(sub.list.Last()==0 && sub.list.Size()!=1)
                        sub.list.RemoveLast();
            
            sub.Trim();
            n1.list = list1;
            n2.list = list2;

            return sub;
        }

        private void Trim()
        {
            this.list.Reverse();

            while(this.list.First()==0 && this.list.Size()!=1)
                this.list.RemoveFirst();

            this.list.Reverse();
        }

        public static BigInteger MultSimple(BigInteger n1, int n2)
        {
            int x=0;
            
            BigInteger multSimple= new BigInteger();
            multSimple.list.RemoveFirst();
            SinglyLinkedList<int> list1 = new SinglyLinkedList<int>();
            while(!n1.list.IsEmpty())
            {
                multSimple.list.AddLast((n1.list.First()*n2+x)%10);
                x=(n1.list.First()*n2+x)/10;
                list1.AddLast(n1.list.RemoveFirst());
            }
            while(x!=0)
            {
                multSimple.list.AddLast(x%10);
                x/=10;
            }
            n1.list=list1;
            return multSimple;
        }
        public static BigInteger Multiply(BigInteger n1, BigInteger n2)
        {
            bool sign1=true;
            bool sign2=true;
            

            if(n1.CompareAbs(n2)<0)
                return Multiply(n2,n1);
            BigInteger mult = new BigInteger();
            SinglyLinkedList<int> list2 = new SinglyLinkedList<int>();
            if(!n1.sign)
            {
                n1.sign=true;
                sign1=false;
            }
            if(!n2.sign)
            {
                n2.sign=true;
                sign2=false;
            }

            while(!n2.list.IsEmpty())
            {
                int a=list2.Size();
                BigInteger simple=MultSimple(n1,n2.list.First());
                while(a>0)
                {
                    simple.list.AddFirst(0);
                    a--;
                }
                
                mult=Add(simple, mult);
                list2.AddLast(n2.list.RemoveFirst());
            }
            mult.Trim();
            mult.sign=!(sign1^sign2);
            n1.sign=sign1;
            n2.sign=sign2;

            return mult;
        }



        public static BigInteger operator +(BigInteger num1,BigInteger num2)
        {
            return Add(num1, num2);
        }

        public static BigInteger operator *(BigInteger num1, BigInteger num2)
        {
            return Multiply(num1, num2);
        }
        public static BigInteger operator -(BigInteger num1, BigInteger num2)
        {
            return Subtract(num1, num2);
        }

    }
}