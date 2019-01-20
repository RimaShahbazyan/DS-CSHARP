using System;

namespace DataStructures
{
    public class SinglyLinkedList <T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int size=0;
        public SinglyLinkedList()
        {
            size=0;
        }
        
        public T First()
        {
            if (head != null) 
              return head.Element();

             return default(T);
        }


        public T Last()
        {
            if (tail!= null)
                return tail.Element();

             return default(T);
        }
        
        
        public int Size()
        {
            return size;
        }
        public bool IsEmpty()
        {
            return this.size==0;
        }
        public void AddFirst( T element)
        {
            Node<T> newNode= new Node<T>(element);
            if (head==null)
            {
                head=newNode;
                tail=newNode;
            }
            else
            {
                newNode.Setnext(head);
                head=newNode;
            }
            size++;

        }

        public void AddLast( T element)
        {
            Node<T> newNode= new Node<T>(element);
            if (tail==null)
            {
                head=newNode;
                tail=newNode;
            }
            else
            {
                tail.Setnext(newNode);
                tail=newNode;
            }
            size++;

        }

        public T RemoveFirst()
        {
            if (head!=null)
            {
                Node<T> deleted = head;
                head= head.Getnext();
                deleted.Setnext(null);
                if(size==1)
                    tail=null;
                size--;
                return deleted.Element();
            }
            return default(T);

        }

#region extended
        public T RemoveLast()
        {
            if (IsEmpty())
                return default(T);
            
                
            Node<T> deleted = tail;
            
            if (size==1)
            {
                head=null;
                tail=null;
            }
            else 
            {
                tail=head;
                for(int i =0;i<size-2;i++)
                {
                    tail=tail.Getnext();
                }
                tail.Setnext(null);
                    
            }
            size--;
            return deleted.Element();
        
        }

        public void Print()
        {
            Console.Write("[ ");
           Node<T> printed=this.head;
            for(int i=0;i<this.size;i++)
            { 
                if(i==0)
                {
                    Console.Write(head.Element());
                    if (i!= size-1)
                    Console.Write(", ");
                }
                else 
                {
                    printed=printed.Getnext();
                    Console.Write(printed.Element());
                    if (i!= size-1)
                    Console.Write(", ");
                }
                
            }
            Console.Write(" ]");
           
        }

        public void Reverse()
        {
            if(head==null || head==tail)
            return;
            Node <T> A=null;
            Node <T> B=head;
            Node <T> C=head.Getnext();
            tail=head;
            while(B!=null)
            {
                B.Setnext(A);
                A=B;
                B=C;
                
                if(C!=null)
                {
                    C=C.Getnext();
                } 
                
            }
            head=A;
            

        }

#endregion

    }
}
