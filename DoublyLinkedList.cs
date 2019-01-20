using System;
namespace DataStructures
{
    

    public class DoublyLinkedList<T>
    {
        private Node head;
        private Node tail;

        public DoublyLinkedList()
        {
            Size=0;          
        }
        public int Size{get; private set;}
        public T First{get{return head.Element;}}
        public T Last{get{return tail.Element;}}
        public bool IsEmpty()
        {
            return head==null;
        }
        public void AddFirst(T n)
        {
            Node num= new Node(n);

            if( head == null )
                head=tail=num;
            else
            {
                num.Next=this.head;
                head.Prev=num;
                num.Prev=null;
                head=num;
            }
            Size++;
        }
        public void AddLast(T n)
        {
            Node num= new Node(n);

            if( head == null )
                head=tail=num;
            else
            {
                num.Next=null;
                num.Prev=this.tail;
                tail.Next=num;
                tail=num;
            }
            Size++;
        }
        public T RemoveFirst()
        {
            T removed = head.Element;
            head = head.Next;
            head.Prev=null;
            Size--;
            return removed;
        }
        public T RemoveLast()
        {
            T removed = tail.Element;
            tail = tail.Prev;
            tail.Next=null;
            Size--;
            return removed;
        }
        public void Reverse()
        {
            Node temp=head;
            Node newnext=head.Next;
            while(temp!=null)
            {
                newnext=temp.Prev;
                temp.Prev=temp.Next;
                temp.Next=newnext;
                temp=temp.Prev;
            } 
            
            temp=head;
            head=tail;
            tail=temp;

        }
        public void Print()
        {
            Console.Write("[ ");
            Node printed=this.head;
            for(int i=0;i<this.Size;i++)
            { 
                if(i==0)
                {
                    Console.Write(head.Element);
                    if (i!= Size-1)
                        Console.Write(", ");
                }
                else 
                {
                    printed=printed.Next;
                    Console.Write(printed.Element);
                    if (i!= Size-1)
                        Console.Write(", ");
                }
                
            }
            Console.Write(" ]");
            Console.WriteLine();
           
        }
        private class Node
        {
            
            public Node(T n)
            {
                this.Element=n;
                this.Next=null;
                this.Prev=null;
            } 

            public Node Prev {get; set;}
            public T Element{get; set;}
            public Node Next{get; set;}

        }

        

    }
}
