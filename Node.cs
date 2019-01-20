using System;

namespace DataStructures
{
    public class Node<T>
    {
        private Node <T> next;
        private T element;
        public Node (T n)
        {
            this.element=n;
            this.Setnext(null);
        }
        public T  Element()
        {
            return element;
        }

        
        public Node <T> Getnext()
        {
            return next;
        }

        public void Setnext(Node <T> value)
        {
            next = value;
        }

        
    }
}
